﻿using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Item
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public int Threshold { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
