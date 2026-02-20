using Microsoft.EntityFrameworkCore;
using RoleBasedJWT.Models;

namespace RoleBasedJWT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Employee> Employees => Set<Employee>();

    }
}
