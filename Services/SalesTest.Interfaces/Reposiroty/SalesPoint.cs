using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;

namespace SalesTest.SalesTest.Interfaces.Repository;

public class SalesPointRepository : IRepository<SalesPoint>
{
    SalesTestContext _context;
    public SalesPointRepository(SalesTestContext context)
    {
        _context = context;
    }

    public int Add(SalesPoint item)
    {
        
    }

    public int Update(int id, SalesPoint updatedItem)
    {
        
    }

    public IEnumerable<SalesPoint> GetAll()
    {
        
    }

    public SalesPoint GetById(int id)
    {
        
    }

    public SalesPoint Delete(int id)
    {
        
    }

    public void Save()
    {

    }
}