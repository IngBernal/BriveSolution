using Brive.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brive.Infraestructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Code)
                 .IsRequired()
                 .HasMaxLength(6)
                 .IsUnicode(false)
                 .IsFixedLength();

            builder.Property(e => e.UnitPrice)
               .HasColumnType("decimal(6, 2)");
        }
    }
}
