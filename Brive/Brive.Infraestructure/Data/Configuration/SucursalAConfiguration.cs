﻿using Brive.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brive.Infraestructure.Data.Configuration
{
    public class SucursalAConfiguration : IEntityTypeConfiguration<SucursalA>
    {
        public void Configure(EntityTypeBuilder<SucursalA> builder)
        {
            builder.ToTable("SucursalA");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.ProductName)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(e => e.Code)
                   .IsRequired()
                   .HasMaxLength(6)
                   .IsUnicode(false)
                   .IsFixedLength();

            builder.Property(e => e.Quantity)
                  .IsRequired();
                  
            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(6, 2)");
        }
    }
}
