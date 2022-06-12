using SalesTest.Domain;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Model.Buyer;
using SalesTest.Interfaces.Model.Product;
using SalesTest.Interfaces.Model.Sales;
using SalesTest.Interfaces.Model.SalesPoint;
using System.Linq;

namespace SalesTest.Interfaces.Extensions
{
    public static class ModelExtensions
    {
        public static ProductModel ToModel(this IProduct item)
        {
            return new ProductModel()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }
        public static IProduct ToDomian(this ProductModel item)
        {
            return new Product()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }
        public static IProduct ToDomain(this CreateProductModel item)
        {
            return new Product()
            {
                Name = item.Name,
                Price = item.Price,
            };
        }

        public static BuyerModel ToModel(this IBuyer item)
        {
            return new BuyerModel()
            {
                Id = item.Id,
                Name = item.Name,
                SalesIds = item.SalesIds,
            };
        }
        public static IBuyer ToDomain(this BuyerModel item)
        {
            return new Buyer()
            {
                Id = item.Id,
                Name = item.Name,
                SalesIds = item.SalesIds,
            };
        }
        public static IBuyer ToDomain(this CreateBuyerModel item)
        {
            return new Buyer()
            {
                Name = item.Name,
            };
        }

        public static ProvidedProductModel ToModel(this IProvidedProduct item)
        {
            return new ProvidedProductModel()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,
            };
        }
        public static IProvidedProduct ToDomain(this ProvidedProductModel item)
        {
            return new ProvidedProduct()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,
            };
        }
        public static SalesPointModel ToModel(this ISalesPoint item)
        {
            return new SalesPointModel()
            {
                Id = item.Id,
                Name = item.Name,
                ProvidedProducts = item.ProvidedProducts.Select(p => p.ToModel()).ToList(),
            };
        }
        public static ISalesPoint ToDomain(this SalesPointModel item)
        {
            return new SalesPoint()
            {
                Id = item.Id,
                Name = item.Name,
                ProvidedProducts = item.ProvidedProducts.Select(p => p.ToDomain()).ToList(),
            };
        }
        public static ISalesPoint ToDomain(this CreateSalesPointModel item)
        {
            return new SalesPoint()
            {
                Name = item.Name,
                ProvidedProducts = item.ProvidedProducts.Select(p => p.ToDomain()).ToList(),
            };
        }

        public static SalesDataModel ToModel(this ISalesData item)
        {
            return new SalesDataModel()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,
                ProductIdAmount = item.ProductIdAmount,
            };
        }
        public static ISalesData ToDomain(this SalesDataModel item)
        {
            return new SalesData()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,
                ProductIdAmount = item.ProductIdAmount,
            };
        }
        public static SalesModel ToModel(this ISales item)
        {
            return new SalesModel()
            {
                Id = item.Id,
                Date = item.Date,
                Time = item.Time,
                SalesPointId = item.SalesPointId,
                BuyerId = item.BuyerId,
                SalesData = item.SalesData.Select(p => p.ToModel()).ToList(),
                TotalAmount = item.SalesData.Sum(p => p.ProductIdAmount),
            };
        }
        public static ISales ToDomain(this SalesModel item)
        {
            return new Sales()
            {
                Id = item.Id,
                Date = item.Date,
                Time = item.Time,
                SalesPointId = item.SalesPointId,
                BuyerId = item.BuyerId,
                SalesData = item.SalesData.Select(p => p.ToDomain()).ToList(),
                TotalAmount = item.SalesData.Sum(p => p.ProductIdAmount),
            };
        }
        public static ISales ToDomain(this CreateSalesModel item)
        {
            return new Sales()
            {
                SalesPointId = item.SalesPointId,
                BuyerId = item.BuyerId,
                SalesData = item.SalesData.Select(p => p.ToDomain()).ToList(),
                TotalAmount = item.SalesData.Sum(p => p.ProductIdAmount),
            };
        }

    }
}
