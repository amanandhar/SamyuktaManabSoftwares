using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
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
        private Mock<ISettingRepository> _settingRepository;
        private UserTransactionService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _userTransactionRepository = new Mock<IUserTransactionRepository>();
            _settingRepository = new Mock<ISettingRepository>();
            _sut = new UserTransactionService(_userTransactionRepository.Object, _settingRepository.Object);
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
                        InvoiceNo = "InvoiceNo1",
                        BillNo = "BillNo1",
                        MemberId = "MemberId1",
                        ShareMemberId = 1,
                        SupplierId = "SupplierId1",
                        DeliveryPersonId = "DeliveryPersonId1",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        Bank = "Bank1",
                        Income = "Income1",
                        Expense = "Expense1",
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
                        InvoiceNo = "InvoiceNo2",
                        BillNo = "BillNo2",
                        MemberId = "MemberId2",
                        ShareMemberId = 2,
                        SupplierId = "SupplierId2",
                        DeliveryPersonId = "DeliveryPersonId2",
                        Action = "Action2",
                        ActionType = "ActionType2",
                        Bank = "Bank2",
                        Income = "Income2",
                        Expense = "Expense2",
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
        public void GetDeliveryPersonTransactions_ReturnsUserTransactions_WhenDeliveryPersonTransactionFilterIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetDeliveryPersonTransactions(It.IsAny<DeliveryPersonTransactionFilter>()))
                .Returns(new List<UserTransaction>() {
                    new UserTransaction() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        InvoiceNo = "InvoiceNo1",
                        BillNo = "BillNo1",
                        MemberId = "MemberId1",
                        ShareMemberId = 1,
                        SupplierId = "SupplierId1",
                        DeliveryPersonId = "DeliveryPersonId1",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        Bank = "Bank1",
                        Income = "Income1",
                        Expense = "Expense1",
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
                        InvoiceNo = "InvoiceNo2",
                        BillNo = "BillNo2",
                        MemberId = "MemberId2",
                        ShareMemberId = 2,
                        SupplierId = "SupplierId2",
                        DeliveryPersonId = "DeliveryPersonId2",
                        Action = "Action2",
                        ActionType = "ActionType2",
                        Bank = "Bank2",
                        Income = "Income2",
                        Expense = "Expense2",
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

            var userTransactions = _sut.GetDeliveryPersonTransactions(new DeliveryPersonTransactionFilter());

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
            _userTransactionRepository.Setup(repo => repo.GetLastUserTransaction(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new UserTransaction() 
                {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        InvoiceNo = "InvoiceNo1",
                        BillNo = "BillNo1",
                        MemberId = "MemberId1",
                        ShareMemberId = 1,
                        SupplierId = "SupplierId1",
                        DeliveryPersonId = "DeliveryPersonId1",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        Bank = "Bank1",
                        Income = "Income1",
                        Expense = "Expense1",
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

            var userTransactions = _sut.GetLastUserTransaction(string.Empty, string.Empty);

            Assert.AreEqual(1, userTransactions.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetInvoiceNo_ReturnsInvoiceNo_WhenInvoiceNoIsNotPresent()
        {
            _userTransactionRepository.Setup(repo => repo.GetLastInvoiceNo())
                .Returns(string.Empty);

            _settingRepository.Setup(repo => repo.GetSettings())
               .Returns(new List<Setting>()
               {
                   new Setting() {Id = 1, StartingInvoiceNo = "IN-01-0001", StartingBillNo = "BN-01-0001", StartingDate = "2078-02-01", FiscalYear="2078/79", Discount = 2.00m, Vat = 2.00m, DeliveryCharge = 5.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null}
               });

            var invoiceNo = _sut.GetInvoiceNo();

            Assert.AreEqual("IN-01-0001", invoiceNo);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetInvoiceNo_ReturnsInvoiceNo_WhenInvoiceNoIsPresent()
        {
            _userTransactionRepository.Setup(repo => repo.GetLastInvoiceNo())
                .Returns("IN-01-0001");

            var invoiceNo = _sut.GetInvoiceNo();

            Assert.AreEqual("IN-01-0002", invoiceNo);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetInvoices_ReturnsInvoices()
        {
            _userTransactionRepository.Setup(repo => repo.GetInvoices())
                .Returns(new List<string>() {
                    "IN-01-0001", "IN-01-0002" 
                });

            var invoices = _sut.GetInvoices();

            Assert.AreEqual(2, invoices.ToList().Count);
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
                        MemberSupplierId = "M0001",
                        Action = "Action1",
                        ActionType = "ActionType1",
                        Bank = "Bank1",
                        InvoiceBillNo = "IN-01-0001",
                        Income = "Income",
                        Expense = "Expense",
                        Amount = 100.00m,
                        AddedDate = DateTime.Parse("2078-01-01")
                    },
                    new DailyTransactionView() {
                        Id = 2,
                        EndOfDay = "2078-01-02",
                        MemberSupplierId = "M0002",
                        Action = "Action2",
                        ActionType = "ActionType2",
                        Bank = "Bank2",
                        InvoiceBillNo = "BN-01-0001",
                        Income = "Income",
                        Expense = "Expense",
                        Amount = 100.00m,
                        AddedDate = DateTime.Parse("2078-01-01")
                    }
                });

            var dailyTransactions = _sut.GetDailyTransactions(new DailyTransactionFilter());

            Assert.AreEqual(2, dailyTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetShareMemberTransactions_ReturnsShareMemberTransactionViews_WhenShareMemberTransactionFilterIsPassed()
        {
            _userTransactionRepository.Setup(repo => repo.GetShareMemberTransactions(It.IsAny<ShareMemberTransactionFilter>()))
                .Returns(new List<ShareMemberTransactionView>() {
                    new ShareMemberTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        ShareMemberId = "1",
                        Name = "Name1",
                        ContactNo = 9999999999,
                        Description = "Description1",
                        Type = "Type1",
                        Debit = 100.00m,
                        Credit = 0.00m,
                        Balance = 100.00m
                    },
                    new ShareMemberTransactionView() {
                        Id = 2,
                        EndOfDay = "2078-01-02",
                        ShareMemberId = "2",
                        Name = "Name2",
                        ContactNo = 9999999999,
                        Description = "Description2",
                        Type = "Type2",
                        Debit = 200.00m,
                        Credit = 0.00m,
                        Balance = 200.00m
                    }
                });

            var shareMemberTransactions = _sut.GetShareMemberTransactions(new ShareMemberTransactionFilter());

            Assert.AreEqual(2, shareMemberTransactions.ToList().Count);
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
                    InvoiceNo = "InvoiceNo1",
                    BillNo = "BillNo1",
                    MemberId = "MemberId1",
                    ShareMemberId = 1,
                    SupplierId = "SupplierId1",
                    DeliveryPersonId = "DeliveryPersonId1",
                    Action = "Action1",
                    ActionType = "ActionType1",
                    Bank = "Bank1",
                    Income = "Income1",
                    Expense = "Expense1",
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
