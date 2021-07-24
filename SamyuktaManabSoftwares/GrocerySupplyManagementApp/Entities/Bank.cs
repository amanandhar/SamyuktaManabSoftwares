using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Bank
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AccountNo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
