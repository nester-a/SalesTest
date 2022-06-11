using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using SalesTest.Interfaces.Base.Repository;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.UnitsOfWork
{
    /// <summary>Unit of work for sales actions</summary>
    public interface ISalesUnitOfWork
    {
        /// <summary>Buyers repository</summary>
        public IRepository<IBuyer> Buyers { get; }

        /// <summary>Products repository</summary>
        public IRepository<IProduct> Products { get; }

        /// <summary>Sales points repository</summary>
        public IRepository<ISalesPoint> SalesPoints { get; }

        /// <summary>Sales repository</summary>
        public IRepository<ISales> Sales { get; }

        /// <summary>Get all information from data-base</summary>
        /// <returns>Information model</returns>
        public IInfoModel GetAll();

        /// <summary>Check is repository has product with this id</summary>
        /// <param name="productId">Id of product</param>
        /// <returns>True if the product exsists</returns>
        public bool ProductExists(int productId);

        /// <summary>Check is repository has sales with this id</summary>
        /// <param name="salesPointId">Id of sales</param>
        /// <returns>True if the sales exsists</returns>
        public bool SalesPointExists(int salesPointId);

        /// <summary>Check is repository has buyer with this id</summary>
        /// <param name="buyerId">Id of buyer</param>
        /// <returns>True if the buyer exsists</returns>
        public bool BuyerExists(int buyerId);

        /// <summary>Check is this sales point has this provided products</summary>
        /// <param name="salesPoint">Sales point</param>
        /// <param name="products">Provided products</param>
        /// <returns>True if they exsists</returns>
        public bool ProductsExistsOnSalesPoint(ISalesPoint salesPoint, IEnumerable<IProvidedProduct> products);

        /// <summary>Check is this sales point has this provided products</summary>
        /// <param name="salesPointId">Sales point id</param>
        /// <param name="products">Provided products</param>
        /// <returns>True if they exsists</returns>
        public bool ProductsExistsOnSalesPoint(int salesPointId, IEnumerable<IProvidedProduct> products);

        /// <summary>Calculate products amount</summary>
        /// <param name="product">Product</param>
        /// <param name="productQuantity">Product quantity</param>
        /// <returns>Amount</returns>
        public decimal CalcAmount(IProduct product, int productQuantity);

        /// <summary>Calculate products amount</summary>
        /// <param name="productId">Product's id</param>
        /// <param name="productQuantity">Product quantity</param>
        /// <returns>Amount</returns>
        public decimal CalcAmount(int productId, int productQuantity);

        /// <summary>Get provided products list from sale model</summary>
        /// <param name="model">Sale model</param>
        /// <returns>List of provided products</returns>
        public List<IProvidedProduct> GetProvidedProducts(ISaleModel model);

        /// <summary>Make a sale</summary>
        /// <param name="model">Sale model</param>
        /// <param name="providedProducts">Provided products</param>
        /// <returns>New sale</returns>
        public ISales MakeASale(ISaleModel model, IEnumerable<IProvidedProduct> providedProducts);

        /// <summary>Save information in data-base</summary>
        void SaveInformation(ISales sales, ISalesPoint salesPoint, IBuyer buyer = null);
    }
}
