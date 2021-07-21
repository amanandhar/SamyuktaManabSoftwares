﻿using System;

namespace GrocerySupplyManagementApp.DTOs
{
    public class Stock
    {
        public DateTime EndOfDate { get; set; }
        public string Type { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int PurchaseQuantity { get; set; }
        public int SalesQuantity { get; set; }
        public int StockQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalPurchasePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
