namespace SalesTest.DAL.Enities
{
    public class ProvidedProduct
    {
        //public Product Product { get; set; }
        //public int ProductQuantity { get; set; }
        //public SalesPoint SalesPoint { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int SalesPointId { get; set; }
        public SalesPoint SalesPoint { get; set; }
    }
}
