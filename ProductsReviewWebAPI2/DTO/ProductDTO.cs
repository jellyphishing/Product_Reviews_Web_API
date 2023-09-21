using ProductsReviewWebAPI2.Controllers;
using ProductsReviewWebAPI2.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductsReviewWebAPI2.NewFolder
{
    public class ProductDTO
    {
       

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        //Navigation Property
        public ICollection<ReviewDTO> Reviews { get; set; }
        public double AverageRating { get; set; }
        public object ProductId { get; internal set; }
    }
}
