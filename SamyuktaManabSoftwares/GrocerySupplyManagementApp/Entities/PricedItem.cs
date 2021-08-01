﻿using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PricedItem
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string ItemSubCode { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ProfitPercent { get; set; }
        public decimal Profit { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal SalesPricePerUnit { get; set; }
        public string ImagePath { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}