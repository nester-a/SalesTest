using SalesTest.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="IProduct"/>
    public class Product : IProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
