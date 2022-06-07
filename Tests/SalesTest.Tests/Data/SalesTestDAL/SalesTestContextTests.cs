using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTest.DAL;
using Assert = Xunit.Assert;

namespace SalesTest.Tests.Data.SalesTestDAL
{
    [TestClass]
    public class SalesTestContextTests
    {
        [TestMethod]
        public void ContextCreated()
        {
            var optionBuilder = new DbContextOptionsBuilder<SalesTestContext>();
            var option = optionBuilder.UseInMemoryDatabase("SalesTest").Options;
            SalesTestContext db = new SalesTestContext(option);
            DbInitializer.Initializer(db);
            Assert.True(db is not null);
        }
    }
}
