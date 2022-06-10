using SalesTest.Domain;
using SalesTest.Domain.Base;
using SalesTest.SalesTest.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;

namespace TestProject.Services.ServiceTestInterfaces.Repository
{
    public class SalesRepositoryTests : BaseTest
    {
        static SalesRepository repo = new SalesRepository(db);
        [Fact]
        public void SalesRepository_Add_Test()
        {
            var list = new List<ISalesData>()
            {
                new SalesData()
                {
                    ProductId = 1,
                    ProductIdAmount = 1,
                    ProductQuantity = 1,
                },
                new SalesData()
                {
                    ProductId = 2,
                    ProductIdAmount = 2,
                    ProductQuantity = 2,
                },
            };

            Sales sales = new Sales()
            {
                SalesPointId = 1,
                SalesData = list,
                TotalAmount = list.Select(i => i.ProductIdAmount).Sum(),
            };

            var result = repo.Add(sales);
            repo.Save();

            Assert.True(result == 1);
            Assert.True(db.Sales.Find(result).SalesPointId == sales.SalesPointId);
            Assert.True(db.Sales.Find(result).DateTime == DateTimeOffset.Parse(sales.Date + " " + sales.Time));
            Assert.True(db.Sales.Find(result).Buyer is null);
            Assert.True(db.Sales.Find(result).BuyerId is null);
            Assert.True(db.Sales.Find(result).SalesData.Count == 2);
            Assert.True(db.SalesData.ToList().Count == 2);

            var sd = db.SalesData.ToList();
            foreach (var item in sd)
            {
                Assert.True(item.Sales is not null);
                Assert.True(item.SalesId == 1);
            }
        }
        [Fact]
        public void SalesRepository_Update_Test()
        {
            var list = new List<ISalesData>()
            {
                new SalesData()
                {
                    ProductId = 1,
                    ProductIdAmount = 1,
                    ProductQuantity = 1,
                },
                new SalesData()
                {
                    ProductId = 2,
                    ProductIdAmount = 2,
                    ProductQuantity = 2,
                },
            };

            Sales sales = new Sales()
            {
                SalesPointId = 1,
                SalesData = list,
                TotalAmount = list.Select(i => i.ProductIdAmount).Sum(),
            };

            var result = repo.Add(sales);
            repo.Save();

            Assert.True(result == 1);
            Assert.True(db.Sales.Find(result).SalesPointId == sales.SalesPointId);
            Assert.True(db.Sales.Find(result).DateTime == DateTimeOffset.Parse(sales.Date + " " + sales.Time));
            Assert.True(db.Sales.Find(result).Buyer is null);
            Assert.True(db.Sales.Find(result).BuyerId is null);
            Assert.True(db.Sales.Find(result).SalesData.Count == 2);
            Assert.True(db.SalesData.ToList().Count == 2);

            var sd = db.SalesData.ToList();
            foreach (var item in sd)
            {
                Assert.True(item.Sales is not null);
                Assert.True(item.SalesId == 1);
            }

            var salesDal = db.Sales.Find(result);

            Assert.True(salesDal.Id == 1); 
            Assert.True(salesDal.SalesPointId == sales.SalesPointId);
            Assert.True(salesDal.DateTime == DateTimeOffset.Parse(sales.Date + " " + sales.Time));
            Assert.True(salesDal.Buyer is null);
            Assert.True(salesDal.BuyerId is null);
            Assert.True(salesDal.SalesData.Count == 2);

            sales.Id = salesDal.Id;
            sales.SalesData.Add(new SalesData()
            {
                ProductId = 3,
                ProductIdAmount = 3,
                ProductQuantity = 3,
            });

            var updated = repo.Update(sales.Id, sales);
            repo.Save();

            Assert.True(updated == 1);
            Assert.True(db.Sales.Find(result).SalesPointId == sales.SalesPointId);
            Assert.True(db.Sales.Find(result).DateTime == DateTimeOffset.Parse(sales.Date + " " + sales.Time));
            Assert.True(db.Sales.Find(result).Buyer is null);
            Assert.True(db.Sales.Find(result).BuyerId is null);
            Assert.True(db.Sales.Find(result).SalesData.Count == 3);
            Assert.True(db.SalesData.ToList().Count == 3);

            sd = db.SalesData.ToList();
            foreach (var item in sd)
            {
                Assert.True(item.Sales is not null);
                Assert.True(item.SalesId == 1);
            }
        }

        [Fact]
        public void SalesRepository_GetAll_Test()
        {
            var list = new List<ISalesData>()
            {
                new SalesData()
                {
                    ProductId = 1,
                    ProductIdAmount = 1,
                    ProductQuantity = 1,
                },
                new SalesData()
                {
                    ProductId = 2,
                    ProductIdAmount = 2,
                    ProductQuantity = 2,
                },
            };

            Sales sales1 = new Sales()
            {
                SalesPointId = 1,
                SalesData = list,
                TotalAmount = list.Select(i => i.ProductIdAmount).Sum(),
            };
            Sales sales2 = new Sales()
            {
                SalesPointId = 2,
                SalesData = list,
                TotalAmount = list.Select(i => i.ProductIdAmount).Sum(),
            };

            var result1 = repo.Add(sales1);
            var result2 = repo.Add(sales2);
            repo.Save();

            Assert.True(result1 == 1);
            Assert.True(db.Sales.Find(result1).SalesPointId == sales1.SalesPointId);
            Assert.True(db.Sales.Find(result1).DateTime == DateTimeOffset.Parse(sales1.Date + " " + sales1.Time));
            Assert.True(db.Sales.Find(result1).Buyer is null);
            Assert.True(db.Sales.Find(result1).BuyerId is null);
            Assert.True(db.Sales.Find(result1).SalesData.Count == 2);
            Assert.True(result2 == 2);
            Assert.True(db.Sales.Find(result2).SalesPointId == sales2.SalesPointId);
            Assert.True(db.Sales.Find(result2).DateTime == DateTimeOffset.Parse(sales2.Date + " " + sales2.Time));
            Assert.True(db.Sales.Find(result2).Buyer is null);
            Assert.True(db.Sales.Find(result2).BuyerId is null);
            Assert.True(db.Sales.Find(result2).SalesData.Count == 2);
            Assert.True(db.SalesData.ToList().Count == 4);

            var sd = repo.GetAll();
            foreach (var item in sd)
            {
                Assert.True(item is not null);
                if(item.Id == 1)
                {
                    Assert.True(item.SalesPointId == sales1.SalesPointId);
                    Assert.True(item.Date == sales1.Date);
                    Assert.True(item.Time == sales1.Time);
                    Assert.True(item.BuyerId is null);
                    Assert.True(item.SalesData.Count == 2);
                }
                else
                {
                    Assert.True(item.Id == 2);
                    Assert.True(item.SalesPointId == sales2.SalesPointId);
                    Assert.True(item.Date == sales2.Date);
                    Assert.True(item.Time == sales2.Time);
                    Assert.True(item.BuyerId is null);
                    Assert.True(item.SalesData.Count == 2);
                }
            }
        }
    }
}
