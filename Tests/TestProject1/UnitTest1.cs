using Microsoft.EntityFrameworkCore;
using SalesTest.DAL;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var optionBuilder = new DbContextOptionsBuilder<SalesTestContext>();
            var option = optionBuilder.UseInMemoryDatabase("SalesTest").Options;
            SalesTestContext db = new SalesTestContext(option);
            DbInitializer.Initializer(db);
            Assert.True(db is not null);
        }
    }
}
