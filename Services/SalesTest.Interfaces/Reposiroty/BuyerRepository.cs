using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;

namespace SalesTest.SalesTest.Interfaces.Repository;

public class BuyerRepository : IRepository<Buyer>
{
    SalesTestContext _context;
    public BuyerRepository(SalesTestContext context)
    {
        _context = context;
    }

    public int Add(Buyer item)
    {
        
    }

    public int Update(int id, Buyer updatedItem)
    {
        
    }

    public IEnumerable<Buyer> GetAll()
    {
        
    }

    public Buyer GetById(int id)
    {
        
    }

    public Buyer Delete(int id)
    {
        
    }

    public void Save()
    {

    }
}