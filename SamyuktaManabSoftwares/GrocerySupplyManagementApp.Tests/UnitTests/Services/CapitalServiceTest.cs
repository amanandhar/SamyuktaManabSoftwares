using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class CapitalServiceTest
    {
        private Mock<ICapitalRepository> _capitalRepository;
        private CapitalService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _capitalRepository = new Mock<ICapitalRepository>();
            _sut = new CapitalService(_capitalRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetMemberTotalBalance_ReturnsMemberTotalBalance_WhenUserTransactionFilterIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetMemberTotalBalance(It.IsAny<UserTransactionFilter>()))
                .Returns(101.01m);

            var memberTotalBalance = _sut.GetMemberTotalBalance(new UserTransactionFilter());

            Assert.AreEqual(101.01m, memberTotalBalance);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetSupplierTotalBalance_ReturnsSupplierTotalBalance_WhenSupplierTransactionFilterIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetSupplierTotalBalance(It.IsAny<SupplierTransactionFilter>()))
                .Returns(202.02m);

            var supplierTotalBalance = _sut.GetSupplierTotalBalance(new SupplierTransactionFilter());

            Assert.AreEqual(202.02m, supplierTotalBalance);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetOpeningCashBalance_ReturnsOpeningCashBalance_WhenEndOfDayIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetOpeningCashBalance(It.IsAny<string>()))
                .Returns(404.04m);

            var openingCashBalance = _sut.GetOpeningCashBalance(string.Empty);

            Assert.AreEqual(404.04m, openingCashBalance);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetOpeningCreditBalance_ReturnsOpeningCreditBalance_WhenEndOfDayIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetOpeningCreditBalance(It.IsAny<string>()))
                .Returns(505.05m);

            var openingCreditBalance = _sut.GetOpeningCreditBalance(string.Empty);

            Assert.AreEqual(505.05m, openingCreditBalance);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetCashBalance_ReturnsCashBalance_WhenEndOfDayIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetCashBalance(It.IsAny<string>()))
                .Returns(606.06m);

            var cashBalance = _sut.GetCashBalance(string.Empty);

            Assert.AreEqual(606.06m, cashBalance);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetCreditBalance_ReturnsCreditBalance_WhenEndOfDayIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetCreditBalance(It.IsAny<string>()))
                .Returns(707.07m);

            var creditBalance = _sut.GetCreditBalance(string.Empty);

            Assert.AreEqual(707.07m, creditBalance);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetTotalCashPayment_ReturnsTotalCashPayment_WhenEndOfDayIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetTotalCashPayment(It.IsAny<string>()))
                .Returns(808.08m);

            var totalCashPayment = _sut.GetTotalCashPayment(string.Empty);

            Assert.AreEqual(808.08m, totalCashPayment);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetTotalChequePayment_ReturnsTotalChequePayment_WhenEndOfDayIsPassed()
        {
            _capitalRepository.Setup(repo => repo.GetTotalChequePayment(It.IsAny<string>()))
                .Returns(909.09m);

            var totalChequePayment = _sut.GetTotalChequePayment(string.Empty);

            Assert.AreEqual(909.09m, totalChequePayment);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CapitalService")]
        public void GetTotalBalance_ReturnsTotalBalance_WhenEndOfDayAndActionAndActionTypeArePassed()
        {
            _capitalRepository.Setup(repo => repo.GetTotalBalance(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(1001.01m);

            var totalBalance = _sut.GetTotalBalance(string.Empty, string.Empty, string.Empty);

            Assert.AreEqual(1001.01m, totalBalance);
        }
    }
}
