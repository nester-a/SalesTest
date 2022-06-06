using Microsoft.EntityFrameworkCore;

namespace SalesTest.DAL
{
    public class SalesTestContext : DbContext
    {
        public SalesTestContext(DbContextOptions<SalesTestContext> options) : base(options)
        {

        }

        // TODO DBSets
    }
}
