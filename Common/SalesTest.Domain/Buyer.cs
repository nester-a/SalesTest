using SalesTest.Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesTest.Domain
{
    ///<inheritdoc cref="IBuyer"/>
    public class Buyer : IBuyer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<int> SalesIds { get; set; }
    }
}
