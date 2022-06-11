using SalesTest.DAL.Data;
using System.Linq;

namespace SalesTest.DAL
{
    public class DbInitializer
    {
        public static void Initializer(SalesTestContext context)
        {
            context.Database.EnsureCreated();
        }
        public static void InitializeWithData(SalesTestContext context)
        {
            context.Buyers.AddRange(OriginData.buyers);
            //context.SaveChanges();
            //var one = context.Buyers.ToList();
            context.Products.AddRange(OriginData.products);
            //context.SaveChanges();
            //var two = context.Products.ToList();
            context.SalesPoints.AddRange(OriginData.salesPoints);
            //context.SaveChanges();
            //var three = context.SalesPoints.ToList();
            //context.Sales.AddRange(OriginData.sales);
            //context.SaveChanges();
            //var four = context.Sales.ToList();
            //context.SalesData.AddRange(OriginData.salesData);
            context.SaveChanges();
            //var five = context.SalesData.ToList();
            Initializer(context);
        }
    }
}