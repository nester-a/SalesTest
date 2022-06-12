using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;
using System.Linq;
using SalesTest.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    ///<inheritdoc cref="IRepository<T>"/>
    public class SalesPointRepository : IRepository<ISalesPoint>
    {
        SalesTestContext _context;
        public SalesPointRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(ISalesPoint item)
        {
            if (item == null) throw new ArgumentNullException("Item is null");
            var result = item.ToDAL();
            
            var id = _context.SalesPoints.Add(result).Entity.Id;

            return id;
        }

        public int Update(int id, ISalesPoint updatedItem)
        {
            if (updatedItem == null) throw new ArgumentNullException("Item is null");

            var exsist = _context.SalesPoints.Include(i => i.ProvidedProducts).FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            exsist.Name = updatedItem.Name;
            exsist.ProvidedProducts = updatedItem.ProvidedProducts.Select(i => i.ToDAL()).ToList();

            _context.SalesPoints.Update(exsist);

            return id;
        }

        public List<ISalesPoint> GetAll()
        {
            var all = _context.SalesPoints.Include(i => i.ProvidedProducts).ToList();
            return all.Select(i => i.ToDOM()).ToList();
        }

        public ISalesPoint GetById(int id)
        {
            var exsist = _context.SalesPoints.Include(i => i.ProvidedProducts).FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            return exsist.ToDOM();
        }

        public ISalesPoint Delete(int id)
        {
            var exsist = _context.SalesPoints.Include(i => i.ProvidedProducts).FirstOrDefault(i => i.Id == id);
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
            var result = _context.SalesPoints.FirstOrDefault(i => i.Id == id);
            if (result is null) return false;
            return true;
        }

        public List<string> GetAllInformation()
        {
            var all = GetAll();
            var result = new List<string>();
            foreach (var item in all)
            {
                result.Add($"Id: {item.Id}; Name: {item.Name};");
                if (item.ProvidedProducts.Count > 0)
                {
                    result.Add($"Provided products:");
                    foreach (var product in item.ProvidedProducts)
                    {
                        result.Add($"Product Id: {product.ProductId}; Product quantity: {product.ProductQuantity};");
                    }
                }
                else result.Add($"No provided products");
            }
            return result;
        }
    }

}
