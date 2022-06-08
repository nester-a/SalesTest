using SalesTest.Domain;
using SalesTest.SalesTest.Interfaces.Repository;
using System.Linq;
using Xunit;

namespace TestProject.Services.ServiceTestInterfaces.Repository
{
    public class ProductsRepositoryTests : BaseTest
    {
        [Fact]
        public void BuyerRepository_Add_Test()
        {
            ProductRepository repo = new ProductRepository(db);

            var product = new Product()
            {
                Name = "Hello",
                Price = 15.12m,
            };

            var result = repo.Add(product);
            repo.Save();

            Assert.True(result == 1);
            Assert.True(db.Products.Find(result).Name == product.Name);
            Assert.True(db.Products.Find(result).Price == product.Price);
        }
    }
}
