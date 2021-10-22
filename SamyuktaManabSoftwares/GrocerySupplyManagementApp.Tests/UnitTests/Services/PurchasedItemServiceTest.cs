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
    public class PurchasedItemServiceTest
    {
        private Mock<IPurchasedItemRepository> _purchasedItemRepository;
        private Mock<ISettingRepository> _settingRepository;
        private PurchasedItemService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _purchasedItemRepository = new Mock<IPurchasedItemRepository>();
            _settingRepository = new Mock<ISettingRepository>();
            _sut = new PurchasedItemService(_purchasedItemRepository.Object, _settingRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void GetPurchasedItemDetails_ReturnsPurchasedItemListViews()
        {
            _purchasedItemRepository.Setup(repo => repo.GetPurchasedItemDetails())
                .Returns(new List<PurchasedItemListView>() {
                new PurchasedItemListView() { Id = 1, Code = "Code1", Name = "Name1", Brand = "Brand1" },
                new PurchasedItemListView() { Id = 2, Code = "Code2", Name = "Name2", Brand = "Brand2" }
            });

            var purchasedItemListViews = _sut.GetPurchasedItemDetails();

            Assert.AreEqual(2, purchasedItemListViews.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void GetPurchasedItemBySupplierAndBill_ReturnsPurchasedItems_WhenSupplierIdAndBillNumberArePassed()
        {
            _purchasedItemRepository.Setup(repo => repo.GetPurchasedItemBySupplierAndBill(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<PurchasedItem>() {
                new PurchasedItem() { Id = 1, EndOfDay = "2078-01-01",  SupplierId = "S0001", BillNo = "BillNo1", ItemId = 101, Quantity = 1.00m, Price = 100.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null },
                new PurchasedItem() { Id = 2, EndOfDay = "2078-01-02",  SupplierId = "S0002", BillNo = "BillNo2", ItemId = 202, Quantity = 2.00m, Price = 200.00m, AddedBy = "TestUser2", AddedDate = DateTime.Parse("2078-01-02"), UpdatedBy = null, UpdatedDate = null },
            });

            var purchasedItemListViews = _sut.GetPurchasedItemBySupplierAndBill(string.Empty, string.Empty);

            Assert.AreEqual(2, purchasedItemListViews.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void GetPurchasedItemTotalAmount_ReturnsTotalAmount_WhenSupplierIdAndBillNumberArePassed()
        {
            _purchasedItemRepository.Setup(repo => repo.GetPurchasedItemTotalAmount(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(100.00m);

            var totalAmount = _sut.GetPurchasedItemTotalAmount(string.Empty, string.Empty);

            Assert.AreEqual(100.00m, totalAmount);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void GetPurchasedItemTotalQuantity_ReturnsTotalAmount_WhenSupplierIdAndBillNumberArePassed()
        {
            _purchasedItemRepository.Setup(repo => repo.GetPurchasedItemTotalQuantity(It.IsAny<StockFilter>()))
                .Returns(10);

            var totalQuantity = _sut.GetPurchasedItemTotalQuantity(new StockFilter());

            Assert.AreEqual(10, totalQuantity);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void GetPurchasedItemByItemId_ReturnsPurchasedItem_WhenItemIdIsPassed()
        {
            long itemId = 1;
            _purchasedItemRepository.Setup(repo => repo.GetPurchasedItemByItemId(It.IsAny<long>()))
                .Returns(new PurchasedItem() { Id = 1, EndOfDay = "2078-01-01", SupplierId = "S0001", BillNo = "BillNo1", ItemId = 101, Quantity = 1.00m, Price = 100.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null });

            var purchasedItem = _sut.GetPurchasedItemByItemId(itemId);

            Assert.AreEqual(1, purchasedItem.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void GetLastBillNo_ReturnsBillNo_WhenInvoiceNoIsNotPresent()
        {
            _purchasedItemRepository.Setup(repo => repo.GetLastBillNo())
                .Returns(string.Empty);
            _settingRepository.Setup(repo => repo.GetSettings())
               .Returns(new List<Setting>()
               {
                   new Setting() {Id = 1, StartingInvoiceNo = "IN-01-0001", StartingBillNo = "BN-01-0001", StartingDate = "2078-02-01", FiscalYear="2078/79", Discount = 2.00m, Vat = 2.00m, DeliveryCharge = 5.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null}
               });

            var billNo = _sut.GetLastBillNo();

            Assert.AreEqual("BN-01-0001", billNo);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void GetLastBillNo_ReturnsBillNo_WhenInvoiceNoIsPresent()
        {
            _purchasedItemRepository.Setup(repo => repo.GetLastBillNo())
                .Returns("BN-01-0001");

            var billNo = _sut.GetLastBillNo();

            Assert.AreEqual("BN-01-0002", billNo);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void AddPurchasedItem_ReturnsPurchasedItem_WhenPurchasedItemIsPassed()
        {
            _purchasedItemRepository.Setup(repo => repo.AddPurchasedItem(It.IsAny<PurchasedItem>()))
                .Returns(new PurchasedItem() { Id = 1, EndOfDay = "2078-01-01", SupplierId = "S0001", BillNo = "BillNo1", ItemId = 101, Quantity = 1.00m, Price = 100.00m, AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null });

            var purchasedItem = _sut.AddPurchasedItem(new PurchasedItem());

            Assert.AreEqual(1, purchasedItem.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PurchasedItemService")]
        public void DeletePurchasedItem_ReturnsTrue_WhenBillNoIsPassed()
        {
            _purchasedItemRepository.Setup(repo => repo.DeletePurchasedItem(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeletePurchasedItem(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
