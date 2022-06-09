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

        [Fact]
        public void ProductsRepository_Update_Test()
        {
            var salesPoint = new SalesPoint()
            {
                Name = "Hello",
            };

            var added = repo.Add(salesPoint);
            repo.Save();

            Assert.True(added == 1);
            var salesPointDal = db.SalesPoints.Find(added);

            Assert.True(salesPointDal.Id == 1);
            Assert.True(salesPointDal.Name == salesPoint.Name);

            salesPoint.Id = salesPointDal.Id;
            salesPoint.Name = "Hello World";

            var updated = repo.Update(salesPoint.Id, salesPoint);
            repo.Save();

            Assert.True(updated == 1);
            salesPointDal = db.SalesPoints.Find(updated);

            Assert.True(salesPointDal.Name == salesPoint.Name);
        }
    }
}
