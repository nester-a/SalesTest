using SalesTest.Domain.Base;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="IProduct"/>
    public class Product : IProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
