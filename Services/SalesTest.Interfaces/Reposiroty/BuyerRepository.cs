using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    public class BuyerRepository : IRepository<Buyer>
    {
        SalesTestContext _context;
        public BuyerRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(Buyer item)
        {
            return default;
        }

        public int Update(int id, Buyer updatedItem)
        {
            return default;
        }

        public IEnumerable<Buyer> GetAll()
        {
            return default;
        }

        public Buyer GetById(int id)
        {
            return default;
        }

        public Buyer Delete(int id)
        {
            return default;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
