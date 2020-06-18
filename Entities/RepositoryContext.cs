using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        private readonly IEntityTypeConfiguration<User> _userConfiguration;
        private readonly IEntityTypeConfiguration<Citizen> _citizensConfiguration;
        private readonly IEntityTypeConfiguration<City> _citiesConfiguration;
        private readonly IEntityTypeConfiguration<State> _statesConfiguration;
        public DbContextOptions Options;
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Citizen> Citizen { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<State> State { get; set; }


        public RepositoryContext(DbContextOptions options, 
            IEntityTypeConfiguration<User> userConfiguration, 
            IEntityTypeConfiguration<Citizen> citizensConfiguration, 
            IEntityTypeConfiguration<City> citiesConfiguration, 
            IEntityTypeConfiguration<State> statesConfiguration)
            : base(options)
        {
            this.Options = options;
            this._userConfiguration = userConfiguration;
            this._citizensConfiguration = citizensConfiguration;
            this._citiesConfiguration = citiesConfiguration;
            this._statesConfiguration = statesConfiguration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(_userConfiguration)
                .ApplyConfiguration(_citizensConfiguration)
                .ApplyConfiguration(_citiesConfiguration)
                .ApplyConfiguration(_statesConfiguration);
        }
    }
}
