using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using System.Collections.Generic;
using SalesTest.Interfaces.Extensions;

using BuyerDAL = SalesTest.DAL.Enities.Buyer;
using SalesDAL = SalesTest.DAL.Enities.Sales;
using BuyerDOM = SalesTest.Domain.Buyer;
using System;
using System.Linq;
using SalesTest.Domain.Base;

namespace SalesTest.SalesTest.Interfaces.Repository
{
    public class BuyerRepository : IRepository<IBuyer>
    {
        SalesTestContext _context;
        public BuyerRepository(SalesTestContext context)
        {
            _context = context;
        }

        public int Add(IBuyer item)
        {
            if (item == null) throw new ArgumentNullException("Item is null");
            var result = MapBuyerToDal(item);

            return _context.Buyers.Add(result).Entity.Id;
        }

        public int Update(int id, IBuyer updatedItem)
        {
            if (updatedItem == null) throw new ArgumentNullException("Item is null");

            var exsist = _context.Buyers.FirstOrDefault(i => i.Id == id);
            if(exsist is null) throw new ArgumentException("Item not found");

            exsist.Name = updatedItem.Name;
            exsist.Sales = GetSales(updatedItem.SalesIds);

            _context.Buyers.Update(exsist);

            return id;

        }

        public List<IBuyer> GetAll()
        {
            var all = _context.Buyers.ToList();
            return all.Select(i => i.ToDOM()).ToList();
        }

        public IBuyer GetById(int id)
        {
            var exsist = _context.Buyers.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            return exsist.ToDOM();
        }

        public IBuyer Delete(int id)
        {
            var exsist = _context.Buyers.FirstOrDefault(i => i.Id == id);
            if (exsist is null) throw new ArgumentException("Item not found");

            _context.Remove(exsist);

            return exsist.ToDOM();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private BuyerDAL MapBuyerToDal(IBuyer item)
        {
            var result = item.ToDAL();
            List<SalesDAL> sales = GetSales(item.SalesIds);

            result.Sales = sales;
            return result;
        }

        private List<SalesDAL> GetSales(List<int> ids)
        {
            List<SalesDAL> sales = new List<SalesDAL>();
            if (ids.Count == 0) return sales;
            foreach (var sale in ids)
            {
                var findedSale = _context.Sales.Find(sale);
                sales.Add(findedSale);
            }

            return sales;
        }
    }
}
