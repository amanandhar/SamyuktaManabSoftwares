using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class ItemServiceTest
    {
        private Mock<IItemRepository> _itemRepository;
        private ItemService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _itemRepository = new Mock<IItemRepository>();
            _sut = new ItemService(_itemRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemService")]
        public void GetItems_ReturnsItems()
        {
            _itemRepository.Setup(repo => repo.GetItems())
                .Returns(new List<Item>() {
                new Item() { Id = 1, EndOfDay = "2078-01-01", Code = "Code1", Name = "Item Name 1", AddedBy = "TestUser1", Unit = Constants.KILOGRAM, Threshold = 10, AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null },
                new Item() { Id = 2, EndOfDay = "2078-02-02", Code = "Code2", Name = "Item Name 2", AddedBy = "TestUser2", Unit = Constants.LITER, Threshold = 20,  AddedDate = DateTime.Parse("2078-02-02"), UpdatedBy = null, UpdatedDate = null }
            });

            var items = _sut.GetItems();

            Assert.AreEqual(2, items.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemService")]
        public void GetItem_ReturnsItem_WhenItemCodeIsPassed()
        {
            _itemRepository.Setup(repo => repo.GetItem(It.IsAny<string>()))
                .Returns(
                new Item() { Id = 1, EndOfDay = "2078-01-01", Code = "Code1", Name = "Item Name 1", AddedBy = "TestUser1", Unit = Constants.KILOGRAM, Threshold = 10, AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
                );

            var item = _sut.GetItem(string.Empty);

            Assert.AreEqual("Code1", item.Code);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemService")]
        public void GetItem_ReturnsItem_WhenItemIdIsPassed()
        {
            long id = 1;
            _itemRepository.Setup(repo => repo.GetItem(It.IsAny<long>()))
                .Returns(
                new Item() { Id = 1, EndOfDay = "2078-01-01", Code = "Code1", Name = "Item Name 1", AddedBy = "TestUser1", Unit = Constants.KILOGRAM, Threshold = 10, AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
                );

            var item = _sut.GetItem(id);

            Assert.AreEqual("Code1", item.Code);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemService")]
        public void AddItem_ReturnsItem_WhenItemIsPassed()
        {
            _itemRepository.Setup(repo => repo.AddItem(It.IsAny<Item>()))
                .Returns(
                new Item() { Id = 1, EndOfDay = "2078-01-01", Code = "Code1", Name = "Item Name 1", AddedBy = "TestUser1", Unit = Constants.KILOGRAM, Threshold = 10, AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
                );

            var item = _sut.AddItem(new Item());

            Assert.AreEqual("Code1", item.Code);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemService")]
        public void UpdateItem_ReturnsItem_WhenIdAndItemArePassed()
        {
            long id = 1;
            _itemRepository.Setup(repo => repo.UpdateItem(It.IsAny<long>(), It.IsAny<Item>()))
                .Returns(
                new Item() { Id = 1, EndOfDay = "2078-01-01", Code = "Code1", Name = "Item Name 1", AddedBy = "TestUser1", Unit = Constants.KILOGRAM, Threshold = 10, AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
                );

            var item = _sut.UpdateItem(id, new Item());

            Assert.AreEqual("Code1", item.Code);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ItemService")]
        public void DeleteItem_ReturnsTrue_WhenIdIsPassed()
        {
            long id = 1;
            _itemRepository.Setup(repo => repo.DeleteItem(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteItem(id);

            Assert.IsTrue(result);
        }
    }
}
