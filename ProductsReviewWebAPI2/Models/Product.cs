using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsReviewWebAPI2.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        //Navigation Property
        public ICollection<Review> Reviews { get; set; }
        public int ProductId { get; set; }
    }
}

