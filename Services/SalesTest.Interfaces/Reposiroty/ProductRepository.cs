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

    public int Add(Product item)
    {
        
    }

    public int Update(int id, Product updatedItem)
    {
        
    }

    public IEnumerable<Product> GetAll()
    {
        
    }

    public Product GetById(int id)
    {
        
    }

    public Product Delete(int id)
    {
        
    }

    public void Save()
    {

    }
}