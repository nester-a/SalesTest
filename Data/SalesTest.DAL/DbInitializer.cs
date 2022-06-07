namespace SalesTest.DAL
{
    public class DbInitializer
    {
        public static void Initializer(SalesTestContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}