using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class POSDetailView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string PartyId { get; set; }
        public string PartyNumber { get; set; }
        public string BankName { get; set; }
        public string Narration { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal Vat { get; set; }
        public decimal DeliveryChargePercent { get; set; }
        public decimal DeliveryCharge { get; set; }
        public string DeliveryPersonId { get; set; }
        public decimal DueReceivedAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
