namespace SalesTest.DAL
{
    public class DbInitializer{
        public DbInitializer(SalesTestContext context){
            context.Database.EnsureCreated();
        }
    }
}