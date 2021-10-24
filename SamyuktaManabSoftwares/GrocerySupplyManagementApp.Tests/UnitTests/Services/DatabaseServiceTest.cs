using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class DatabaseServiceTest
    {
        private Mock<IDatabaseRepository> _databaseRepository;
        private DatabaseService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _databaseRepository = new Mock<IDatabaseRepository>();
            _sut = new DatabaseService(_databaseRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.DatabaseService")]
        public void BackupDatabase_ReturnsTrue_WhenDbBackupPrefixAndDbBackupFolderArePassed()
        {
            _databaseRepository.Setup(repo => repo.BackupDatabase(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var result = _sut.BackupDatabase(string.Empty, string.Empty);

            Assert.IsTrue(result);
        }
    }
}
