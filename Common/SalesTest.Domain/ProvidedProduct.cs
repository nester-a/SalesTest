using SalesTest.Domain.Base;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="IProvidedProduct"/>
    public class ProvidedProduct : IProvidedProduct
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
