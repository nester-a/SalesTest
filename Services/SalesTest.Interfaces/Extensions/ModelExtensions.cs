using SalesTest.Domain;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Model.Buyer;
using SalesTest.Interfaces.Model.Product;
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

    }
}
