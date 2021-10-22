using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class EndOfDayServiceTest
    {
        private Mock<IEndOfDayRepository> _endOfDayRepository;
        private EndOfDayService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _endOfDayRepository = new Mock<IEndOfDayRepository>();
            _sut = new EndOfDayService(_endOfDayRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EndOfDayService")]
        public void GetEndOfDay_ReturnsEndOfDay_WhenDateIsPassed()
        {
            _endOfDayRepository.Setup(repo => repo.GetEndOfDay(It.IsAny<string>()))
                .Returns(new EndOfDay() { Id = 1, DateInAd = DateTime.Parse("2021-10-21"), DateInBs = "2078-07-04" } );

            var endOfDay = _sut.GetEndOfDay(string.Empty);

            Assert.AreEqual("2078-07-04", endOfDay.DateInBs);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EndOfDayService")]
        public void GetNextEndOfDay_ReturnsEndOfDay_WhenIdIsPassed()
        {
            long id = 1;
            _endOfDayRepository.Setup(repo => repo.GetNextEndOfDay(It.IsAny<long>()))
                .Returns(new EndOfDay() { Id = 1, DateInAd = DateTime.Parse("2021-10-21"), DateInBs = "2078-07-04" });

            var endOfDay = _sut.GetNextEndOfDay(id);

            Assert.AreEqual("2078-07-04", endOfDay.DateInBs);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.EndOfDayService")]
        public void IsEndOfDayExist_ReturnsTrue_WhenEndOfDayIsPassed()
        {
            _endOfDayRepository.Setup(repo => repo.IsEndOfDayExist(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.IsEndOfDayExist(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
