using SalesTest.Domain.Base;
using System;
using System.Collections.Generic;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISales"/>
    public class Sales : ISales
    {
        public int Id { get; set; }

        public string Date { get; set; } = DateTime.Now.Date.ToShortDateString();

        public string Time {get; set; } = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        public List<ISalesData> SalesData { get; set; } = new List<ISalesData>();

        public decimal TotalAmount { get; set; }
        
    }
}
