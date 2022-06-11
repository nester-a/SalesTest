using System.Collections.Generic;

namespace SalesTest.DAL.Enities
{
    public class SalesPoint
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProvidedProduct> ProvidedProducts { get; set; } = new List<ProvidedProduct>();
    }
}
