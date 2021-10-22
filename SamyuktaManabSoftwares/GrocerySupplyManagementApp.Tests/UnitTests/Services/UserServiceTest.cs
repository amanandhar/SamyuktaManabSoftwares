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
    public class UserServiceTest
    {
        private Mock<IUserRepository> _userRepository;
        private UserService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepository = new Mock<IUserRepository>();
            _sut = new UserService(_userRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void GetUsers_ReturnsUsers_WhenUsernameAndUserTypeArePassed()
        {
            _userRepository.Setup(repo => repo.GetUsers(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<User>() {
                    new User() { 
                        Id = 1, 
                        Username = "Username1", 
                        Password = "Password1", 
                        Type = Constants.ADMIN,
                        IsReadOnly = false,
                        Bank = true,
                        DailySummary = true,
                        DailyTransaction = true,
                        Employee = true,
                        EOD = true, 
                        ItemPricing = true,
                        Member = true,
                        POS = true,
                        Reports = true,
                        Settings = true,
                        StockSummary = true,
                        Supplier = true,
                        AddedBy = "TestUser1", 
                        AddedDate = DateTime.Parse("2078-01-01"), 
                        UpdatedBy = null, 
                        UpdatedDate = null 
                    },
                     new User() {
                        Id = 2,
                        Username = "Username2",
                        Password = "Password2",
                        Type = Constants.ADMIN,
                        IsReadOnly = false,
                        Bank = true,
                        DailySummary = true,
                        DailyTransaction = true,
                        Employee = true,
                        EOD = true,
                        ItemPricing = true,
                        Member = true,
                        POS = true,
                        Reports = true,
                        Settings = true,
                        StockSummary = true,
                        Supplier = true,
                        AddedBy = "TestUser2",
                        AddedDate = DateTime.Parse("2078-01-02"),
                        UpdatedBy = null,
                        UpdatedDate = null
                    }
                });

            var users = _sut.GetUsers(string.Empty, string.Empty);

            Assert.AreEqual(2, users.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void GetUser_ReturnsUser_WhenIdIsPassed()
        {
            long id = 1;
            _userRepository.Setup(repo => repo.GetUser(It.IsAny<long>()))
                .Returns(new User()
                {
                    Id = 1,
                    Username = "Username1",
                    Password = "Password1",
                    Type = Constants.ADMIN,
                    IsReadOnly = false,
                    Bank = true,
                    DailySummary = true,
                    DailyTransaction = true,
                    Employee = true,
                    EOD = true,
                    ItemPricing = true,
                    Member = true,
                    POS = true,
                    Reports = true,
                    Settings = true,
                    StockSummary = true,
                    Supplier = true,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var user = _sut.GetUser(id);

            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void GetUser_ReturnsUser_WhenUsernameIsPassed()
        {
            _userRepository.Setup(repo => repo.GetUser(It.IsAny<string>()))
                .Returns(new User()
                {
                    Id = 1,
                    Username = "Username1",
                    Password = "Password1",
                    Type = Constants.ADMIN,
                    IsReadOnly = false,
                    Bank = true,
                    DailySummary = true,
                    DailyTransaction = true,
                    Employee = true,
                    EOD = true,
                    ItemPricing = true,
                    Member = true,
                    POS = true,
                    Reports = true,
                    Settings = true,
                    StockSummary = true,
                    Supplier = true,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var user = _sut.GetUser(string.Empty);

            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void IsUserExist_ReturnsTrue_WhenUsernameIsPassed()
        {
            _userRepository.Setup(repo => repo.IsUserExist(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.IsUserExist(string.Empty);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void IsUserExist_ReturnsTrue_WhenUsernameAndPasswordArePassed()
        {
            _userRepository.Setup(repo => repo.IsUserExist(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var result = _sut.IsUserExist(string.Empty, string.Empty);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void AddUser_ReturnsUser_WhenUserIsPassed()
        {
            _userRepository.Setup(repo => repo.AddUser(It.IsAny<User>()))
                .Returns(new User()
                {
                    Id = 1,
                    Username = "Username1",
                    Password = "Password1",
                    Type = Constants.ADMIN,
                    IsReadOnly = false,
                    Bank = true,
                    DailySummary = true,
                    DailyTransaction = true,
                    Employee = true,
                    EOD = true,
                    ItemPricing = true,
                    Member = true,
                    POS = true,
                    Reports = true,
                    Settings = true,
                    StockSummary = true,
                    Supplier = true,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var user = _sut.AddUser(new User());

            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void UpdateUser_ReturnsUser_WhenUsernameAndUserArePassed()
        {
            _userRepository.Setup(repo => repo.UpdateUser(It.IsAny<string>(), It.IsAny<User>()))
                .Returns(new User()
                {
                    Id = 1,
                    Username = "Username1",
                    Password = "Password1",
                    Type = Constants.ADMIN,
                    IsReadOnly = false,
                    Bank = true,
                    DailySummary = true,
                    DailyTransaction = true,
                    Employee = true,
                    EOD = true,
                    ItemPricing = true,
                    Member = true,
                    POS = true,
                    Reports = true,
                    Settings = true,
                    StockSummary = true,
                    Supplier = true,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var user = _sut.UpdateUser(string.Empty, new User());

            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserService")]
        public void DeleteUser_ReturnsTrue_WhenUsernameIsPassed()
        {
            _userRepository.Setup(repo => repo.DeleteUser(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteUser(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
