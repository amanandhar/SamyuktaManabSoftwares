using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class StockView
    {
        public DateTime EndOfDate { get; set; }
        public string BillInvoiceNo { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public long PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseTotal { get; set; }
        public decimal PurchaseGrandTotal { get; set; }
        public long SalesQuantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal SalesTotal { get; set; }
        public decimal SalesGrandTotal { get; set; }
        public long BalanceQuantity { get; set; }
        public decimal TotalStockValue { get; set; }
        public decimal PerUnitValue { get; set; }
        public DateTime Date { get; set; }
    }
}
