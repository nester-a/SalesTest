using SalesTest.Domain;
using SalesTest.SalesTest.Interfaces.Repository;
using System.Linq;
using Xunit;

namespace TestProject.Services.ServiceTestInterfaces.Repository
{
    public class BuyerRepositoryTests : BaseTest
    {
        //static DbContextOptionsBuilder<SalesTestContext> optionBuilder = new DbContextOptionsBuilder<SalesTestContext>();
        //static DbContextOptions<SalesTestContext> option = optionBuilder.UseInMemoryDatabase("TestDB").Options;
        //static SalesTestContext db = new SalesTestContext(option);

        //static BuyerRepositoryTests()
        //{
        //    DbInitializer.Initializer(db);
        //}

        static BuyerRepository repo = new BuyerRepository(db);
        [Fact]
        public void BuyerRepository_Add_Test()
        {

            var buyer = new Buyer()
            {
                Name = "Hello",
            };

            var result = repo.Add(buyer);
            repo.Save();

            Assert.True(result == 1);
            Assert.True(db.Buyers.Find(result).Name == buyer.Name);
        }

        [Fact]
        public void BuyerRepository_Update_Test()
        {

            var buyer = new Buyer()
            {
                Name = "Hello",
            };

            var added = repo.Add(buyer);
            repo.Save();

            Assert.True(added == 1);
            var buyerDal = db.Buyers.Find(added);

            Assert.True(buyerDal.Id == 1);
            Assert.True(buyerDal.Name == buyer.Name);

            buyer.Id = buyerDal.Id;
            buyer.Name = "Hello World";

            var updated = repo.Update(buyer.Id, buyer);
            repo.Save();

            Assert.True(updated == 1);
            buyerDal = db.Buyers.Find(updated);

            Assert.True(buyerDal.Name == buyer.Name);
        }

        [Fact]
        public void BuyerRepository_GetAll_Test()
        {

            var buyer1 = new Buyer()
            {
                Name = "Hello",
            };
            var buyer2 = new Buyer()
            {
                Name = "World",
            };

            repo.Add(buyer1);
            repo.Add(buyer2);
            repo.Save();

            Assert.True(db.Buyers.Count() == 2);

            var result = repo.GetAll();
            Assert.Equal(2, result.Count);

            var entity1 = result.FirstOrDefault(e => e.Name == buyer1.Name);
            Assert.True(entity1 is not null);
            Assert.Equal(entity1.Name, buyer1.Name);

            var entity2 = result.FirstOrDefault(e => e.Name == buyer2.Name);
            Assert.True(entity2 is not null);
            Assert.Equal(entity2.Name, buyer2.Name);
        }

        [Fact]
        public void BuyerRepository_GetById_Test()
        {

            var buyer1 = new Buyer()
            {
                Name = "Hello",
            };
            var buyer2 = new Buyer()
            {
                Name = "World",
            };

            var id1 = repo.Add(buyer1);
            var id2 = repo.Add(buyer2);
            repo.Save();

            Assert.True(db.Buyers.Count() == 2);

            var result1 = repo.GetById(id1);
            Assert.True(result1 is not null);
            Assert.Equal(result1.Name, buyer1.Name);

            var result2 = repo.GetById(id2);
            Assert.True(result2 is not null);
            Assert.Equal(result2.Name, buyer2.Name);
        }

        [Fact]
        public void BuyerRepository_Delete_Test()
        {

            var buyer1 = new Buyer()
            {
                Name = "Hello",
            };
            var buyer2 = new Buyer()
            {
                Name = "World",
            };

            var id1 = repo.Add(buyer1);
            var id2 = repo.Add(buyer2);
            repo.Save();

            Assert.True(db.Buyers.Count() == 2);

            var result1 = repo.GetById(id1);
            Assert.True(result1 is not null);
            Assert.Equal(result1.Name, buyer1.Name);

            var result2 = repo.GetById(id2);
            Assert.True(result2 is not null);
            Assert.Equal(result2.Name, buyer2.Name);

            var deleteResult = repo.Delete(id1);
            repo.Save();

            Assert.True(deleteResult is not null);
            Assert.Equal(deleteResult.Name, buyer1.Name);

            Assert.True(db.Buyers.Count() == 1);
        }
    }
}
