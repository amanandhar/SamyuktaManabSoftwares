using GrocerySupplyManagementApp.DTOs;
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
    public class StockServiceTest
    {
        private Mock<IStockRepository> _stockRepository;
        private Mock<IPurchasedItemRepository> _purchasedItemRepository;
        private Mock<ISoldItemRepository> _soldItemRepository;
        private Mock<IStockAdjustmentRepository> _stockAdjustmentRepository;
        private StockService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _stockRepository = new Mock<IStockRepository>();
            _purchasedItemRepository = new Mock<IPurchasedItemRepository>();
            _soldItemRepository = new Mock<ISoldItemRepository>();
            _stockAdjustmentRepository = new Mock<IStockAdjustmentRepository>();
            _sut = new StockService(_stockRepository.Object, _purchasedItemRepository.Object,
                _soldItemRepository.Object, _stockAdjustmentRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockService")]
        public void GetStocks_ReturnsStocks_WhenStockFilterIsPassed()
        {
            _stockRepository.Setup(repo => repo.GetStocks(It.IsAny<StockFilter>()))
                .Returns(new List<Stock>() {
                new Stock() { 
                    EndOfDay = "2078-01-01", 
                    Description = "Description1", 
                    Type = "Type1", 
                    ItemCode = "ItemCode1", 
                    ItemName = "ItemName1", 
                    ItemUnit = "ItemUnit1", 
                    PurchaseQuantity = 1.00m, 
                    SalesQuantity = 1.00m, 
                    StockQuantity = 1.00m, 
                    PurchasePrice = 100.00m, 
                    TotalPurchasePrice = 100.00m, 
                    AddedDate = DateTime.Parse("2078-01-01")
                },
                new Stock() {
                    EndOfDay = "2078-01-02",
                    Description = "Description2",
                    Type = "Type2",
                    ItemCode = "ItemCode2",
                    ItemName = "ItemName2",
                    ItemUnit = "ItemUnit2",
                    PurchaseQuantity = 2.00m,
                    SalesQuantity = 2.00m,
                    StockQuantity = 2.00m,
                    PurchasePrice = 200.00m,
                    TotalPurchasePrice = 400.00m,
                    AddedDate = DateTime.Parse("2078-01-02")
                }
            });

            var stocks = _sut.GetStocks(new StockFilter());

            Assert.AreEqual(2, stocks.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockService")]
        public void GetPerUnitValue_ReturnsPerUnitValue_WhenStocksAndStockFilterArePassed()
        {
            _stockRepository.Setup(repo => repo.GetPerUnitValue(It.IsAny<List<Stock>>(), It.IsAny<StockFilter>()))
                .Returns(10.00m);

            var perUnitValue = _sut.GetPerUnitValue(new List<Stock>(), new StockFilter());

            Assert.AreEqual(10.00m, perUnitValue);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockService")]
        public void GetStockValue_ReturnsStockValue_WhenStocksAndStockFilterArePassed()
        {
            _stockRepository.Setup(repo => repo.GetStockValue(It.IsAny<List<Stock>>(), It.IsAny<StockFilter>()))
                .Returns(10.00m);

            var stockValue = _sut.GetStockValue(new List<Stock>(), new StockFilter());

            Assert.AreEqual(10.00m, stockValue);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockService")]
        public void GetStockViewList_ReturnsStockViewList_WhenStocksAndStockFilterArePassed()
        {
            _stockRepository.Setup(repo => repo.GetStockViewList(It.IsAny<List<Stock>>(), It.IsAny<StockFilter>()))
                .Returns(new List<StockView>() {
                new StockView() {
                    EndOfDay = "2078-01-01",
                    Description = "Description1",
                    Type = "Type1",
                    ItemCode = "ItemCode1",
                    ItemName = "ItemName1",
                    PurchaseQuantity = 1.00m,
                    SalesQuantity = 1.00m,
                    Unit = Constants.KILOGRAM,
                    StockQuantity = 1.00m,
                    PurchasePrice = 100.00m,
                    TotalPurchasePrice = 100.00m,
                    SalesPrice = 100.00m,
                    StockValue = 100.00m,
                    PerUnitValue = 100.00m,
                    AddedDate = DateTime.Parse("2078-01-01")
                },
                new StockView() {
                    EndOfDay = "2078-01-02",
                    Description = "Description2",
                    Type = "Type2",
                    ItemCode = "ItemCode2",
                    ItemName = "ItemName2",
                    PurchaseQuantity = 2.00m,
                    SalesQuantity = 2.00m,
                    Unit = Constants.KILOGRAM,
                    StockQuantity = 2.00m,
                    PurchasePrice = 200.00m,
                    TotalPurchasePrice = 400.00m,
                    SalesPrice = 200.00m,
                    StockValue = 200.00m,
                    PerUnitValue = 200.00m,
                    AddedDate = DateTime.Parse("2078-01-02")
                }
            });

            var stockViews = _sut.GetStockViewList(new List<Stock>(), new StockFilter());

            Assert.AreEqual(2, stockViews.ToList().Count);
        }
    }
}
