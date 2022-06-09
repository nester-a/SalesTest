using SalesTest.Interfaces.Base.Repository;
using SalesTest.DAL;
using SalesTest.Domain;
using System.Collections.Generic;
using System;
using SalesTest.Interfaces.Extensions;
using System.Linq;
using SalesTest.Domain.Base;

namespace SalesTest.Interfaces.Reposiroty
{
    public class ProvidedProductRepository : IRepository<ProvidedProduct>
    {
        SalesTestContext _context;
        public ProvidedProductRepository(SalesTestContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Product Id of adde item</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int Add(ProvidedProduct item)
        {
            if (item == null) throw new ArgumentNullException("Item is null");
            var result = item.ToDAL();

            return _context.ProvidedProducts.Add(result).Entity.ProductId;
        }

        public ProvidedProduct Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProvidedProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProvidedProduct GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public int Update(int id, ProvidedProduct updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
