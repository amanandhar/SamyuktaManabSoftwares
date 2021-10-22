using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
        [TestCategory("UnitTests"), TestCategory("Services.POSDetailService")]
        public void GetPOSDetailView_ReturnsPOSDetailView_WhenInvoiceNumberIsPassed()
        {
            _posDetailRepository.Setup(repo => repo.GetPOSDetailView(It.IsAny<string>()))
                .Returns(
                new POSDetailView() { 
                    Id = 1, 
                    EndOfDay = "2078-01-01", 
                    InvoiceNo = "InvoiceNo", 
                    BillNo = "BillNo",
                    MemberId = "MemberId",
                    ShareMemberId = 1,
                    SupplierId = "SupplierId",
                    DeliveryPersonId = "DeliveryPersonId",
                    Action = Constants.SALES,
                    ActionType = Constants.CREDIT,
                    Bank = "Bank",
                    Income = "Income",
                    Expense = null,
                    Narration = "Narration",
                    SubTotal = 100.00m,
                    DiscountPercent = 2,
                    Discount = 2,
                    VatPercent = 0,
                    Vat = 0,
                    DeliveryChargePercent = 2,
                    DeliveryCharge = 1.96m,
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
                    DeliveryCharge = 1.96m
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
