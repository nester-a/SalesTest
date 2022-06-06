using SalesTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISales"/>
    public class Sales : ISales
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset Date { get; } = DateTimeOffset.Now.Date;

        public DateTimeOffset Time {get; } = DateTimeOffset.Now.ToLocalTime();

        [Required]
        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        [Required]
        public List<ISalesData> SalesData { get; set; } = new List<ISalesData>();

        [Required]
        public decimal TotalAmount { get; set; }
        
    }
}
