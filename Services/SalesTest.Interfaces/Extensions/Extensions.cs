using BuyerDAL = SalesTest.DAL.Enities.Buyer;
using ProductDAL = SalesTest.DAL.Enities.Product;
using SalesPointDAL = SalesTest.DAL.Enities.SalesPoint;
using ProvidedProductDAL = SalesTest.DAL.Enities.ProvidedProduct;
using SalesDAL = SalesTest.DAL.Enities.Sales;
using SalesDataDAL = SalesTest.DAL.Enities.SalesData;
using BuyerDOM = SalesTest.Domain.Buyer;
using ProductDOM = SalesTest.Domain.Product;
using SalesPointDOM = SalesTest.Domain.SalesPoint;
using ProvidedProductDOM = SalesTest.Domain.ProvidedProduct;
using SalesDOM = SalesTest.Domain.Sales;
using SalesDataDOM = SalesTest.Domain.SalesData;
using System.Linq;
using System;
using SalesTest.Domain.Base;

namespace SalesTest.Interfaces.Extensions
{
    public static class Extensions
    {
        public static BuyerDAL ToDAL(this IBuyer item)
        {
            return new BuyerDAL()
            {
                Id = item.Id,
                Name = item.Name,
                // наполнение коллекции Sales происходит непосредственно в репозитории - сделано
            };
        }

        public static IBuyer ToDOM(this BuyerDAL item)
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

        public static ProductDAL ToDAL(this IProduct item)
        {
            return new ProductDAL()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }

        public static IProduct ToDOM(this ProductDAL item)
        {
            return new ProductDOM()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }

        public static ProvidedProductDAL ToDAL(this IProvidedProduct item)
        {
            return new ProvidedProductDAL()
            {
                ProductId = item.ProductId,
                ProductQuantity = item.ProductQuantity,
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

        public static SalesDAL ToDAL(this SalesDOM item)
        {
            return new SalesDAL()
            {
                Id = item.Id,
                DateTime = DateTimeOffset.Parse(item.Date + " " + item.Time),
                SalesPointId = item.SalesPointId,
                BuyerId = item.BuyerId,
                //покупателя добавляем в репозитории
                //данные покупок добавляем в репозитории
                TotalAmount = item.TotalAmount,
            };
        }

        public static SalesDOM ToDOM(this SalesDAL item)
        {
            return new SalesDOM()
            {
                Id = item.Id,
                Date = item.DateTime.Date.ToShortDateString(),
                Time = item.DateTime.Date.ToShortTimeString(),
                SalesPointId = item.SalesPointId,
                BuyerId = item.BuyerId,
                SalesData = item.SalesData.Select(i => i.ToDOM()).ToList(),
                TotalAmount = item.TotalAmount,
            };
        }

        public static SalesDataDAL ToDAL(this ISalesData item)
        {
            return new SalesDataDAL()
            {
                ProductId = item.ProductId,
                ProductIdAmount = item.ProductIdAmount,
                ProductQuantity = item.ProductQuantity,
                //всё касающееся продажи добавляем в репозитории
            };
        }

        public static ISalesData ToDOM(this SalesDataDAL item)
        {
            return new SalesDataDOM()
            {
                ProductId = item.ProductId,
                ProductIdAmount = item.ProductIdAmount,
                ProductQuantity = item.ProductQuantity,
            };
        }
    }
}
