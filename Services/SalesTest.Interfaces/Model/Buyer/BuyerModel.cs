using System.Collections.Generic;

namespace SalesTest.Interfaces.Model.Buyer
{
    public class BuyerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> SalesIds { get; set; } = new List<int>();
    }
}
