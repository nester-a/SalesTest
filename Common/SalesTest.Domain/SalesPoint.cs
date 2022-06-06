using SalesTest.Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="ISalesPoint"/>
    public class SalesPoint : ISalesPoint
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<IProvidedProduct> ProvidedProducts { get; set; }
    }
}
