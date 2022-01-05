using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class SoldItemServiceTest
    {
        private Mock<ISettingRepository> _settingRepository;
        private Mock<ISoldItemRepository> _soldItemRepository;
        private SoldItemService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _settingRepository = new Mock<ISettingRepository>();
            _soldItemRepository = new Mock<ISoldItemRepository>();
            _sut = new SoldItemService(_settingRepository.Object, _soldItemRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SoldItemService")]
        public void GetSoldItems_ReturnsSoldItems()
        {
            _soldItemRepository.Setup(repo => repo.GetSoldItems())
                .Returns(new List<SoldItem>() {
                new SoldItem() {
                    Id = 1, 
                    EndOfDay = "2078-01-01", 
                    MemberId = "M0001", 
                    InvoiceNo = "InvoiceNo1", 
                    ItemId = 1, 
                    Profit = 10.00m, 
                    Unit = Constants.KILOGRAM, 
                    Quantity = 1.00m, 
                    Price = 100.00m, 
                    AddedBy = "TestUser1", 
                    AddedDate = DateTime.Parse("2078-01-01"), 
                    UpdatedBy = null, 
                    UpdatedDate = null 
                },
                new SoldItem() {
                    Id = 1,
                    EndOfDay = "2078-01-02",
                    MemberId = "M0002",
                    InvoiceNo = "InvoiceNo2",
                    ItemId = 2,
                    Profit = 20.00m,
                    Unit = Constants.KILOGRAM,
                    Quantity = 2.00m,
                    Price = 200.00m,
                    AddedBy = "TestUser2",
                    AddedDate = DateTime.Parse("2078-01-02"),
                    UpdatedBy = null,
                    UpdatedDate = null
                },
            });

            var soldItems = _sut.GetSoldItems();

            Assert.AreEqual(2, soldItems.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SoldItemService")]
        public void GetSoldItemViewList_ReturnsSoldItemViews_WhenInvoiceNumberIsPassed()
        {
            _soldItemRepository.Setup(repo => repo.GetSoldItemViewList(It.IsAny<string>()))
                .Returns(new List<SoldItemView>() {
                new SoldItemView() {
                    Id = 1,
                    ItemCode = "ItemCode1",
                    ItemName = "ItemName1",
                    Profit = 10.00m,
                    Unit = Constants.KILOGRAM,
                    ItemPrice = 100.00m,
                    Quantity = 1.00m,
                    Total = 110.00m,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01")
                },
                new SoldItemView() {
                    Id = 2,
                    ItemCode = "ItemCode2",
                    ItemName = "ItemName2",
                    Profit = 20.00m,
                    Unit = Constants.KILOGRAM,
                    ItemPrice = 200.00m,
                    Quantity = 2.00m,
                    Total = 120.00m,
                    AddedBy = "TestUser2",
                    AddedDate = DateTime.Parse("2078-01-02")
                }
            });

            var soldItemViews = _sut.GetSoldItemViewList(string.Empty);

            Assert.AreEqual(2, soldItemViews.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SoldItemService")]
        public void GetSoldItemTotalQuantity_ReturnsTotalQuantity_WhenStockFilterIsPassed()
        {
            _soldItemRepository.Setup(repo => repo.GetSoldItemTotalQuantity(It.IsAny<StockFilter>()))
                .Returns(10.00m);

            var totalQuantity = _sut.GetSoldItemTotalQuantity(new StockFilter());

            Assert.AreEqual(10.00m, totalQuantity);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SoldItemService")]
        public void AddSoldItem_ReturnsSoldItem_WhenSoldItemIsPassed()
        {
            _soldItemRepository.Setup(repo => repo.AddSoldItem(It.IsAny<SoldItem>()))
                .Returns(new SoldItem() {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    MemberId = "M0001",
                    InvoiceNo = "InvoiceNo1",
                    ItemId = 1,
                    Profit = 10.00m,
                    Unit = Constants.KILOGRAM,
                    Quantity = 1.00m,
                    Price = 100.00m,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var soldItem = _sut.AddSoldItem(new SoldItem());

            Assert.AreEqual(1, soldItem.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SoldItemService")]
        public void DeleteSoldItem_ReturnsTrue_WhenInvoiceNumberIsPassed()
        {
            _soldItemRepository.Setup(repo => repo.DeleteSoldItem(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteSoldItem(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
