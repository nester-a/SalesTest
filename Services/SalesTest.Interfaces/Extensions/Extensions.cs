using BuyerDAL = SalesTest.DAL.Enities.Buyer;
using ProductDAL = SalesTest.DAL.Enities.Product;
using SalesPointDAL = SalesTest.DAL.Enities.SalesPoint;
using ProvidedProductDAL = SalesTest.DAL.Enities.ProvidedProduct;
using BuyerDOM = SalesTest.Domain.Buyer;
using ProductDOM = SalesTest.Domain.Product;
using SalesPointDOM = SalesTest.Domain.SalesPoint;
using ProvidedProductDOM = SalesTest.Domain.ProvidedProduct;
using System.Linq;
using SalesTest.Domain.Base;

namespace SalesTest.Interfaces.Extensions
{
    public static class Extensions
    {
        public static BuyerDAL ToDAL(this BuyerDOM item)
        {
            return new BuyerDAL()
            {
                Id = item.Id,
                Name = item.Name,

                // наполнение коллекции Sales происходит непосредственно в репозитории
            };
        }

        public static BuyerDOM ToDOM(this BuyerDAL item)
        {
            var sales = item.Sales?.Select(i => i.Id).ToList();
            var buyer = new BuyerDOM()
            {
                Id = item.Id,
                Name = item.Name,
                SalesIds = sales,
            };

            return buyer;
        }

        public static ProductDAL ToDAL(this ProductDOM item)
        {
            return new ProductDAL()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }

        public static ProductDOM ToDOM(this ProductDAL item)
        {
            return new ProductDOM()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }
        public static ProvidedProductDAL ToDAL(this ProvidedProductDOM item)
        {
            return new ProvidedProductDAL()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,

                // наполнение коллекции Sales происходит непосредственно в репозитории
            };
        }
        public static ProvidedProductDAL ToDAL(this IProvidedProduct item)
        {
            return new ProvidedProductDAL()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,

                // наполнение коллекции Sales происходит непосредственно в репозитории
            };
        }
        public static IProvidedProduct ToDOM(this ProvidedProductDAL item)
        {
            return new ProvidedProductDOM()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,
            };
        }

        public static SalesPointDAL ToDAL(this SalesPointDOM item)
        {
            return new SalesPointDAL()
            {
                Id = item.Id,
                Name = item.Name,
                ProvidedProducts = item.ProvidedProducts.Select(i => i.ToDAL()).ToList(),
            };
        }

        public static SalesPointDOM ToDOM(this SalesPointDAL item)
        {
            return new SalesPointDOM()
            {
                Id = item.Id,
                Name = item.Name,
                ProvidedProducts = item.ProvidedProducts.Select(i => i.ToDOM()).ToList(),
            };
        }
    }
}
