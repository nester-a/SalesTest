using BuyerDAL = SalesTest.DAL.Enities.Buyer;
using SalesDAL = SalesTest.DAL.Enities.Sales;
using BuyerDOM = SalesTest.Domain.Buyer;
using SalesDOM = SalesTest.Domain.Sales;
using System.Collections.Generic;
using System.Linq;

namespace SalesTest.Interfaces.Extensions
{
    public static class Extensions
    {
        public static BuyerDAL ToDAL(this BuyerDOM item)
        {
            return new BuyerDAL()
            {
                Id = item.Id,
                Name = item.Name,
                // здесь преобразователь можно какой-нибудь
            };
        }

        public static BuyerDOM ToDal(this BuyerDAL item)
        {
            var sales = item.Sales?.Select(i => i.Id).ToList();
            var buyer = new BuyerDOM()
            {
                Id = item.Id,
                Name = item.Name,
                SalesIds = sales,
            };

            return buyer;
        }
    }
}
