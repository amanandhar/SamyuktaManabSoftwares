using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Income
    {
        public long Id { get; set; }
        public DateTime EndOfDate { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
