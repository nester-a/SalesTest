using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Model
{
    /// <summary>Purchase transaction information model</summary>
    public interface ISaleModel
    {
        IDictionary<int, int> ProductsToBuy { get; set; }

        int SalesPointId { get; set; }

        int? BuyerId { get; set; }
    }
}
