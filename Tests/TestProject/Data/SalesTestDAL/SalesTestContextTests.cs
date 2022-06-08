using Microsoft.EntityFrameworkCore;
using SalesTest.DAL;
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
            Assert.True(db.Products.ToListAsync().Result.Count == 0);
            Assert.True(db.ProvidedProducts.ToListAsync().Result.Count == 0);
            Assert.True(db.Sales.ToListAsync().Result.Count == 0);
            Assert.True(db.SalesData.ToListAsync().Result.Count == 0);
            Assert.True(db.SalesPoints.ToListAsync().Result.Count == 0);
        }
    }
}
