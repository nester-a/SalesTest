using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;

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

            return _context.SalesPoints.Add(result).Entity.Id;
        }

        public int Update(int id, SalesPoint updatedItem)
        {
            return default;
        }

        public List<SalesPoint> GetAll()
        {
            return default;
        }

        public SalesPoint GetById(int id)
        {
            return default;
        }

        public SalesPoint Delete(int id)
        {
            return default;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
