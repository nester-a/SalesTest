using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    public class SalesRepository : IRepository<Sales>
    {
        SalesTestContext _context;
        public SalesRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(Sales item)
        {
            return default;
        }

        public int Update(int id, Sales updatedItem)
        {
            return default;
        }

        public List<Sales> GetAll()
        {
            return default;
        }

        public Sales GetById(int id)
        {
            return default;
        }

        public Sales Delete(int id)
        {
            return default;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
