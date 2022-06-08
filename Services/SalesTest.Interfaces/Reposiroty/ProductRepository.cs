using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        SalesTestContext _context;
        public ProductRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(Product item)
        {
            return default;
        }

        public int Update(int id, Product updatedItem)
        {
            return default;
        }

        public List<Product> GetAll()
        {
            return default;
        }

        public Product GetById(int id)
        {
            return default;
        }

        public Product Delete(int id)
        {
            return default;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
