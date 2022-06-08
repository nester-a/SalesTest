using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;
using System.Linq;

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
            if (updatedItem == null) throw new ArgumentNullException("Item is null");

            var exsist = _context.Products.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            exsist.Name = updatedItem.Name;
            exsist.Price = updatedItem.Price;

            _context.Products.Update(exsist);

            return id;
        }

        public List<Product> GetAll()
        {
            var all = _context.Products.ToList();
            return all.Select(i => i.ToDOM()).ToList();
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
