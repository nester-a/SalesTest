using SalesTest.Domain.Base;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISalesData"/>
    public class SalesData : ISalesData
    {
        public int ProductId { get; set; }
        
        public int ProductQuantity { get; set; }
        
        public decimal ProductIdAmount { get; set; }
    }
}
