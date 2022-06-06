namespace SalesTest.Domain.Base
{
    /// <summary>ProvidedProduct</summary>
    public interface IProvidedProduct
    {
        /// <summary>Product Id</summary>
        public int ProductId { get; set; }

        /// <summary>Quantity</summary>
        public int ProductQuantity { get; set; }
    }
}
