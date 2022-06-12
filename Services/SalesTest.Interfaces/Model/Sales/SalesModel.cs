using System;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Model.Sales
{
    public class SalesModel
    {
        public int Id { get; set; }

        public string Date { get; set; } = DateTime.Now.Date.ToShortDateString();

        public string Time { get; set; } = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

        public int SalesPointId { get; set; }

        public int? BuyerId { get; set; }

        public List<SalesDataModel> SalesData { get; set; } = new List<SalesDataModel>();

        public decimal TotalAmount { get; set; }
    }
}
