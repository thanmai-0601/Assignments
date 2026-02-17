using Microsoft.EntityFrameworkCore;

namespace ProductsSQLAPI.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
        {
        }

        public DbSet<CProducts> Products { get; set; } = null!;
    }
}
