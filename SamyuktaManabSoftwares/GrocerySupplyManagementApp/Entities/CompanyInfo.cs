using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class CompanyInfo
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public string FacebookPage { get; set; }
        public string RegistrationNo { get; set; }
        public string RegistrationDate { get; set; }
        public string PanVatNo { get; set; }
        public string LogoPath { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
