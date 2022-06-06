using SalesTest.Domain.Base;
using System;
using System.Collections.Generic;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISales"/>
    public class Sales : ISales
    {
        public int Id { get; set; }

        public DateTimeOffset Date { get; } = DateTimeOffset.Now.Date;

        public DateTimeOffset Time {get; } = DateTimeOffset.Now.ToLocalTime();

        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        public List<ISalesData> SalesData { get; set; } = new List<ISalesData>();

        public decimal TotalAmount { get; set; }
        
    }
}
