using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTest.Interfaces.Model.SalesPoint
{
    public class CreateSalesPointModel
    {

        public string Name { get; set; }

        public List<ProvidedProductModel> ProvidedProducts { get; set; } = new List<ProvidedProductModel>();
    }
}
