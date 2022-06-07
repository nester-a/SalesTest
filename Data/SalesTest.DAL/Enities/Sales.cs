using System;
using System.Collections.Generic;

namespace SalesTest.DAL.Enities
{
    public class Sales
    {
        public int Id { get; set; }

        public DateTimeOffset DateTime { get; } = DateTimeOffset.Now;

        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        //public IEnumerable<int> SalesDataId { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
