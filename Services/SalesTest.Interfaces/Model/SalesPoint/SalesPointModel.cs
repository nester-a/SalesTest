using System.Collections.Generic;

namespace SalesTest.Interfaces.Model.SalesPoint
{
    public class SalesPointModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProvidedProductModel> ProvidedProducts { get; set; } = new List<ProvidedProductModel>();
    }
}
