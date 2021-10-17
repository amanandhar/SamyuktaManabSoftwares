using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public long Counter { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string TempAddress { get; set; }
        public string PermAddress { get; set; }
        public long ContactNo { get; set; }
        public string Email { get; set; }
        public string CitizenshipNo { get; set; }
        public string Education { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string Post { get; set; }
        public string PostStatus { get; set; }
        public string AppointedDate { get; set; }
        public string ResignedDate { get; set; }
        public string ImagePath { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
