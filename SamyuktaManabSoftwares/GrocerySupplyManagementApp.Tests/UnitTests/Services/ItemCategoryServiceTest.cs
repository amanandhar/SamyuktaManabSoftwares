using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class ItemCategoryServiceTest
    {
        private Mock<IItemCategoryRepository> _itemCategoryRepository;
        private ItemCategoryService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _itemCategoryRepository = new Mock<IItemCategoryRepository>();
            _sut = new ItemCategoryService(_itemCategoryRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemCategoryService")]
        public void GetItemCategory_ReturnsItemCategory_WhenItemNameIsPassed()
        {
            _itemCategoryRepository.Setup(repo => repo.GetItemCategory(It.IsAny<string>()))
                .Returns(new ItemCategory() 
                { Id = 1, EndOfDay = "2078-01-01", Counter = 1 , Name = "ItemName1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var itemCategory = _sut.GetItemCategory(string.Empty);

            Assert.AreEqual("ItemName1", itemCategory.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemCategoryService")]
        public void AddItemCategory_ReturnsItemCategory_WhenItemCategoryIsPassed()
        {
            _itemCategoryRepository.Setup(repo => repo.AddItemCategory(It.IsAny<ItemCategory>()))
                .Returns(new ItemCategory()
                { Id = 1, EndOfDay = "2078-01-01", Counter = 1, Name = "ItemName1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var itemCategory = _sut.AddItemCategory(new ItemCategory());

            Assert.AreEqual("ItemName1", itemCategory.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemCategoryService")]
        public void DeleteItemCategory_ReturnsTrue_WhenItemCodeIsPassed()
        {
            _itemCategoryRepository.Setup(repo => repo.DeleteItemCategory(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteItemCategory(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
