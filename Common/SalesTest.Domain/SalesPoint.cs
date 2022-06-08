using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISalesPoint"/>
    public class SalesPoint : ISalesPoint
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<IProvidedProduct> ProvidedProducts { get; set; }
    }
}
