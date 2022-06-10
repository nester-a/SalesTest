using SalesTest.DAL;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.Interfaces.Base.UnitsOfWork;
using SalesTest.Interfaces.Model;
using SalesTest.SalesTest.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace SalesTest.Interfaces.UnitsOfWork
{
    public class SalesUnitOfWork : ISalesUnitOfWork, IDisposable
    {
        SalesTestContext _context;
        BuyerRepository _buyers;
        ProductRepository _products;
        SalesPointRepository _salesPoints;
        SalesRepository _sales;
        bool disposed = false;
        public IRepository<IBuyer> Buyers
        {
            get
            {
                if (_buyers == null) _buyers = new BuyerRepository(_context);
                return _buyers;
            }
        }
        public IRepository<IProduct> Products
        {
            get
            {
                if (_products == null) _products = new ProductRepository(_context);
                return _products;
            }
        }
        public IRepository<ISalesPoint> SalesPoints
        {
            get
            {
                if (_salesPoints == null) _salesPoints = new SalesPointRepository(_context);
                return _salesPoints;
            }
        }
        public IRepository<ISales> Sales
        {
            get
            {
                if (_sales == null) _sales = new SalesRepository(_context);
                return _sales;
            }
        }

        public SalesUnitOfWork(SalesTestContext context)
        {
            _context = context;
        }

        public IInfoModel GetAll()
        {
            return new InfoModel()
            {
                BuyersInfo = Buyers.GetAll(),
                SalesInfo = Sales.GetAll(),
                SalesPointsInfo = SalesPoints.GetAll(),
                ProductInfo = Products.GetAll(),
            };
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool ProductExists(int productId)
        {
            try
            {
                Products.GetById(productId);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool SalesPointExists(int salesPointId)
        {
            try
            {
                SalesPoints.GetById(salesPointId);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool BuyerExists(int buyerId)
        {
            try
            {
                Buyers.GetById(buyerId);
            }
            catch
            {
                return false;
            }

            return true;
        }


        public bool ProductsExistsOnSalesPoint(ISalesPoint salesPoint, IEnumerable<IProvidedProduct> products)
        {
            foreach (var item in products)
            {
                var onStock = salesPoint.ProvidedProducts.Contains(item);
                if(!onStock) return false;
            }
            return true;
        }

        public bool ProductsExistsOnSalesPoint(int salesPointId, IEnumerable<IProvidedProduct> products)
        {
            var sp = SalesPoints.GetById(salesPointId);
            return ProductsExistsOnSalesPoint(sp, products);
        }

        public decimal CountAmount(IProduct product, int productQuantity)
        {
            return product.Price * productQuantity;
        }

        public decimal CountAmount(int productId, int productQuantity)
        {
            var p = Products.GetById(productId);
            return CountAmount(p, productQuantity);
        }
    }
}
