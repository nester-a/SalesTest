using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;

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
            if (item == null) throw new ArgumentNullException("Item is null");
            var result = item.ToDAL();

            return _context.Products.Add(result).Entity.Id;
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
