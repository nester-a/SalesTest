using System;
using System.Collections.Generic;

namespace SalesTest.DAL.Enities
{
    public class Sales
    {
        public int Id { get; set; }

        public DateTimeOffset DateTime { get; } = DateTimeOffset.Now;

        public int SalesPointId { get; set; }

        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }

        public List<SalesData> SalesData { get; set; } = new List<SalesData>();

        public decimal TotalAmount { get; set; }
    }
}
