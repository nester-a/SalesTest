using SalesTest.Domain;
using SalesTest.SalesTest.Interfaces.Repository;
using System.Linq;
using Xunit;

namespace TestProject.Services.ServiceTestInterfaces.Repository
{
    public class ProductsRepositoryTests : BaseTest
    {
        static ProductRepository repo = new ProductRepository(db);

        [Fact]
        public void BuyerRepository_Add_Test()
        {

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

        [Fact]
        public void BuyerRepository_Update_Test()
        {
            var product = new Product()
            {
                Name = "Hello",
                Price = 15.12m,
            };

            var added = repo.Add(product);
            repo.Save();

            Assert.True(added == 1);
            var productDal = db.Products.Find(added);

            Assert.True(productDal.Id == 1);
            Assert.True(productDal.Name == product.Name);
            Assert.True(productDal.Price == product.Price);

            product.Id = productDal.Id;
            product.Name = "Hello World";

            var updated = repo.Update(product.Id, product);
            repo.Save();

            Assert.True(updated == 1);
            productDal = db.Products.Find(updated);

            Assert.True(productDal.Name == product.Name);
        }
    }
}
