using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Model
{
    ///<inheritdoc cref="IInfoModel"/>
    public class InfoModel : IInfoModel
    {
        public List<string> BuyersInfo { get; set; } = new List<string>()
        {
            "Buyers info"
        };
        public List<string> SalesInfo { get; set; } = new List<string>()
        {
            "Sales info"
        };
        public List<string> SalesPointsInfo { get; set; } = new List<string>()
        {
            "Sales Points info"
        };
        public List<string> ProductInfo { get; set; } = new List<string>()
        {
            "Products info"
        };
    }
}
