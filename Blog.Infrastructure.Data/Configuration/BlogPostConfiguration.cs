using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPC.TN.DataAccess.Configuration
{
    internal class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(r => r.Title)
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(r => r.Content)
            .HasMaxLength(1000)
            .IsRequired();
        }
    }
}