using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;

namespace SalesTest.SalesTest.Interfaces.Repository;

public class ProductRepository : IRepository<Product>
{
    SalesTestContext _context;
    public ProductRepository(SalesTestContext context)
    {
        _context = context;
    }
}