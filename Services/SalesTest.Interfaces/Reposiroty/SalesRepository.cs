using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;

using BuyerDAL = SalesTest.DAL.Enities.Buyer;
using SalesDAL = SalesTest.DAL.Enities.Sales;
using SalesDataDAL = SalesTest.DAL.Enities.SalesData;
using BuyerDOM = SalesTest.Domain.Buyer;
using SalesDataDOM = SalesTest.Domain.SalesData;
using System.Linq;
using SalesTest.Domain.Base;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    public class SalesRepository : IRepository<ISales>
    {
        SalesTestContext _context;
        public SalesRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(ISales item)
        {
            if (item == null) throw new ArgumentNullException("Item is null");

            var result = MapSalesToDal(item);
            result.SalesData = item.SalesData.Select(i => MapSalesDataToDal(i, item)).ToList();
            var id = _context.Sales.Add(result).Entity.Id;

            return id;
        }

        public int Update(int id, ISales updatedItem)
        {
            if (updatedItem == null) throw new ArgumentNullException("Item is null");

            var exsist = _context.Sales.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            exsist.DateTime = DateTimeOffset.Parse(updatedItem.Date + " " + updatedItem.Time);
            exsist.BuyerId = updatedItem.BuyerId;
            exsist.Buyer = _context.Buyers.FirstOrDefault(i => i.Id == updatedItem.BuyerId);
            exsist.SalesPointId = updatedItem.SalesPointId;
            exsist.SalesData = updatedItem.SalesData.Select(i => MapSalesDataToDal(i, updatedItem)).ToList();
            exsist.TotalAmount = exsist.SalesData.Sum(i => i.ProductIdAmount);

            _context.Sales.Update(exsist);

            return id;
        }

        public List<ISales> GetAll()
        {
            var all = _context.Sales.ToList();
            return all.Select(i => i.ToDOM()).ToList();
        }

        public ISales GetById(int id)
        {
            var exsist = _context.Sales.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            return exsist.ToDOM();
        }

        public ISales Delete(int id)
        {
            var exsist = _context.Sales.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            _context.Remove(exsist);

            return exsist.ToDOM();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private SalesDAL MapSalesToDal(ISales item)
        {
            var result = item.ToDAL();
            result.Buyer = _context.Buyers.FirstOrDefault(i => i.Id == item.Id);

            return result;
        }

        private SalesDataDAL MapSalesDataToDal(ISalesData salesData, ISales item)
        {
            var result = salesData.ToDAL();
            result.SalesId = item.Id;

            return result;
        }
    }
}
