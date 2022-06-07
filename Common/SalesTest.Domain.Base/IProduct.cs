namespace SalesTest.Domain.Base
{
    /// <summary>Product</summary>
    public interface IProduct : INamedEntity
    {
        /// <summary>Price</summary>
        public decimal Price { get; set; }
    }
}
