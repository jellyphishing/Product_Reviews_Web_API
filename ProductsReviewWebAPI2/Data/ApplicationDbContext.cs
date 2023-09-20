
using Microsoft.EntityFrameworkCore;

namespace ProductsReviewWebAPI2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }
    }
}
