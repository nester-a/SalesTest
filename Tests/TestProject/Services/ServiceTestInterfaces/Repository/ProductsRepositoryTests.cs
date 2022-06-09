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
        public void ProductsRepository_Add_Test()
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
        public void ProductsRepository_Update_Test()
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
            product.Price = 100.25m;

            var updated = repo.Update(product.Id, product);
            repo.Save();

            Assert.True(updated == 1);
            productDal = db.Products.Find(updated);

            Assert.True(productDal.Name == product.Name);
            Assert.True(productDal.Price == product.Price);
        }

        [Fact]
        public void ProductsRepository_GetAll_Test()
        {

            var product1 = new Product()
            {
                Name = "Hello",
                Price = 15.12m,

            };
            var product2 = new Product()
            {
                Name = "World",
                Price = 100.25m,
            };

            repo.Add(product1);
            repo.Add(product2);
            repo.Save();

            Assert.True(db.Products.Count() == 2);

            var result = repo.GetAll();
            Assert.Equal(2, result.Count);

            var entity1 = result.FirstOrDefault(e => e.Name == product1.Name);
            Assert.True(entity1 is not null);
            Assert.Equal(entity1.Name, product1.Name);
            Assert.Equal(entity1.Price, product1.Price);

            var entity2 = result.FirstOrDefault(e => e.Name == product2.Name);
            Assert.True(entity2 is not null);
            Assert.Equal(entity2.Name, product2.Name);
            Assert.Equal(entity2.Price, product2.Price);
        }

        [Fact]
        public void ProductsRepository_GetById_Test()
        {

            var product1 = new Product()
            {
                Name = "Hello",
                Price = 15.12m,

            };
            var product2 = new Product()
            {
                Name = "World",
                Price = 100.25m,
            };

            var id1 = repo.Add(product1);
            var id2 = repo.Add(product2);
            repo.Save();

            Assert.True(db.Products.Count() == 2);

            var result1 = repo.GetById(id1);
            Assert.True(result1 is not null);
            Assert.Equal(result1.Name, product1.Name);
            Assert.Equal(result1.Price, product1.Price);

            var result2 = repo.GetById(id2);
            Assert.True(result2 is not null);
            Assert.Equal(result2.Name, product2.Name);
            Assert.Equal(result2.Price, product2.Price);
        }
    }
}
