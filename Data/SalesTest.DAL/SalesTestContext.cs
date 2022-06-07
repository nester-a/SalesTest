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
        public void Configure(EntityTypeBuilder<Buyer> builder>)
        {
            // todo
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // todo
        }
    }

    public class ProvidedProductConfiguration : IEntityTypeConfiguration<ProvidedProduct>
    {
        public void Configure(EntityTypeBuilder<ProvidedProduct> builder)
        {
            // todo
        }
    }

    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            // todo
        }
    }

    public class SalesDataConfiguration : IEntityTypeConfiguration<SalesData>
    {
        public void Configure(EntityTypeBuilder<SalesData> builder)
        {
            // todo
        }
    }

    public class SalesPointsConfiguration : IEntityTypeConfiguration<SalesPoints>
    {
        public void Configure(EntityTypeBuilder<SalesPoints> builder)
        {
            // todo
        }
    }
}
