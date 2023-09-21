using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsReviewWebAPI2.Data;
using ProductsReviewWebAPI2.Models;
using ProductsReviewWebAPI2.NewFolder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsReviewWebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] int? maxPrice)
        {
            var products = _context.Products.ToList();
            if (maxPrice != null)
            {
                products = products.Where(price => price.Price < maxPrice).ToList();
            }

            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] int id)
        {
            var product = _context.Products
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Reviews = product.Reviews.Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    Rating = r.Rating,
                }).ToList()
            };              
            return Ok(productDTO);
        }
        

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201, product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var productToUpdate = _context.Products.Find(id);
            if (productToUpdate == null) 
            {
                return NotFound();
            } 
            productToUpdate.Price = product.Price;
            productToUpdate.Reviews = product.Reviews;

            _context.Products.Add(productToUpdate);
            _context.SaveChanges();

            return Ok(productToUpdate);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
