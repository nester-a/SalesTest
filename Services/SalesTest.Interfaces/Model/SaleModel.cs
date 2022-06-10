using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Model
{
    public class SaleModel : ISaleModel
    {
        //public IProduct Product { get; set; }
        //public int Quantity { get; set; }
        public int SalesPointId { get; set; }
        public IBuyer Buyer { get; set; }
        public IDictionary<int, int> ProductsToBuy { get; set; } = new Dictionary<int, int>();
    }
}
