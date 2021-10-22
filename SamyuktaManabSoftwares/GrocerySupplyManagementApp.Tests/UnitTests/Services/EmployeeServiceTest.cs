using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class EmployeeServiceTest
    {
        private Mock<IEmployeeRepository> _employeeRepository;
        private EmployeeService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _sut = new EmployeeService(_employeeRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void GetEmployees_ReturnsEmployees()
        {
            _employeeRepository.Setup(repo => repo.GetEmployees())
                .Returns(new List<Employee>() {
                        new Employee()
                        {
                            Id = 1,
                            EndOfDay = "2078-01-01",
                            Counter = 1,
                            EmployeeId = "E0001",
                            Name = "Employee1",
                            TempAddress = "Temp Address1",
                            PermAddress = "Perm Address1",
                            ContactNo = 123456789,
                            Email = "test1.test1@gmail.com",
                            CitizenshipNo = "1111-2222",
                            Education = Constants.EDUCATION_SEE,
                            DateOfBirth = "2000-01-01",
                            Age = 21,
                            BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                            FatherName = "Father Name1",
                            MotherName = "Mother Name1",
                            Gender = Constants.MALE,
                            MaritalStatus = Constants.SINGLE,
                            Post = "Delivery Person1",
                            PostStatus = Constants.POST_STATUS_DAILY,
                            AppointedDate = "2078-01-01",
                            ResignedDate = "2078-01-01",
                            ImagePath = @"D:\Images\CompanyLogo1.jpg",
                            AddedBy = "TestUser",
                            AddedDate = DateTime.Parse("2078-01-01"),
                            UpdatedBy = null,
                            UpdatedDate = null
                        },

                        new Employee()
                        {
                            Id = 2,
                            EndOfDay = "2078-01-02",
                            Counter = 2,
                            EmployeeId = "E0002",
                            Name = "Employee2",
                            TempAddress = "Temp Address2",
                            PermAddress = "Perm Address2",
                            ContactNo = 123456789,
                            Email = "test2.test2@gmail.com",
                            CitizenshipNo = "2222-1111",
                            Education = Constants.EDUCATION_SEE,
                            DateOfBirth = "2000-01-02",
                            Age = 21,
                            BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                            FatherName = "Father Name2",
                            MotherName = "Mother Name2",
                            Gender = Constants.FEMALE,
                            MaritalStatus = Constants.MALE,
                            SpouseName = "Spouse Name2",
                            Post = "Delivery Person2",
                            PostStatus = Constants.POST_STATUS_DAILY,
                            AppointedDate = "2078-01-02",
                            ResignedDate = "2078-01-02",
                            ImagePath = @"D:\Images\CompanyLogo2.jpg",
                            AddedBy = "TestUser",
                            AddedDate = DateTime.Parse("2078-01-02"),
                            UpdatedBy = null,
                            UpdatedDate = null
                        }                 
                    });

            var employees = _sut.GetEmployees();

            Assert.AreEqual(2, employees.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void GetEmployee_ReturnsEmployee_WhenIdIsPassed()
        {
            long id = 1;
            _employeeRepository.Setup(repo => repo.GetEmployee(It.IsAny<long>()))
                .Returns(new Employee()
                        {
                            Id = 1,
                            EndOfDay = "2078-01-01",
                            Counter = 1,
                            EmployeeId = "E0001",
                            Name = "Employee1",
                            TempAddress = "Temp Address1",
                            PermAddress = "Perm Address1",
                            ContactNo = 123456789,
                            Email = "test1.test1@gmail.com",
                            CitizenshipNo = "1111-2222",
                            Education = Constants.EDUCATION_SEE,
                            DateOfBirth = "2000-01-01",
                            Age = 21,
                            BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                            FatherName = "Father Name1",
                            MotherName = "Mother Name1",
                            Gender = Constants.MALE,
                            MaritalStatus = Constants.SINGLE,
                            Post = "Delivery Person1",
                            PostStatus = Constants.POST_STATUS_DAILY,
                            AppointedDate = "2078-01-01",
                            ResignedDate = "2078-01-01",
                            ImagePath = @"D:\Images\CompanyLogo1.jpg",
                            AddedBy = "TestUser",
                            AddedDate = DateTime.Parse("2078-01-01"),
                            UpdatedBy = null,
                            UpdatedDate = null
                        }
                    );

            var employee = _sut.GetEmployee(id);

            Assert.AreEqual("Employee1", employee.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void GetEmployee_ReturnsEmployee_WhenEmployeeIdIsPassed()
        {
            string employeeId = "E0001";
            _employeeRepository.Setup(repo => repo.GetEmployee(It.IsAny<string>()))
                .Returns(new Employee()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    Counter = 1,
                    EmployeeId = "E0001",
                    Name = "Employee1",
                    TempAddress = "Temp Address1",
                    PermAddress = "Perm Address1",
                    ContactNo = 123456789,
                    Email = "test1.test1@gmail.com",
                    CitizenshipNo = "1111-2222",
                    Education = Constants.EDUCATION_SEE,
                    DateOfBirth = "2000-01-01",
                    Age = 21,
                    BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                    FatherName = "Father Name1",
                    MotherName = "Mother Name1",
                    Gender = Constants.MALE,
                    MaritalStatus = Constants.SINGLE,
                    Post = "Delivery Person1",
                    PostStatus = Constants.POST_STATUS_DAILY,
                    AppointedDate = "2078-01-01",
                    ResignedDate = "2078-01-01",
                    ImagePath = @"D:\Images\CompanyLogo1.jpg",
                    AddedBy = "TestUser",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                }
                    );

            var employee = _sut.GetEmployee(employeeId);

            Assert.AreEqual("Employee1", employee.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void GetNewEmployeeId_ReturnsEmployeeId()
        {
            _employeeRepository.Setup(repo => repo.GetLastEmployeeId())
                .Returns(1);

            var employeeId = _sut.GetNewEmployeeId();

            Assert.AreEqual("E0002", employeeId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void GetDeliveryPersons_ReturnsEmployees()
        {
            _employeeRepository.Setup(repo => repo.GetDeliveryPersons())
                .Returns(new List<Employee>() {
                        new Employee()
                        {
                            Id = 1,
                            EndOfDay = "2078-01-01",
                            Counter = 1,
                            EmployeeId = "E0001",
                            Name = "Employee1",
                            TempAddress = "Temp Address1",
                            PermAddress = "Perm Address1",
                            ContactNo = 123456789,
                            Email = "test1.test1@gmail.com",
                            CitizenshipNo = "1111-2222",
                            Education = Constants.EDUCATION_SEE,
                            DateOfBirth = "2000-01-01",
                            Age = 21,
                            BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                            FatherName = "Father Name1",
                            MotherName = "Mother Name1",
                            Gender = Constants.MALE,
                            MaritalStatus = Constants.SINGLE,
                            Post = "Delivery Person1",
                            PostStatus = Constants.POST_STATUS_DAILY,
                            AppointedDate = "2078-01-01",
                            ResignedDate = "2078-01-01",
                            ImagePath = @"D:\Images\CompanyLogo1.jpg",
                            AddedBy = "TestUser",
                            AddedDate = DateTime.Parse("2078-01-01"),
                            UpdatedBy = null,
                            UpdatedDate = null
                        },

                        new Employee()
                        {
                            Id = 2,
                            EndOfDay = "2078-01-02",
                            Counter = 2,
                            EmployeeId = "E0002",
                            Name = "Employee2",
                            TempAddress = "Temp Address2",
                            PermAddress = "Perm Address2",
                            ContactNo = 123456789,
                            Email = "test2.test2@gmail.com",
                            CitizenshipNo = "2222-1111",
                            Education = Constants.EDUCATION_SEE,
                            DateOfBirth = "2000-01-02",
                            Age = 21,
                            BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                            FatherName = "Father Name2",
                            MotherName = "Mother Name2",
                            Gender = Constants.FEMALE,
                            MaritalStatus = Constants.MALE,
                            SpouseName = "Spouse Name2",
                            Post = "Delivery Person2",
                            PostStatus = Constants.POST_STATUS_DAILY,
                            AppointedDate = "2078-01-02",
                            ResignedDate = "2078-01-02",
                            ImagePath = @"D:\Images\CompanyLogo2.jpg",
                            AddedBy = "TestUser",
                            AddedDate = DateTime.Parse("2078-01-02"),
                            UpdatedBy = null,
                            UpdatedDate = null
                        }
                    });

            var deliveryPersons = _sut.GetDeliveryPersons();

            Assert.AreEqual(2, deliveryPersons.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void AddEmployee_ReturnsEmployee_WhenEmployeeIsPassed()
        {
            _employeeRepository.Setup(repo => repo.AddEmployee(It.IsAny<Employee>()))
                .Returns(new Employee()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    Counter = 1,
                    EmployeeId = "E0001",
                    Name = "Employee1",
                    TempAddress = "Temp Address1",
                    PermAddress = "Perm Address1",
                    ContactNo = 123456789,
                    Email = "test1.test1@gmail.com",
                    CitizenshipNo = "1111-2222",
                    Education = Constants.EDUCATION_SEE,
                    DateOfBirth = "2000-01-01",
                    Age = 21,
                    BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                    FatherName = "Father Name1",
                    MotherName = "Mother Name1",
                    Gender = Constants.MALE,
                    MaritalStatus = Constants.SINGLE,
                    Post = "Delivery Person1",
                    PostStatus = Constants.POST_STATUS_DAILY,
                    AppointedDate = "2078-01-01",
                    ResignedDate = "2078-01-01",
                    ImagePath = @"D:\Images\CompanyLogo1.jpg",
                    AddedBy = "TestUser",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var employee = _sut.AddEmployee(new Employee());

            Assert.AreEqual("Employee1", employee.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void UpdateEmployee_ReturnsEmployee_WhenEmployeeIdAndEmployeeArePassed()
        {
            string employeeId = "E0001";
            _employeeRepository.Setup(repo => repo.UpdateEmployee(It.IsAny<string>(), It.IsAny<Employee>()))
                .Returns(new Employee()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    Counter = 1,
                    EmployeeId = "E0001",
                    Name = "Employee1",
                    TempAddress = "Temp Address1",
                    PermAddress = "Perm Address1",
                    ContactNo = 123456789,
                    Email = "test1.test1@gmail.com",
                    CitizenshipNo = "1111-2222",
                    Education = Constants.EDUCATION_SEE,
                    DateOfBirth = "2000-01-01",
                    Age = 21,
                    BloodGroup = Constants.BLOOD_GROUP_A_POSITIVE,
                    FatherName = "Father Name1",
                    MotherName = "Mother Name1",
                    Gender = Constants.MALE,
                    MaritalStatus = Constants.SINGLE,
                    Post = "Delivery Person1",
                    PostStatus = Constants.POST_STATUS_DAILY,
                    AppointedDate = "2078-01-01",
                    ResignedDate = "2078-01-01",
                    ImagePath = @"D:\Images\CompanyLogo1.jpg",
                    AddedBy = "TestUser",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var employee = _sut.UpdateEmployee(employeeId, new Employee());

            Assert.AreEqual("Employee1", employee.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EmployeeService")]
        public void DeleteEmployee_ReturnsTrue_WhenEmployeeIdIsPassed()
        {
            string employeeId = "E0001";
            _employeeRepository.Setup(repo => repo.DeleteEmployee(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteEmployee(employeeId);

            Assert.IsTrue(result);
        }
    }
}
