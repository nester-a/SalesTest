using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTest.DAL.Enities;

namespace SalesTest.DAL
{
    public class SalesTestContext : DbContext
    {
        public SalesTestContext(DbContextOptions<SalesTestContext> options) : base(options)
        {

        }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProvidedProduct> ProvidedProducts { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesData> SalesData { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BuyerConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProvidedProductConfiguration());
            builder.ApplyConfiguration(new SalesConfiguration());
            builder.ApplyConfiguration(new SalesDataConfiguration());
            builder.ApplyConfiguration(new SalesPointsConfiguration());
            base.OnModelCreating(builder);
        }
    }

    
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired();
            builder.HasMany(b => b.Sales).WithOne(s => s.Buyer).HasForeignKey(b => b.BuyerId);
        }
    }

    
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Price).IsRequired();
        }
    }

    
    public class ProvidedProductConfiguration : IEntityTypeConfiguration<ProvidedProduct>
    {
        public void Configure(EntityTypeBuilder<ProvidedProduct> builder)
        {
            builder.HasKey(pp => new { pp.SalesPointId, pp.ProductId });
            //builder.HasKey(pp => pp.ProductId);
            builder.Property(pp => pp.ProductQuantity).IsRequired();
        }
    }

    
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.DateTime).IsRequired();
            builder.HasOne(s => s.Buyer).WithMany(b => b.Sales).HasForeignKey(s => s.BuyerId);
            builder.Property(s => s.SalesPointId).IsRequired();
            builder.HasMany(s => s.SalesData).WithOne(sd => sd.Sales).HasForeignKey(sd => sd.SalesId);
        }
    }

    
    public class SalesDataConfiguration : IEntityTypeConfiguration<SalesData>
    {
        public void Configure(EntityTypeBuilder<SalesData> builder)
        {
            builder.HasKey(sd => new { sd.ProductId, sd.SalesId });
            //builder.HasKey(sd => sd.SalesId);
            builder.Property(sd => sd.ProductQuantity).IsRequired();
            builder.Property(sd => sd.ProductIdAmount).IsRequired();
        }
    }

    public class SalesPointsConfiguration : IEntityTypeConfiguration<SalesPoint>
    {
        public void Configure(EntityTypeBuilder<SalesPoint> builder)
        {
            builder.HasKey(sp => sp.Id);
            builder.HasIndex(sp => sp.Id).IsUnique();
            builder.Property(sp => sp.Id).ValueGeneratedOnAdd();
            builder.Property(sp => sp.Name).IsRequired();
            builder.HasMany(sp => sp.ProvidedProducts).WithOne(pp => pp.SalesPoint).HasForeignKey(sp => sp.SalesPointId);
        }
    }
}
