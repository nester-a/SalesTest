namespace SalesTest.Domain.Base
{
    /// <summary>Sales Data</summary>
    public interface ISalesData
    {
        /// <summary>Id of the purchased product</summary>
        public int ProductId { get; set; }

        /// <summary>The number of pieces of purchased products of this ProductID</summary>
        public int ProductQuantity { get; set; }

        /// <summary>The total cost of the purchased quantity of goods of this ProductId</summary>
        public decimal ProductIdAmount { get; set; }

    }
}
