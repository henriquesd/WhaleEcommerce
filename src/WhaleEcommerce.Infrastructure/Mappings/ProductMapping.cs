using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.Infrastructure.Mappings
{

    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Description)
                .HasColumnType("varchar(350)");

            builder.ToTable("Books");
        }
    }
}
