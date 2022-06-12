using SalesTest.Domain;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.Interfaces.Base.Services;
using SalesTest.Interfaces.Base.UnitsOfWork;
using System.Collections.Generic;
using System.Linq;

namespace SalesTest.Interfaces.Services
{
    public class SalesService : IService<ISales>
    {
        private readonly ISalesUnitOfWork _unitOfWork;

        public SalesService(ISalesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ISales Delete(int id)
        {
            var result = _unitOfWork.Sales.Delete(id);
            _unitOfWork.Sales.Save();
            return result;
        }

        public List<ISales> GetAll()
        {
            return _unitOfWork.Sales.GetAll();
        }

        public ISales GetById(int id)
        {
            return _unitOfWork.Sales.GetById(id);
        }

        public int Update(int id, ISales updatedItem)
        {
            if (CheckBuyerSalesDataAndSalesPoint(updatedItem) == -1)
                return -1;

            var pp = updatedItem.SalesData.Select(p => new ProvidedProduct { ProductId = p.ProductId, ProductQuantity = p.ProductQuantity }).ToList<IProvidedProduct>();

            if (!_unitOfWork.ProductsExistsOnSalesPoint(updatedItem.SalesPointId, pp))
                return -1;
            var result = _unitOfWork.Sales.Update(id, updatedItem);

            _unitOfWork.Sales.Save();

            return result;
        }
        public int Add(ISales item)
        {
            if(CheckBuyerSalesDataAndSalesPoint(item) == -1)
                return -1;

            var pp = item.SalesData.Select(p => new ProvidedProduct { ProductId = p.ProductId, ProductQuantity = p.ProductQuantity }).ToList<IProvidedProduct>();

            if (!_unitOfWork.ProductsExistsOnSalesPoint(item.SalesPointId, pp))
                return -1;

            //обновили данные в таблицах
            int id = SaveInformation(item);
            return id;
        }

        /// <summary>Save information in data-base</summary>
        private int SaveInformation(ISales sales)
        {
            var salesPoint = _unitOfWork.SalesPoints.GetById(sales.SalesPointId);
            var updatedSalesPoint = ReduceStock(salesPoint, sales.SalesData);

            _unitOfWork.SalesPoints.Update(salesPoint.Id, updatedSalesPoint);
            var salesId = _unitOfWork.Sales.Add(sales);
            if (sales.BuyerId is not null)
            {
                var buyer = _unitOfWork.Buyers.GetById((int)sales.BuyerId);
                buyer.SalesIds.Add(salesId);
                _unitOfWork.Buyers.Update(buyer.Id, buyer);
            }
            _unitOfWork.Sales.Save();
            return salesId;
        }

        /// <summary>Reduce product quantity on sales point stock</summary>
        /// <param name="productsStock">Sales point with provided products</param>
        /// <param name="productsToSell">Products to sell</param>
        /// <returns>Sales point with updated stock</returns>
        private ISalesPoint ReduceStock(ISalesPoint productsStock, IEnumerable<ISalesData> productsToSell)
        {
            var result = productsStock;
            foreach (var product in productsStock.ProvidedProducts)
            {
                foreach (var item in productsToSell)
                {
                    if (product.ProductId == item.ProductId)
                    {
                        product.ProductQuantity -= item.ProductQuantity;
                    }
                }
            }
            if (productsStock.ProvidedProducts.Any(pp => pp.ProductQuantity == 0))
            {
                productsStock.ProvidedProducts.RemoveAll(pp => pp.ProductQuantity == 0);
            }
            return result;
        }

        private int CheckBuyerSalesDataAndSalesPoint(ISales item)
        {
            if (item.BuyerId is not null && !_unitOfWork.BuyerExists((int)item.BuyerId))
                return -1;

            foreach (var product in item.SalesData)
            {
                if (!_unitOfWork.ProductExists(product.ProductId))
                    return -1;
            }

            if (!_unitOfWork.SalesPointExists(item.SalesPointId))
                return -1;

            return 0;
        }
    }
}
