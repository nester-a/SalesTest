using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="IBuyer"/>
    public class Buyer : IBuyer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> SalesIds { get; set; }
    }
}
