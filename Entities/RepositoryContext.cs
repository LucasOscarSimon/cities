using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public RepositoryContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citizen>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<State>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Citizen>().Property(c => c.FullName)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<State>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<City>()
                .HasMany(c => c.Citizens)
                .WithOne(c => c.City);

            modelBuilder.Entity<State>()
                .HasMany(s => s.Cities)
                .WithOne(c => c.State);

        }
    }
}
