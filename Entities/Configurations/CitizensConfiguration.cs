using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class CitizensConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).HasMaxLength(250).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(250).IsRequired();
        }
    }
}