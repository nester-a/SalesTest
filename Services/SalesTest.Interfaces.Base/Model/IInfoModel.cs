using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Model
{
    /// <summary>Model which contains all information about repositorys items</summary>
    public interface IInfoModel
    {
        /// <summary>Information about buyers</summary>
        List<string> BuyersInfo { get; set; }

        /// <summary>Information about sales</summary>
        List<string> SalesInfo { get; set; }

        /// <summary>Information about sales points</summary>
        List<string> SalesPointsInfo { get; set; }

        /// <summary>Information about products</summary>
        List<string> ProductInfo { get; set; }
    }
}
