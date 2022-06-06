using System;
using System.Collections.Generic;

namespace SalesTest.DAL.Enities
{
    public class Sales
    {
        public int Id { get; set; }

        public DateTimeOffset Date { get; } = DateTimeOffset.Now.Date;

        public DateTimeOffset Time { get; } = DateTimeOffset.Now.ToLocalTime();

        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        public ICollection<int> SalesDataId { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
