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
    public class SalesRepository : IRepository<Sales>
    {
        SalesTestContext _context;
        public SalesRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(Sales item)
        {
            if (item == null) throw new ArgumentNullException("Item is null");


            //var list = item.SalesData.Select(i => MapSalesDataToDal(i, item)).ToList();



            var result = MapSalesToDal(item);
            result.SalesData = item.SalesData.Select(i => MapSalesDataToDal(i, item)).ToList();
            var id = _context.Sales.Add(result).Entity.Id;

            //_context.SaveChanges();
            //var res = _context.Sales.FirstOrDefault(i => i.Id == id);
            //var sd = _context.SalesData.ToList();


            return id;
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

        private SalesDAL MapSalesToDal(Sales item)
        {
            var result = item.ToDAL();
            result.Buyer = _context.Buyers.FirstOrDefault(i => i.Id == item.Id);

            return result;
        }

        private SalesDataDAL MapSalesDataToDal(ISalesData salesData, Sales item)
        {
            var result = salesData.ToDAL();
            result.SalesId = item.Id;

            return result;
        }
    }
}
