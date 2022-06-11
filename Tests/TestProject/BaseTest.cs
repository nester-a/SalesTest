using Microsoft.EntityFrameworkCore;
using SalesTest.DAL;

namespace TestProject
{
    public abstract class BaseTest
    {
        private static DbContextOptionsBuilder<SalesTestContext> optionBuilder = new DbContextOptionsBuilder<SalesTestContext>();
        private static DbContextOptions<SalesTestContext> option = optionBuilder.UseInMemoryDatabase("TestDB").Options;
        protected static SalesTestContext db = new SalesTestContext(option);

        static BaseTest()
        {
            DbInitializer.Initializer(db);
        }
    }
}
