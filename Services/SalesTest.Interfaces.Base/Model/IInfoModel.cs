using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Model
{
    public interface IInfoModel
    {
        List<IBuyer> BuyersInfo { get; set; }
        List<ISales> SalesInfo { get; set; }
        List<ISalesPoint> SalesPointsInfo { get; set; }
        List<IProduct> ProductInfo { get; set; }
    }
}
