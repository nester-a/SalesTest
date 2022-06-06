using SalesTest.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISalesData"/>
    public class SalesData : ISalesData
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public decimal ProductIdAmount { get; set; }
    }
}
