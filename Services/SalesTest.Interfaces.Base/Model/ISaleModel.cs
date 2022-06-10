using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Model
{
    public interface ISaleModel
    {
        IDictionary<int, int> ProductsToBuy { get; set; }
        //IProduct Product { get; set; }
        //int Quantity { get; set; }

        int SalesPointId { get; set; }

        IBuyer Buyer { get; set; }
    }
}
