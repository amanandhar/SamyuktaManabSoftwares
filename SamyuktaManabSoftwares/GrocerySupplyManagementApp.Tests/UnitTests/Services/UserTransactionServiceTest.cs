using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared.Enums;
using GrocerySupplyManagementApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class UserTransactionServiceTest
    {
        private Mock<IUserTransactionRepository> _userTransactionRepository;
        private UserTransactionService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _userTransactionRepository = new Mock<IUserTransactionRepository>();
            _sut = new UserTransactionService(_userTransactionRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetUserTransactions_ReturnsUserTransactions_WhenUserTransactionFilterIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetUserTransactions(It.IsAny<UserTransactionFilter>()))
                .Returns(new List<UserTransaction>() {
                    new UserTransaction() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        PartyId = "PartyId1",
                        PartyNumber = "PartyNumber1",
                        BankName = "BankName1",
                        Narration = "Narration1",
                        DueReceivedAmount = 10.00m,
                        DuePaymentAmount = 0.00m,
                        ReceivedAmount = 0.00m,
                        PaymentAmount = 0.00m,
                        AddedBy = "TestUser1",
                        AddedDate = DateTime.Parse("2078-01-01"),
                        UpdatedBy = null,
                        UpdatedDate = null
                    },
                    new UserTransaction() {
                        Id = 2,
                        EndOfDay = "2078-01-02",
                        Action = "Action2",
                        ActionType = "ActionType2",
                        PartyId = "PartyId2",
                        PartyNumber = "PartyNumber2",
                        BankName = "BankName2",
                        Narration = "Narration2",
                        DueReceivedAmount = 00.00m,
                        DuePaymentAmount = 0.00m,
                        ReceivedAmount = 10.00m,
                        PaymentAmount = 0.00m,
                        AddedBy = "TestUser2",
                        AddedDate = DateTime.Parse("2078-01-02"),
                        UpdatedBy = null,
                        UpdatedDate = null
                    }
                });

            var userTransactions = _sut.GetUserTransactions(new UserTransactionFilter());

            Assert.AreEqual(2, userTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetMemberTransactions_ReturnsMemberTransactionViews_WhenMemberTransactionFilterIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetMemberTransactions(It.IsAny<MemberTransactionFilter>()))
                .Returns(new List<MemberTransactionView>() {
                    new MemberTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        InvoiceNo = "InvoiceNo1",
                        DueReceivedAmount = 10.00m,
                        ReceivedAmount = 0.00m,
                        Balance = 10.00m
                    },
                    new MemberTransactionView() {
                        Id = 2,
                        EndOfDay = "2078-01-02",
                        Action = "Action2",
                        ActionType = "ActionType2",
                        InvoiceNo = "InvoiceNo2",
                        DueReceivedAmount = 00.00m,
                        ReceivedAmount = 10.00m,
                        Balance = 10.00m
                    }
                });

            var memberTransactions = _sut.GetMemberTransactions(new MemberTransactionFilter());

            Assert.AreEqual(2, memberTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetSupplierTransactions_ReturnsSupplierTransactionViews_WhenSupplierTransactionFilterIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetSupplierTransactions(It.IsAny<SupplierTransactionFilter>()))
                .Returns(new List<SupplierTransactionView>() {
                    new SupplierTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        BillNo = "BillNo1",
                        DuePaymentAmount = 10.00m,
                        PaymentAmount = 0.00m,
                        Balance = 0.00m
                    },
                    new SupplierTransactionView() {
                        Id = 2,
                        EndOfDay = "2078-01-02",
                        Action = "Action2",
                        ActionType = "ActionType1",
                        BillNo = "BillNo2",
                        DuePaymentAmount = 0.00m,
                        PaymentAmount = 10.00m,
                        Balance = 10.00m,
                    }
                });

            var supplierTransactions = _sut.GetSupplierTransactions(new SupplierTransactionFilter());

            Assert.AreEqual(2, supplierTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetLastUserTransaction_ReturnsUserTransaction_WhenAddedByAndOptionArePassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetLastUserTransaction(It.IsAny<PartyNumberType>(), It.IsAny<string>()))
                .Returns(new UserTransaction()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    Action = "Action1",
                    ActionType = "ActionType1",
                    PartyId = "PartyId1",
                    PartyNumber = "PartyNumber1",
                    BankName = "BankName1",
                    Narration = "Narration1",
                    DueReceivedAmount = 10.00m,
                    DuePaymentAmount = 0.00m,
                    ReceivedAmount = 0.00m,
                    PaymentAmount = 0.00m,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var lastUserTransaction = _sut.GetLastUserTransaction(PartyNumberType.None, string.Empty);

            Assert.AreEqual(1, lastUserTransaction.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetDailyTransactions_ReturnsDailyTransactionViews_WhenDailyTransactionFilterIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetDailyTransactions(It.IsAny<DailyTransactionFilter>()))
                .Returns(new List<DailyTransactionView>() {
                    new DailyTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        PartyId = "PartyId1",
                        PartyNumber = "PartyNumber1",
                        BankName = "BankName1",
                        Amount = 100.00m,
                        AddedDate = DateTime.Parse("2078-01-01")
                    },
                    new DailyTransactionView() {
                        Id = 2,
                        EndOfDay = "2078-01-02",
                        Action = "Action2",
                        ActionType = "ActionType2",
                        PartyId = "PartyId2",
                        PartyNumber = "PartyNumber2",
                        BankName = "BankName2",
                        Amount = 100.00m,
                        AddedDate = DateTime.Parse("2078-01-02")
                    }
                });

            var dailyTransactions = _sut.GetDailyTransactions(new DailyTransactionFilter());

            Assert.AreEqual(2, dailyTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetSalesReturnTransactions_ReturnsSalesReturnTransactionViews_WhenSalesReturnTransactionFilterIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetSalesReturnTransactions(It.IsAny<SalesReturnTransactionFilter>()))
                .Returns(new List<SalesReturnTransactionView>() {
                    new SalesReturnTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Description = "Description1",
                        ItemCode = "ItemCode1",
                        ItemName = "ItemName1",
                        ItemQuantity = 1.00m,
                        ItemPrice = 100.00m,
                        SalesProfit = 10.00m,
                        Amount = 110.00m
                    },
                    new SalesReturnTransactionView() {
                        Id = 2,
                        EndOfDay = "2078-01-02",
                        Description = "Description2",
                        ItemCode = "ItemCode2",
                        ItemName = "ItemName2",
                        ItemQuantity = 1.00m,
                        ItemPrice = 200.00m,
                        SalesProfit = 20.00m,
                        Amount = 220.00m
                    }
                });

            var salesReturnTransactions = _sut.GetSalesReturnTransactions(new SalesReturnTransactionFilter());

            Assert.AreEqual(2, salesReturnTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void AddUserTransaction_ReturnsUserTransaction_WhenUserTransactionIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.AddUserTransaction(It.IsAny<UserTransaction>()))
                .Returns(new UserTransaction()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    Action = "Action1",
                    ActionType = "ActionType1",
                    PartyId = "PartyId1",
                    PartyNumber = "PartyNumber1",
                    BankName = "BankName1",
                    Narration = "Narration1",
                    DueReceivedAmount = 10.00m,
                    DuePaymentAmount = 0.00m,
                    ReceivedAmount = 0.00m,
                    PaymentAmount = 0.00m,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var userTransaction = _sut.AddUserTransaction(new UserTransaction());

            Assert.AreEqual(1, userTransaction.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void DeleteUserTransaction_ReturnsTrue_WhenIdIsPassed()
        {
            long id = 1;
            _userTransactionRepository.Setup(repo => repo.DeleteUserTransaction(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteUserTransaction(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void DeleteUserTransaction_ReturnsTrue_WhenInvoiceNumberIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.DeleteUserTransaction(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteUserTransaction(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
