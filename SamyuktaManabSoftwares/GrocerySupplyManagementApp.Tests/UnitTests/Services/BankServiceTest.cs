using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class BankServiceTest
    {
        private Mock<IBankRepository> _bankRepository;
        private BankService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _bankRepository = new Mock<IBankRepository>();
            _sut = new BankService(_bankRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankService")]
        public void GetBanks_ReturnsBanks()
        {
            _bankRepository.Setup(repo => repo.GetBanks())
                .Returns(new List<Bank>() {
                new Bank() { Id = 1, EndOfDay = "2078-01-01", Name = "Test Bank 1", AccountNo = "TestAccNo1" , AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null },
                new Bank() { Id = 2, EndOfDay = "2078-02-02", Name = "Test Bank 2", AccountNo = "TestAccNo2" , AddedBy = "TestUser2", AddedDate = DateTime.Parse("2078-02-02"), UpdatedBy = null, UpdatedDate = null }
            });

            var banks = _sut.GetBanks();

            Assert.AreEqual(2, banks.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankService")]
        public void GetBank_ReturnsBank_WhenIdIsPassed()
        {
            long id = 1;
            _bankRepository.Setup(repo => repo.GetBank(It.IsAny<long>()))
                .Returns(new Bank() { Id = 1, EndOfDay = "2078-01-01", Name = "Test Bank 1", AccountNo = "TestAccNo1", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null });

            var bank = _sut.GetBank(id);

            Assert.IsNotNull(bank);
            Assert.AreEqual(1, bank.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankService")]
        public void AddBank_ReturnsBank_WhenBankIsPassed()
        {
            _bankRepository.Setup(repo => repo.AddBank(It.IsAny<Bank>()))
                .Returns(new Bank() { Id = 1, EndOfDay = "2078-01-01", Name = "Test Bank 1", AccountNo = "TestAccNo1", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null });

            var bank = _sut.AddBank(new Bank());

            Assert.IsNotNull(bank);
            Assert.AreEqual(1, bank.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankService")]
        public void UpdateBank_ReturnsBank_WhenIdAndBankArePassed()
        {
            long id = 1;
            _bankRepository.Setup(repo => repo.UpdateBank(It.IsAny<long>(), It.IsAny<Bank>()))
                .Returns(new Bank() { Id = 1, EndOfDay = "2078-01-01", Name = "Test Bank 1", AccountNo = "TestAccNo1", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null });

            var bank = _sut.UpdateBank(id, new Bank());

            Assert.IsNotNull(bank);
            Assert.AreEqual(1, bank.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.BankService")]
        public void DeleteBank_ReturnsTrue_WhenIdIsPassed()
        {
            long id = 1;
            _bankRepository.Setup(repo => repo.DeleteBank(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteBank(id);

            Assert.IsTrue(result);
        }
    }
}
