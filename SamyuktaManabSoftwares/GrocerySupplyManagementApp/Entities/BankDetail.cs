using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class BankDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AccountNo { get; set; }
        public DateTime? Date { get; set; }
    }
}
