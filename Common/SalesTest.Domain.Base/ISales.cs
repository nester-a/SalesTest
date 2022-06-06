using System;
using System.Collections.Generic;

namespace SalesTest.Domain.Base
{
    /// <summary>Act of sale</summary>
    public interface ISales : IEntity
    {
        /// <summary>Date of sale</summary>
        DateTimeOffset Date { get; }

        /// <summary>Time of sale</summary>
        DateTimeOffset Time { get; }

        /// <summary>Sales Point Id</summary>
        public int SalesPointId { get; set; }

        /// <summary>Buyer Id</summary>
        public int? BuyerId { get; set; }

        /// <summary>Sales Data</summary>
        List<ISalesData> SalesData { get; set; }

        /// <summary>The total amount of the entire sale</summary>
        public decimal TotalAmount { get; set; }
    }
}
