using SalesTest.DAL.Enities;
using System.Collections.Generic;

namespace SalesTest.DAL.Data
{
    public static class OriginData
    {
        public static List<Buyer> buyers { get; } = new List<Buyer>()
        {
            new Buyer()
            {
                Id = 1,
                Name = "Остап",

            },
            new Buyer()
            {
                Id = 2,
                Name = "Иполит Матвеевич"
            },
        };

        public static List<Product> products { get; } = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Стул",
                Price = 12,
            },
            new Product()
            {
                Id = 2,
                Name = "Рога",
                Price = 2,
            },
            new Product()
            {
                Id = 3,
                Name = "Копыта",
                Price = 3,
            },
        };

        public static List<SalesPoint> salesPoints { get; } = new List<SalesPoint>()
        {
            new SalesPoint()
            {
                Id = 1,
                Name = "Москва",
                ProvidedProducts = new List<ProvidedProduct>()
                {
                    new ProvidedProduct()
                    {
                        ProductId = 1,
                        ProductQuantity = 1,
                        SalesPointId = 1,
                    }
                }
            },
            new SalesPoint()
            {
                Id = 2,
                Name = "Одесса",
                ProvidedProducts= new List<ProvidedProduct>()
                {
                    new ProvidedProduct()
                    {
                        ProductId = 2,
                        ProductQuantity = 2,
                        SalesPointId = 2,
                    },
                    new ProvidedProduct()
                    {
                        ProductId = 3,
                        ProductQuantity = 3,
                        SalesPointId = 2,
                    },
                },
            },
            new SalesPoint()
            {
                Id = 3,
                Name = "Кисловодск",
                ProvidedProducts = new List<ProvidedProduct>()
                {
                    new ProvidedProduct()
                    {
                        ProductId = 1,
                        ProductQuantity = 5,
                        SalesPointId = 3,
                    },
                },
            },
        };

        public static List<ProvidedProduct> pp { get; } = new List<ProvidedProduct>()
        {
            new ProvidedProduct()
            {
                ProductId = 1,
                ProductQuantity = 5,
                SalesPointId = 3,
            },
            new ProvidedProduct()
            {
                ProductId = 2,
                ProductQuantity = 2,
                SalesPointId = 2,
            },
            new ProvidedProduct()
            {
                ProductId = 3,
                ProductQuantity = 3,
                SalesPointId = 2,
            },
            new ProvidedProduct()
            {
                ProductId = 1,
                ProductQuantity = 1,
                SalesPointId = 1,
            },
        };



        //public static List<Sales> sales = new List<Sales>()
        //{
        //    new Sales()
        //    {
        //        Id = 1,
        //        SalesPointId = 1,
        //        BuyerId = 1,
        //        SalesData = salesData,
        //        TotalAmount = 12,
        //    },
        //};
        //public static List<SalesData> salesData = new List<SalesData>()
        //{
        //    new SalesData()
        //    {
        //        ProductId = 1,
        //        ProductQuantity = 1,
        //        ProductIdAmount = 12,
        //        SalesId = 1,
        //    },
        //};

    }
}
