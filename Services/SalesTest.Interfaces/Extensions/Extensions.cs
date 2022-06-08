using BuyerDAL = SalesTest.DAL.Enities.Buyer;
using BuyerDOM = SalesTest.Domain.Buyer;

namespace SalesTest.Interfaces.Extensions
{
    public static class Extensions
    {
        public static BuyerDAL ToDomain(this BuyerDOM item)
        {
            return new BuyerDAL()
            {
                Id = item.Id,
                Name = item.Name,

            };
        }
    }
}
