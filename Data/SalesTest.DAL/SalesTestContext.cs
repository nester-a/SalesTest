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

    //сделано не менять
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.Name).IsRequired();
            builder.HasMany(b => b.Sales).WithOne(s => s.Buyer).HasForeignKey(b => b.Id);
        }
    }

    //сделано не менять
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Price).IsRequired();
        }
    }

    //сделано не менять
    public class ProvidedProductConfiguration : IEntityTypeConfiguration<ProvidedProduct>
    {
        public void Configure(EntityTypeBuilder<ProvidedProduct> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.ProductQuantity).IsRequired();
        }
    }

    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.DateTime).IsRequired();
            builder.Property(b => b.SalesPointId).IsRequired();
            builder.Property(b => b.TotalAmount).IsRequired();
            builder.HasMany(b => b.SalesData).WithOne(s => s.Sale).HasForeignKey(b => b.Id);
        }
    }

    public class SalesDataConfiguration : IEntityTypeConfiguration<SalesData>
    {
        public void Configure(EntityTypeBuilder<SalesData> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.ProductQuantity).IsRequired();
            builder.Property(b => b.ProductIdAmount).IsRequired();
        }
    }

    public class SalesPointsConfiguration : IEntityTypeConfiguration<SalesPoint>
    {
        public void Configure(EntityTypeBuilder<SalesPoint> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.Name).IsRequired();
            builder.HasMany(b => b.ProvidedProducts);
        }
    }
}
