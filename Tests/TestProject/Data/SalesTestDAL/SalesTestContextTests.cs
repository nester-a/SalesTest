using Microsoft.EntityFrameworkCore;
using SalesTest.DAL;
using SalesTest.DAL.Enities;
using Xunit;

namespace TestProject.Data.SalesTestDAL
{
    public class SalesTestContextTests
    {
        [Fact]
        public void ContextEnsureCreatedTest()
        {

            var optionBuilder = new DbContextOptionsBuilder<SalesTestContext>();
            var option = optionBuilder.UseInMemoryDatabase("TestDB").Options;
            SalesTestContext db = new SalesTestContext(option);

            bool errorCatched = false;
            try
            {
                DbInitializer.Initializer(db);
            }
            catch
            {
                errorCatched = true;
            }

            Assert.False(errorCatched);
            Assert.True(db is not null);
            Assert.True(db.Buyers.ToListAsync().Result.Count == 0);
            Assert.True(db.Products.ToListAsync().Result.Count == 0);
            Assert.True(db.ProvidedProducts.ToListAsync().Result.Count == 0);
            Assert.True(db.Sales.ToListAsync().Result.Count == 0);
            Assert.True(db.SalesData.ToListAsync().Result.Count == 0);
            Assert.True(db.SalesPoints.ToListAsync().Result.Count == 0);
        }

        [Fact]
        public void AddBuyerDataTest()
        {
            Buyer b = new Buyer() { Name = "Hello" };
            var optionBuilder = new DbContextOptionsBuilder<SalesTestContext>();
            var option = optionBuilder.UseInMemoryDatabase("TestDB").Options;
            SalesTestContext db = new SalesTestContext(option);

            bool errorCatched = false;
            try
            {
                DbInitializer.Initializer(db);
            }
            catch
            {
                errorCatched = true;
            }

            Assert.False(errorCatched);
            var result = db.Buyers.Add(b).Entity;
            db.SaveChangesAsync().Wait();

            Assert.True(result.Name == b.Name);
            Assert.True(result.Id == 1);
            Assert.True(db.Buyers.ToListAsync().Result.Count != 0);
            Assert.True(db.Buyers.ToListAsync().Result.Count == 1);
        }
    }
}
