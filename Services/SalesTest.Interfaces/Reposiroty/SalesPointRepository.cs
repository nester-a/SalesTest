using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;
using System.Linq;
using ProvidedProductDAL = SalesTest.DAL.Enities.ProvidedProduct;
using SalesTest.Domain.Base;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    public class SalesPointRepository : IRepository<SalesPoint>
    {
        SalesTestContext _context;
        public SalesPointRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(SalesPoint item)
        {
            if (item == null) throw new ArgumentNullException("Item is null");
            var result = item.ToDAL();
            
            var id = _context.SalesPoints.Add(result).Entity.Id;

            return id;
        }

        public int Update(int id, SalesPoint updatedItem)
        {
            if (updatedItem == null) throw new ArgumentNullException("Item is null");

            var exsist = _context.SalesPoints.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            exsist.Name = updatedItem.Name;
            exsist.ProvidedProducts = updatedItem.ProvidedProducts.Select(i => i.ToDAL()).ToList();

            _context.SalesPoints.Update(exsist);

            return id;
        }

        public List<SalesPoint> GetAll()
        {
            var all = _context.SalesPoints.ToList();
            return all.Select(i => i.ToDOM()).ToList();
        }

        public SalesPoint GetById(int id)
        {
            var exsist = _context.SalesPoints.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            return exsist.ToDOM();
        }

        public SalesPoint Delete(int id)
        {
            var exsist = _context.SalesPoints.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            _context.Remove(exsist);

            return exsist.ToDOM();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }

}
