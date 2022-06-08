using System.Collections.Generic;

namespace SalesTest.DAL.Enities
{
    public class Buyer
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public ICollection<Sales> Sales { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Sales> Sales { get; set; } = new List<Sales>();
    }
}
