using System.Collections.Generic;

namespace SalesTest.DAL.Enities
{
    public class SalesPoint
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
