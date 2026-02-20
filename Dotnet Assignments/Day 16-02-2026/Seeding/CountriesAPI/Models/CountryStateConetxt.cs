using Microsoft.EntityFrameworkCore;

namespace CountriesAPI.Models
{
    public class CountryStateContext : DbContext
    {
        public CountryStateContext(DbContextOptions<CountryStateContext> options) : base(options)
        {
        }

        //Seeding of data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Relationship (Country - State)
            modelBuilder.Entity<State>()
                .HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CntryId);

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CId = 1, CName = "India", CCode = "IND" },
                new Country { CId = 2, CName = "Australia", CCode = "AUS" }
            );

            // Seed States
            modelBuilder.Entity<State>().HasData(
                new State { SId = 1, SName = "Odisha", CntryId = 1 },
                new State { SId = 2, SName = "Delhi", CntryId = 1 },
                new State { SId = 3, SName = "New South Wales", CntryId = 2 }
            );
        }

        // DbSets (Tables)
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}
