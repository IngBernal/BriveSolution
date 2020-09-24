using System;
using Brive.Core.Entities;
using Brive.Infraestructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brive.Infraestructure.Data
{
    public partial class BriveContext : DbContext
    {
        public BriveContext()
        {
        }

        public BriveContext(DbContextOptions<BriveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SucursalA> SucursalA { get; set; }
        public virtual DbSet<SucursalB> SucursalB { get; set; }
        public virtual DbSet<Product> Prodcuts { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SucursalAConfiguration());
            modelBuilder.ApplyConfiguration(new SucursalBConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
