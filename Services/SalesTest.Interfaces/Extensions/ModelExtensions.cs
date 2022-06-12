using SalesTest.Domain.Base;
using SalesTest.Interfaces.Model.Product;

namespace SalesTest.Interfaces.Extensions
{
    public static class ModelExtensions
    {
        public static ProductModel ToModel(this IProduct item)
        {
            return new ProductModel()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }
    }
}
