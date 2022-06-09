using SalesTest.Domain;
using SalesTest.SalesTest.Interfaces.Repository;
using System.Linq;
using Xunit;

namespace TestProject.Services.ServiceTestInterfaces.Repository
{
    public class SalesPointRepositoryTests : BaseTest
    {
        static SalesPointRepository repo = new SalesPointRepository(db);

        [Fact]
        public void ProductsRepository_Add_Test()
        {

            var salesPoint = new SalesPoint()
            {
                Name = "Hello",
            };

            var result = repo.Add(salesPoint);
            repo.Save();

            Assert.True(result == 1);
            Assert.True(db.SalesPoints.Find(result).Name == salesPoint.Name);
        }
    }
}
