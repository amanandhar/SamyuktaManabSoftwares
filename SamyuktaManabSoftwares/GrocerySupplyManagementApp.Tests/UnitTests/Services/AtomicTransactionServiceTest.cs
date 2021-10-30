using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class AtomicTransactionServiceTest
    {
        private Mock<IAtomicTransactionRepository> _atomicTransactionRepository;
        private AtomicTransactionService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _atomicTransactionRepository = new Mock<IAtomicTransactionRepository>();
            _sut = new AtomicTransactionService(_atomicTransactionRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.AtomicTransactionService")]
        public void DeleteBill_ReturnsTrue_WhenIdAndBillNumberArePassed()
        {
            long id = 1;
            _atomicTransactionRepository.Setup(repo => repo.DeleteBill(It.IsAny<long>(), It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteBill(id, string.Empty);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.AtomicTransactionService")]
        public void DeleteInvoice_ReturnsTrue_WhenInvoiceNumberIsPassed()
        {
            _atomicTransactionRepository.Setup(repo => repo.DeleteInvoice(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteInvoice(string.Empty);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.AtomicTransactionService")]
        public void DeleteBankTransaction_ReturnsTrue_WhenIdIsPassed()
        {
            long id = 1;
            _atomicTransactionRepository.Setup(repo => repo.DeleteBankTransaction(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteBankTransaction(id);

            Assert.IsTrue(result);
        }
    }
}
