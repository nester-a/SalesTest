using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTest.DAL.Enities
{
    public class SalesPoint
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> ProvidedProductsIds { get; set; }
    }
}
