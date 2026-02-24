using Microsoft.EntityFrameworkCore;
using Insurance_crud_api.Models;

namespace Insurance_crud_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Policy> Policies => Set<Policy>();
    }
}