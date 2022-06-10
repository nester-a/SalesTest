using SalesTest.Domain;
using SalesTest.SalesTest.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject.Services.ServiceTestInterfaces.Repository
{
    public class SalesPointRepositoryTests : BaseTest
    {
        static SalesPointRepository repo = new SalesPointRepository(db);

        [Fact]
        public void SalesPointRepository_Add_Test()
        {

            var salesPoint = new SalesPoint()
            {
                Name = "Hello",
            };
            var list = new List<ProvidedProduct>()
            {
                new ProvidedProduct()
                {
                    ProductId = 1,
                    ProductQuantity = 1,
                },
                new ProvidedProduct()
                {
                    ProductId = 2,
                    ProductQuantity = 2,
                },
            };
            
            salesPoint.ProvidedProducts.AddRange(list);

            var result = repo.Add(salesPoint);
            repo.Save();
            var find = db.SalesPoints.Find(result);
            Assert.True(result == 1);
            Assert.True(find.Name == salesPoint.Name);
            Assert.True(find.ProvidedProducts.Count == 2);

            Assert.True(db.ProvidedProducts.Count() == 2);
            var pp = db.ProvidedProducts.ToList();

            foreach (var item in pp)
            {
                Assert.True(item.SalesPointId == find.Id);
                Assert.True(item.SalesPoint is not null);
                Assert.Equal(find, item.SalesPoint);
            }

        }

        [Fact]
        public void SalesPointRepository_Update_Test()
        {
            var salesPoint = new SalesPoint()
            {
                Name = "Hello",
            };
            var list = new List<ProvidedProduct>()
            {
                new ProvidedProduct()
                {
                    ProductId = 1,
                    ProductQuantity = 1,
                },
                new ProvidedProduct()
                {
                    ProductId = 2,
                    ProductQuantity = 2,
                },
            };

            salesPoint.ProvidedProducts.AddRange(list);

            var added = repo.Add(salesPoint);
            repo.Save();

            Assert.True(added == 1);
            var salesPointDal = db.SalesPoints.Find(added);

            Assert.True(salesPointDal.Id == 1);
            Assert.True(salesPointDal.Name == salesPoint.Name);

            salesPoint.Id = salesPointDal.Id;
            salesPoint.Name = "Hello World";
            salesPoint.ProvidedProducts.Add(new ProvidedProduct()
            {
                ProductId = 3,
                ProductQuantity = 3,
            });

            var updated = repo.Update(salesPoint.Id, salesPoint);
            repo.Save();

            Assert.True(updated == 1);
            salesPointDal = db.SalesPoints.Find(updated);

            Assert.True(salesPointDal.Name == salesPoint.Name);
            Assert.True(salesPointDal.ProvidedProducts.Count == 3);

            Assert.True(db.ProvidedProducts.Count() == 3);
            var pp = db.ProvidedProducts.ToList();

            foreach (var item in pp)
            {
                Assert.True(item.SalesPointId == salesPointDal.Id);
                Assert.True(item.SalesPoint is not null);
                Assert.Equal(salesPointDal, item.SalesPoint);
            }
        }

        [Fact]
        public void SalesPointRepository_GetAll_Test()
        {

            var salesPoint1 = new SalesPoint()
            {
                Name = "Hello",

            };
            var salesPoint2 = new SalesPoint()
            {
                Name = "World",
            };
            var list = new List<ProvidedProduct>()
            {
                new ProvidedProduct()
                {
                    ProductId = 1,
                    ProductQuantity = 1,
                },
                new ProvidedProduct()
                {
                    ProductId = 2,
                    ProductQuantity = 2,
                },
            };
            salesPoint1.ProvidedProducts.AddRange(list);
            salesPoint2.ProvidedProducts.AddRange(list);

            repo.Add(salesPoint1);
            repo.Add(salesPoint2);
            repo.Save();

            Assert.True(db.SalesPoints.Count() == 2);

            var result = repo.GetAll();
            Assert.Equal(2, result.Count);

            var entity1 = result.FirstOrDefault(e => e.Name == salesPoint1.Name);
            Assert.True(entity1 is not null);
            Assert.Equal(entity1.Name, salesPoint1.Name);
            Assert.True(entity1.ProvidedProducts.Count == 2);

            var entity2 = result.FirstOrDefault(e => e.Name == salesPoint2.Name);
            Assert.True(entity2 is not null);
            Assert.Equal(entity2.Name, salesPoint2.Name);
            Assert.True(entity2.ProvidedProducts.Count == 2);

            var pp = db.ProvidedProducts.ToList();

            foreach (var item in pp)
            {
                if(item.SalesPointId == 1)
                {
                    Assert.True(item.SalesPointId == entity1.Id);
                    Assert.True(item.SalesPoint is not null);
                }
                else
                {
                    Assert.True(item.SalesPointId == 2);
                    Assert.True(item.SalesPointId == entity2.Id);
                    Assert.True(item.SalesPoint is not null);
                }
            }
        }

        [Fact]
        public void SalesPointRepository_GetById_Test()
        {
            var salesPoint1 = new SalesPoint()
            {
                Name = "Hello",

            };
            var salesPoint2 = new SalesPoint()
            {
                Name = "World",
            };

            var id1 = repo.Add(salesPoint1);
            var id2 = repo.Add(salesPoint2);
            repo.Save();

            Assert.True(db.SalesPoints.Count() == 2);

            var result1 = repo.GetById(id1);
            Assert.True(result1 is not null);
            Assert.Equal(result1.Name, salesPoint1.Name);

            var result2 = repo.GetById(id2);
            Assert.True(result2 is not null);
            Assert.Equal(result2.Name, salesPoint2.Name);
        }

        [Fact]
        public void SalesPointRepository_Delete_Test()
        {
            var salesPoint1 = new SalesPoint()
            {
                Name = "Hello",

            };
            var salesPoint2 = new SalesPoint()
            {
                Name = "World",
            };

            var id1 = repo.Add(salesPoint1);
            var id2 = repo.Add(salesPoint2);
            repo.Save();

            Assert.True(db.SalesPoints.Count() == 2);

            var result1 = repo.GetById(id1);
            Assert.True(result1 is not null);
            Assert.Equal(result1.Name, salesPoint1.Name);

            var result2 = repo.GetById(id2);
            Assert.True(result2 is not null);
            Assert.Equal(result2.Name, salesPoint2.Name);

            var deleteResult = repo.Delete(id1);
            repo.Save();

            Assert.True(deleteResult is not null);
            Assert.Equal(deleteResult.Name, salesPoint1.Name);

            Assert.True(db.SalesPoints.Count() == 1);
        }
    }
}
