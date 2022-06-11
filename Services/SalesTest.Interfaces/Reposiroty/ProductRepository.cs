using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;
using System.Linq;
using SalesTest.Domain.Base;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    ///<inheritdoc cref="IRepository<T>"/>
    public class ProductRepository : IRepository<IProduct>
    {
        SalesTestContext _context;
        public ProductRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(IProduct item)
        {
            if (item == null) throw new ArgumentNullException("Item is null");
            var result = item.ToDAL();

            return _context.Products.Add(result).Entity.Id;
        }

        public int Update(int id, IProduct updatedItem)
        {
            if (updatedItem == null) throw new ArgumentNullException("Item is null");

            var exsist = _context.Products.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            exsist.Name = updatedItem.Name;
            exsist.Price = updatedItem.Price;

            _context.Products.Update(exsist);

            return id;
        }

        public List<IProduct> GetAll()
        {
            var all = _context.Products.ToList();
            return all.Select(i => i.ToDOM()).ToList();
        }

        public IProduct GetById(int id)
        {
            var exsist = _context.Products.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            return exsist.ToDOM();
        }

        public IProduct Delete(int id)
        {
            var exsist = _context.Products.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            _context.Remove(exsist);

            return exsist.ToDOM();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            var result = _context.Products.FirstOrDefault(i => i.Id == id);
            if (result is null) return false;
            return true;
        }

        public List<string> GetAllInformation()
        {
            var all = GetAll();
            var result = new List<string>();
            foreach (var item in all)
            {
                result.Add($"Id: {item.Id}; Name: {item.Name}; Price: {item.Price}");
            }
            return result;
        }
    }

}
