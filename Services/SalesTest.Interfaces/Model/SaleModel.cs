using SalesTest.Interfaces.Base.Model;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Model
{
    ///<inheritdoc cref="ISaleModel"/>
    public class SaleModel : ISaleModel
    {
        public int SalesPointId { get; set; }
        public int? BuyerId { get; set; }
        public IDictionary<int, int> ProductsToBuy { get; set; } = new Dictionary<int, int>();
    }
}
