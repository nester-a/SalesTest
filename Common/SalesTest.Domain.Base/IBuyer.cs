using System.Collections.Generic;

namespace SalesTest.Domain.Base
{
    /// <summary>Buyer</summary>
    public interface IBuyer : INamedEntity
    {
        /// <summary>Collection of all buyer purchases</summary>
        List<int> SalesIds { get; set; }
    }
}
