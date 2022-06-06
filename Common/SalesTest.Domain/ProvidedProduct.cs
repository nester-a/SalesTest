using SalesTest.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="IProvidedProduct"/>
    public class ProvidedProduct : IProvidedProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
    }
}
