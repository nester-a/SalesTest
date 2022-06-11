using SalesTest.DAL;
using SalesTest.Domain;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.Interfaces.Base.UnitsOfWork;
using SalesTest.Interfaces.Model;
using SalesTest.SalesTest.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTest.Interfaces.UnitsOfWork
{
    ///<inheritdoc cref="ISalesUnitOfWork"/>
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
            return Products.Exists(productId);
        }

        public bool SalesPointExists(int salesPointId)
        {
            return SalesPoints.Exists(salesPointId);
        }

        public bool BuyerExists(int buyerId)
        {
            return Buyers.Exists(buyerId);
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

        public decimal CalcAmount(IProduct product, int productQuantity)
        {
            return product.Price * productQuantity;
        }

        public decimal CalcAmount(int productId, int productQuantity)
        {
            var p = Products.GetById(productId);
            return CalcAmount(p, productQuantity);
        }

        public List<IProvidedProduct> GetProvidedProducts(ISaleModel model)
        {
            var result =  new List<IProvidedProduct>();
            foreach (var item in model.ProductsToBuy)
            {
                result.Add(new ProvidedProduct()
                {
                    ProductId = item.Key,
                    ProductQuantity = item.Value,
                });
            }
            return result;
        }

        public ISales MakeASale(ISaleModel model, IEnumerable<IProvidedProduct> providedProducts)
        {
            var sale = new Sales()
            {
                SalesPointId = model.SalesPointId,
                BuyerId = model.BuyerId,
            };
            var salesData = new List<ISalesData>();
            foreach (var item in providedProducts)
            {
                salesData.Add(new SalesData()
                {
                    ProductId = item.ProductId,
                    ProductQuantity = item.ProductQuantity,
                    ProductIdAmount = CalcAmount(item.ProductId, item.ProductQuantity),
                });
            }
            sale.SalesData = salesData;
            sale.TotalAmount = salesData.Sum(i => i.ProductIdAmount);

            IBuyer buyer = null;
            if (model.BuyerId is not null)
                buyer = Buyers.GetById((int)model.BuyerId);
            ISalesPoint salesPoint = SalesPoints.GetById(model.SalesPointId);

            SaveInformation(sale, salesPoint, buyer);

            return sale;
        }

        public void SaveInformation(ISales sales, ISalesPoint salesPoint, IBuyer buyer = null)
        {
            SalesPoints.Update(salesPoint.Id, salesPoint);
            var salesId = Sales.Add(sales);
            buyer.SalesIds.Add(salesId);
            if (buyer is not null)
                Buyers.Update(buyer.Id, buyer);
            Sales.Save();
        }
    }
}
