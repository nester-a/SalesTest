﻿namespace SalesTest.DAL.Enities
{
    public class SalesData
    {
        //public Product Product { get; set; }

        //public int ProductQuantity { get; set; }

        //public decimal ProductIdAmount { get; set; }

        //public Sales Sales { get; set; }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductIdAmount { get; set; }
        public Sales Sale { get; set; }
    }
}
