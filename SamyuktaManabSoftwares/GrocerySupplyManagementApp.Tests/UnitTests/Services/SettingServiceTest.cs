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
    public class SettingServiceTest
    {
        private Mock<ISettingRepository> _settingRepository;
        private SettingService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _settingRepository = new Mock<ISettingRepository>();
            _sut = new SettingService(_settingRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SettingService")]
        public void GetSettings_ReturnsSettings()
        {
            _settingRepository.Setup(repo => repo.GetSettings())
                .Returns(new List<Setting>() {
                new Setting() { Id = 1, StartingInvoiceNo = "IN-0000-01", StartingBillNo = "BN-0000-01", StartingDate = "2078-02-01", FiscalYear="2078/79", Discount = 2.00m, Vat = 2.00m, DeliveryCharge = 5.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null },
                new Setting() { Id = 2, StartingInvoiceNo = "IN-0000-02", StartingBillNo = "BN-0000-02", StartingDate = "2078-02-02", FiscalYear="2078/79", Discount = 2.00m, Vat = 2.00m, DeliveryCharge = 5.00m, AddedBy = "TestUser2", AddedDate = DateTime.Parse("2078-01-02"), UpdatedBy = null, UpdatedDate = null },
            });

            var settings = _sut.GetSettings();

            Assert.AreEqual(2, settings.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SettingService")]
        public void AddSetting_ReturnsSetting_WhenSettingAndTruncateFlagArePassed()
        {
            _settingRepository.Setup(repo => repo.AddSetting(It.IsAny<Setting>(), It.IsAny<bool>()))
                .Returns(
                new Setting() { Id = 1, StartingInvoiceNo = "IN-0000-01", StartingBillNo = "BN-0000-01", StartingDate = "2078-02-01", FiscalYear="2078/79", Discount = 2.00m, Vat = 2.00m, DeliveryCharge = 5.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var setting = _sut.AddSetting(new Setting());

            Assert.AreEqual("IN-0000-01", setting.StartingInvoiceNo);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SettingService")]
        public void UpdateSetting_ReturnsSetting_WhenIdAndSettingArePassed()
        {
            long id = 1;
            _settingRepository.Setup(repo => repo.UpdateSetting(It.IsAny<long>(), It.IsAny<Setting>()))
                .Returns(
                new Setting() { Id = 1, StartingInvoiceNo = "IN-0000-01", StartingBillNo = "BN-0000-01", StartingDate = "2078-02-01", FiscalYear = "2078/79", Discount = 2.00m, Vat = 2.00m, DeliveryCharge = 5.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var setting = _sut.UpdateSetting(id, new Setting());

            Assert.AreEqual("IN-0000-01", setting.StartingInvoiceNo);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SettingService")]
        public void DeletePreviousTransactions_ReturnsTrue_WhenEndOfDayIsPassed()
        {
            _settingRepository.Setup(repo => repo.DeletePreviousTransactions(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeletePreviousTransactions(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
