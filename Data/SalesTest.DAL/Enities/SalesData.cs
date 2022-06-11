namespace SalesTest.DAL.Enities
{
    public class SalesData
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductIdAmount { get; set; }
        public int SalesId { get; set; }
        public Sales Sales { get; set; }
    }
}
