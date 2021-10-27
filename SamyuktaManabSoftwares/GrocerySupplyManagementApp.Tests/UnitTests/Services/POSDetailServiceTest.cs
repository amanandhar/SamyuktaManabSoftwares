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
    public class POSDetailServiceTest
    {
        private Mock<IPOSDetailRepository> _posDetailRepository;
        private POSDetailService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _posDetailRepository = new Mock<IPOSDetailRepository>();
            _sut = new POSDetailService(_posDetailRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.UserTransactionService")]
        public void GetPosDetails_ReturnsPosDetails_WhenDeliveryPersonTransactionFilterIsPassed()
        {
            _posDetailRepository.Setup(repo => repo.GetPOSDetails(It.IsAny<DeliveryPersonTransactionFilter>()))
                .Returns(new List<POSDetail>() {
                    new POSDetail()
                    {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    InvoiceNo = "InvoiceNo",
                    SubTotal = 100.00m,
                    DiscountPercent = 1.00m,
                    Discount = 1.00m,
                    VatPercent = 1.00m,
                    Vat = 1.00m,
                    DeliveryChargePercent = 1.00m,
                    DeliveryCharge = 1.00m,
                    DeliveryPersonId = "E0001"
                    },
                    new POSDetail()
                    {
                    Id = 1,
                    EndOfDay = "2078-01-02",
                    InvoiceNo = "InvoiceNo",
                    SubTotal = 200.00m,
                    DiscountPercent = 2.00m,
                    Discount = 2.00m,
                    VatPercent = 2.00m,
                    Vat = 2.00m,
                    DeliveryChargePercent = 2.00m,
                    DeliveryCharge = 2.00m,
                    DeliveryPersonId = "E0002"
                    },
                });

            var posDetails = _sut.GetPOSDetails(new DeliveryPersonTransactionFilter());

            Assert.AreEqual(2, posDetails.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.POSDetailService")]
        public void GetPOSDetailView_ReturnsPOSDetailView_WhenInvoiceNumberIsPassed()
        {
            _posDetailRepository.Setup(repo => repo.GetPOSDetailView(It.IsAny<string>()))
                .Returns(
                new POSDetailView()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    Action = Constants.SALES,
                    ActionType = Constants.CREDIT,
                    PartyId = "PartyId1",
                    PartyNumber = "PartyNumber1",
                    BankName = "BankName1",
                    IncomeExpense = "IncomeExpense1",
                    Narration = "Narration1",
                    SubTotal = 100.00m,
                    DiscountPercent = 2,
                    Discount = 2,
                    VatPercent = 0,
                    Vat = 0,
                    DeliveryChargePercent = 2,
                    DeliveryCharge = 1.96m,
                    DeliveryPersonId = "DeliveryPersonId1",
                    DueReceivedAmount = 99.04m,
                    ReceivedAmount = 0.00m,
                    AddedBy = "TestUser1",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                }
            );

            var posDetailView = _sut.GetPOSDetailView(string.Empty);

            Assert.AreEqual(1, posDetailView.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.POSDetailService")]
        public void AddPOSDetail_ReturnsPOSDetail_WhenPOSDetailIsPassed()
        {
            _posDetailRepository.Setup(repo => repo.AddPOSDetail(It.IsAny<POSDetail>()))
                .Returns(
                new POSDetail()
                {
                    Id = 1,
                    EndOfDay = "2078-01-01",
                    InvoiceNo = "InvoiceNo",
                    SubTotal = 100.00m,
                    DiscountPercent = 2,
                    Discount = 2,
                    VatPercent = 0,
                    Vat = 0,
                    DeliveryChargePercent = 2,
                    DeliveryCharge = 1.96m,
                    DeliveryPersonId = "E0001"
                }
            );

            var posDetail = _sut.AddPOSDetail(new POSDetail());

            Assert.AreEqual(1, posDetail.Id);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.POSDetailService")]
        public void DeletePOSDetail_ReturnsTrue_WhenInvoiceNumberIsPassed()
        {
            _posDetailRepository.Setup(repo => repo.DeletePOSDetail(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeletePOSDetail(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
