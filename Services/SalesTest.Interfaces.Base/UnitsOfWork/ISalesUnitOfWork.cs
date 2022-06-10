using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using SalesTest.Interfaces.Base.Repository;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.UnitsOfWork
{
    public interface ISalesUnitOfWork
    {
        public IRepository<IBuyer> Buyers { get; }
        public IRepository<IProduct> Products { get; }
        public IRepository<ISalesPoint> SalesPoints { get; }
        public IRepository<ISales> Sales { get; }

        public IInfoModel GetAll();

        public bool ProductExists(int productId);
        public bool SalesPointExists(int salesPointId);
        public bool BuyerExists(int buyerId);

        public bool ProductsExistsOnSalesPoint(ISalesPoint salesPoint, IEnumerable<IProvidedProduct> products);
        public bool ProductsExistsOnSalesPoint(int salesPointId, IEnumerable<IProvidedProduct> products);
        public decimal CountAmount(IProduct product, int productQuantity);
        public decimal CountAmount(int productId, int productQuantity);
    }
}
