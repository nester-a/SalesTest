using SalesTest.Domain;
using SalesTest.Interfaces.Reposiroty;
using SalesTest.SalesTest.Interfaces.Repository;
using System.Linq;
using Xunit;

namespace TestProject.Services.ServiceTestInterfaces.Repository
{
    public class ProvidedProductRepositoryTests : BaseTest
    {
        static ProvidedProductRepository repo = new ProvidedProductRepository(db);

        [Fact]
        public void ProvidedProductRepository_Add_Test()
        {

            var pp = new ProvidedProduct()
            {
                ProductId = 1,
                ProductQuantity = 1,
            };

            var result = repo.Add(pp);
            repo.Save();

            Assert.True(result == 1);
            Assert.True(db.ProvidedProducts.Find(result).ProductId == pp.ProductId);
        }
    }
}
