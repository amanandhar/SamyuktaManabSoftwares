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
    public class PricedItemServiceTest
    {
        private Mock<IPricedItemRepository> _pricedItemRepository;
        private PricedItemService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _pricedItemRepository = new Mock<IPricedItemRepository>();
            _sut = new PricedItemService(_pricedItemRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PricedItemService")]
        public void GetPricedItem_ReturnsPricedItem_WhenIdIsPassed()
        {
            long id = 1;
            _pricedItemRepository.Setup(repo => repo.GetPricedItem(It.IsAny<long>()))
                .Returns(
                new PricedItem() { Id = 1, EndOfDay = "2078-01-01", ItemId = 101, SubCode = "SubCode1", Volume = 10, ProfitPercent = 2.00m, Profit = 10.00m, SalesPricePerUnit = 120.00m, ImagePath = @"D:\Images\CompanyLogo1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var pricedItem = _sut.GetPricedItem(id);

            Assert.AreEqual(101, pricedItem.ItemId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PricedItemService")]
        public void GetPricedItem_ReturnsPricedItem_WhenItemCodeAndItemSubCodeArePassed()
        {
            _pricedItemRepository.Setup(repo => repo.GetPricedItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(
                new PricedItem() { Id = 1, EndOfDay = "2078-01-01", ItemId = 101, SubCode = "SubCode1", Volume = 10, ProfitPercent = 2.00m, Profit = 10.00m, SalesPricePerUnit = 120.00m, ImagePath = @"D:\Images\CompanyLogo1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var pricedItem = _sut.GetPricedItem(string.Empty, string.Empty);

            Assert.AreEqual(101, pricedItem.ItemId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PricedItemService")]
        public void GetPricedItemViewList_ReturnsPricedItemViews()
        {
            _pricedItemRepository.Setup(repo => repo.GetPricedItemViewList())
                .Returns( new List<PricedItemView>()
                {
                    new PricedItemView() { Id = 1, Code = "Code1", SubCode = "SubCode1", Name = "Name1", Brand = "Brand1" },
                    new PricedItemView() { Id = 2, Code = "Code2", SubCode = "SubCode2", Name = "Name2", Brand = "Brand2" }
                }
            );

            var pricedItemViews = _sut.GetPricedItemViewList();

            Assert.AreEqual(2, pricedItemViews.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PricedItemService")]
        public void GetUnpricedItemViewList_ReturnsUnpricedItemViews()
        {
            _pricedItemRepository.Setup(repo => repo.GetUnpricedItemViewList())
                .Returns(new List<UnpricedItemView>()
                {
                    new UnpricedItemView() { Id = 1, Code = "Code1", Name = "Name1", Brand = "Brand1" },
                    new UnpricedItemView() { Id = 2, Code = "Code2", Name = "Name2", Brand = "Brand2" }
                }
            );

            var unpricedItemViews = _sut.GetUnpricedItemViewList();

            Assert.AreEqual(2, unpricedItemViews.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PricedItemService")]
        public void AddPricedItem_ReturnsPricedItem_WhenPriceItemIsPassed()
        {
            _pricedItemRepository.Setup(repo => repo.AddPricedItem(It.IsAny<PricedItem>()))
                .Returns(
                new PricedItem() { Id = 1, EndOfDay = "2078-01-01", ItemId = 101, SubCode = "SubCode1", Volume = 10, ProfitPercent = 2.00m, Profit = 10.00m, SalesPricePerUnit = 120.00m, ImagePath = @"D:\Images\CompanyLogo1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var pricedItem = _sut.AddPricedItem(new PricedItem());

            Assert.AreEqual(101, pricedItem.ItemId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PricedItemService")]
        public void UpdatePricedItem_ReturnsPricedItem_WhenIdAndPricedItemArePassed()
        {
            long id = 1;
            _pricedItemRepository.Setup(repo => repo.UpdatePricedItem(It.IsAny<long>(), It.IsAny<PricedItem>()))
                .Returns(
                new PricedItem() { Id = 1, EndOfDay = "2078-01-01", ItemId = 101, SubCode = "SubCode1", Volume = 10, ProfitPercent = 2.00m, Profit = 10.00m, SalesPricePerUnit = 120.00m, ImagePath = @"D:\Images\CompanyLogo1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var pricedItem = _sut.UpdatePricedItem(id, new PricedItem());

            Assert.AreEqual(101, pricedItem.ItemId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.PricedItemService")]
        public void DeletePricedItem_ReturnsTrue_WhenIdIsPassed()
        {
            long id = 1;
            _pricedItemRepository.Setup(repo => repo.DeletePricedItem(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeletePricedItem(id);

            Assert.IsTrue(result);
        }
    }
}
