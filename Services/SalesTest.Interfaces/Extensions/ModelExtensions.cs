using SalesTest.Domain;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Model.Buyer;
using SalesTest.Interfaces.Model.Product;

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
    }
}
