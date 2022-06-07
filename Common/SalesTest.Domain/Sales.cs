using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISales"/>
    public class Sales : ISales
    {
        public int Id { get; set; }

        //public DateTimeOffset Date { get; set; } = DateTimeOffset.Now.Date;
        public string Date { get; set; }

        //public DateTimeOffset Time {get; set; } = DateTimeOffset.Now.ToLocalTime();
        public string Time {get; set; }

        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        public List<ISalesData> SalesData { get; set; } = new List<ISalesData>();

        public decimal TotalAmount { get; set; }
        
    }
}
