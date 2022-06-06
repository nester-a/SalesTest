using System.Collections.Generic;

namespace SalesTest.Domain.Base
{
    /// <summary>Sales Point</summary>
    public interface ISalesPoint : INamedEntity
    {
        /// <summary>Provided Products</summary>
        List<IProvidedProduct> ProvidedProducts { get; set; }
    }
}
