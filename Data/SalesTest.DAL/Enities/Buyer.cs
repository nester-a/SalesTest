using System.Collections.Generic;

namespace SalesTest.DAL.Enities
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> SalesIds { get; set; }
    }
}
