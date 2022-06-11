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
            context.Products.AddRange(OriginData.products);
            context.SalesPoints.AddRange(OriginData.salesPoints);
            context.SaveChanges();
            Initializer(context);
        }
    }
}