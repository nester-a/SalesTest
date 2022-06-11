using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Model
{
    ///<inheritdoc cref="IInfoModel"/>
    public class InfoModel : IInfoModel
    {
        public List<IBuyer> BuyersInfo { get; set; }
        public List<ISales> SalesInfo { get; set; }
        public List<ISalesPoint> SalesPointsInfo { get; set; }
        public List<IProduct> ProductInfo { get; set; }
    }
}
