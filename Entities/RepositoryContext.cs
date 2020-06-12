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

        public DbSet<User> Users { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordSalt)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .IsRequired();


            modelBuilder.Entity<Citizen>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Citizen>().Property(c => c.FirstName)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<Citizen>().Property(c => c.LastName)
                .HasMaxLength(250)
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<State>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<State>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<City>()
                .HasMany(c => c.Citizens)
                .WithOne(c => c.City)
                .IsRequired();

            modelBuilder.Entity<State>()
                .HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .IsRequired();

        }
    }
}
