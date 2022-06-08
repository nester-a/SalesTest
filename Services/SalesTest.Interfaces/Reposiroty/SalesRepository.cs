using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;

namespace SalesTest.SalesTest.Interfaces.Repository;

public class SalesRepository : IRepository<Sales>
{
    SalesTestContext _context;
    public SalesRepository(SalesTestContext context)
    {
        _context = context;
    }

    public int Add(Sales item)
    {
        
    }

    public int Update(int id, Sales updatedItem)
    {
        
    }

    public IEnumerable<Sales> GetAll()
    {
        
    }

    public Sales GetById(int id)
    {
        
    }

    public Sales Delete(int id)
    {
        
    }

    public void Save()
    {

    }
}