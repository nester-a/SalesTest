namespace SalesTest.DAL.Enities
{
    public class ProvidedProduct
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int SalesPointId { get; set; }
        public SalesPoint SalesPoint { get; set; }
    }
}
