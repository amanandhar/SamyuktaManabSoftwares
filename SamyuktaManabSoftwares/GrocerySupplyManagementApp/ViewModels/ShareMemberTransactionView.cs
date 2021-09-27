﻿namespace GrocerySupplyManagementApp.ViewModels
{
    public class ShareMemberTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}