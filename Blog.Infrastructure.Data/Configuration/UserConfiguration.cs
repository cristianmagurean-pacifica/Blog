using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPC.TN.DataAccess.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(r => r.FirstName)
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(r => r.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
               new User { Id = 1, FirstName = "John", LastName = "Doe" }
            );
        }
    }
}