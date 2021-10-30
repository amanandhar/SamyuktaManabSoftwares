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
    public class BankTransactionServiceTest
    {
        private Mock<IBankTransactionRepository> _bankTransactionRepository;
        private BankTransactionService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _bankTransactionRepository = new Mock<IBankTransactionRepository>();
            _sut = new BankTransactionService(_bankTransactionRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankTransactionService")]
        public void GetBankTransactions_ReturnsBankTransactions_WhenBankIdIsPassed()
        {
            long id = 1;
            _bankTransactionRepository.Setup(repo => repo.GetBankTransactions(It.IsAny<long>()))
                .Returns(new List<BankTransaction>() {
                new BankTransaction() { Id = 1, EndOfDay = "2078-01-01", BankId = 1, Type = '0', Action = "Action1", TransactionId = 101, Debit = 10.01m, Credit = 0.00m, Narration = "Debited", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null },
                new BankTransaction() { Id = 2, EndOfDay = "2078-02-02", BankId = 2, Type = '1', Action = "Action2", TransactionId = 102, Debit = 0.00m, Credit = 20.02m, Narration = "Credited", AddedBy = "TestUser2", AddedDate = DateTime.Parse("2078-02-02"), UpdatedBy = null, UpdatedDate = null }
            });

            var bankTransactions = _sut.GetBankTransactions(id);

            Assert.AreEqual(2, bankTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankTransactionService")]
        public void GetBankTransactionViews_ReturnsBankTransactionViews_WhenBankIdIsPassed()
        {
            long id = 1;
            _bankTransactionRepository.Setup(repo => repo.GetBankTransactionViews(It.IsAny<long>()))
                .Returns(new List<BankTransactionView>() {
                new BankTransactionView() { Id = 1, EndOfDay = "2078-01-01", Description = "Debit", Narration = "Debited" , Debit = 10.01m, Credit = 0.00m, Balance = 101.01m },
                new BankTransactionView() { Id = 2, EndOfDay = "2078-02-02", Description = "Credit", Narration = "Credited" , Debit = 0.00m, Credit = 20.02m, Balance = 202.02m }
            });

            var bankTransactionViews = _sut.GetBankTransactionViews(id);

            Assert.AreEqual(2, bankTransactionViews.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankTransactionService")]
        public void GetBankTransactionViews_ReturnsBankTransactionViews_WhenBankTransactionFilterIsPassed()
        {
            _bankTransactionRepository.Setup(repo => repo.GetBankTransactionViews(It.IsAny<BankTransactionFilter>()))
                .Returns(new List<BankTransactionView>() {
                new BankTransactionView() { Id = 1, EndOfDay = "2078-01-01", Description = "Debit", Narration = "Debited" , Debit = 10.01m, Credit = 0.00m, Balance = 101.01m },
                new BankTransactionView() { Id = 2, EndOfDay = "2078-02-02", Description = "Credit", Narration = "Credited" , Debit = 0.00m, Credit = 20.02m, Balance = 202.02m }
            });

            var bankTransactionViews = _sut.GetBankTransactionViews(new BankTransactionFilter());

            Assert.AreEqual(2, bankTransactionViews.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankTransactionService")]
        public void GetTotalBalance_ReturnsTotalBalance_WhenBankTransactionFilterIsPassed()
        {
            _bankTransactionRepository.Setup(repo => repo.GetTotalBalance(It.IsAny<BankTransactionFilter>()))
                .Returns(100.00m);

            var totalBalance = _sut.GetTotalBalance(new BankTransactionFilter());

            Assert.AreEqual(100.00m, totalBalance);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankTransactionService")]
        public void AddBankTransaction_ReturnsBankTransaction_WhenBankTransactionIsPassed()
        {
            _bankTransactionRepository.Setup(repo => repo.AddBankTransaction(It.IsAny<BankTransaction>()))
                .Returns(new BankTransaction() { Id = 1, EndOfDay = "2078-01-01", BankId = 1, Type = '0', Action = "Action1", TransactionId = 101, Debit = 10.01m, Credit = 0.00m, Narration = "Debited", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null });

            var bankTransaction = _sut.AddBankTransaction(new BankTransaction());

            Assert.IsNotNull(bankTransaction);
            Assert.AreEqual(1, bankTransaction.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankTransactionService")]
        public void DeleteBankTransaction_ReturnsTrue_WhenBankTransactionIdIsPassed()
        {
            long bankTransactionId = 1;
            _bankTransactionRepository.Setup(repo => repo.DeleteBankTransaction(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteBankTransaction(bankTransactionId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankTransactionService")]
        public void DeleteBankTransactionByUserTransaction_ReturnsTrue_WhenPassedUserTransactionIdIsPassed()
        {
            long userTransactionId = 1;
            _bankTransactionRepository.Setup(repo => repo.DeleteBankTransactionByTransactionId(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteBankTransactionByTransactionId(userTransactionId);

            Assert.IsTrue(result);
        }
    }
}
