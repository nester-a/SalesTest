using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Model
{
    /// <summary>Model which contains all information about repositorys items</summary>
    public interface IInfoModel
    {
        /// <summary>Information about buyers</summary>
        List<IBuyer> BuyersInfo { get; set; }

        /// <summary>Information about sales</summary>
        List<ISales> SalesInfo { get; set; }

        /// <summary>Information about sales points</summary>
        List<ISalesPoint> SalesPointsInfo { get; set; }

        /// <summary>Information about products</summary>
        List<IProduct> ProductInfo { get; set; }
    }
}
