using System.Collections.Generic;

namespace SalesTest.Interfaces.Model.Sales
{
    public class CreateSalesModel
    {
        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        public List<SalesDataModel> SalesData { get; set; } = new List<SalesDataModel>();

        public decimal TotalAmount { get; set; }
    }
}
