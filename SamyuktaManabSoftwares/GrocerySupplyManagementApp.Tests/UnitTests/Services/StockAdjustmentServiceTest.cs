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
    public class StockAdjustmentServiceTest
    {
        private Mock<IStockAdjustmentRepository> _stockAdjustmentRepository;
        private StockAdjustmentService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _stockAdjustmentRepository = new Mock<IStockAdjustmentRepository>();
            _sut = new StockAdjustmentService(_stockAdjustmentRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockAdjustmentService")]
        public void GetStockAdjustmentViewList_ReturnsStockAdjustmentViews()
        {
            _stockAdjustmentRepository.Setup(repo => repo.GetStockAdjustmentViewList())
                .Returns(new List<StockAdjustmentView>() {
                new StockAdjustmentView() { 
                    Id = 1, 
                    EndOfDay = "2078-01-01", 
                    Action = Constants.ADD,
                    Narration = "Narration1", 
                    ItemCode = "ItemCode1",
                    ItemName = "ItemName1",
                    Quantity = 1.00m,
                    Price = 100.00m
                },
                new StockAdjustmentView() {
                    Id = 2,
                    EndOfDay = "2078-01-02",
                    Action = Constants.DEDUCT,
                    Narration = "Narration2",
                    ItemCode = "ItemCode2",
                    ItemName = "ItemName2",
                    Quantity = 2.00m,
                    Price = 200.00m
                },
            });

            var stockAdjustmentViews = _sut.GetStockAdjustmentViewList();

            Assert.AreEqual(2, stockAdjustmentViews.ToList().Count);
        }


        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockAdjustmentService")]
        public void GetAddedStockTotalQuantity_ReturnsTotalQuantity_WhenStockFilterIsPassed()
        {
            _stockAdjustmentRepository.Setup(repo => repo.GetAddedStockTotalQuantity(It.IsAny<StockFilter>()))
                .Returns(10.00m);

            var totalQuantity = _sut.GetAddedStockTotalQuantity(new StockFilter());

            Assert.AreEqual(10.00m, totalQuantity);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockAdjustmentService")]
        public void GetDeductedStockTotalQuantity_ReturnsTotalQuantity_WhenStockFilterIsPassed()
        {
            _stockAdjustmentRepository.Setup(repo => repo.GetDeductedStockTotalQuantity(It.IsAny<StockFilter>()))
                .Returns(10.00m);

            var totalQuantity = _sut.GetDeductedStockTotalQuantity(new StockFilter());

            Assert.AreEqual(10.00m, totalQuantity);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockAdjustmentService")]
        public void AddStockAdjustment_ReturnsStockAdjustment_WhenStockAdjustmentIsPassed()
        {
            _stockAdjustmentRepository.Setup(repo => repo.AddStockAdjustment(It.IsAny<StockAdjustment>()))
                .Returns(new StockAdjustment()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    UserTransactionId = 101,
                    ItemId = 10,
                    Unit = Constants.KILOGRAM,
                    Action = Constants.ADD,
                    Quantity = 1.00m,
                    Price = 100.00m,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var stockAdjustment = _sut.AddStockAdjustment(new StockAdjustment());

            Assert.AreEqual(1, stockAdjustment.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.StockAdjustmentService")]
        public void DeleteStockAdjustmentByUserTransaction_ReturnsTrue_WhenUserTransactionIdIsPassed()
        {
            long userTransactionId = 1;
            _stockAdjustmentRepository.Setup(repo => repo.DeleteStockAdjustmentByUserTransaction(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteStockAdjustmentByUserTransaction(userTransactionId);

            Assert.IsTrue(result);
        }
    }
}
