using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class ReportServiceTest
    {

        private Mock<IReportRepository> _reportRepository;
        private ReportService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _reportRepository = new Mock<IReportRepository>();
            _sut = new ReportService(_reportRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ReportService")]
        public void GetInvoiceReport_ReturnsInvoiceReportViews_WhenInvoiceNumberIsPassed()
        {
            _reportRepository.Setup(repo => repo.GetInvoiceReport(It.IsAny<string>()))
                .Returns(new List<InvoiceReportView>() {
                    new InvoiceReportView()
                    {
                        MemberId = "M0001",
                        Name = "Name1",
                        Address = "Address1",
                        ContactNo = 1111111111,
                        AccountNo = "AccountNo1",
                        InvoiceNo = "InvoiceNo1",
                        ActionType = "ActionType",
                        EndOfDay = "2078-01-01",
                        SubTotal = 100.00m,
                        Discount = 5.00m,
                        DeliveryCharge = 10.00m,
                        TotalAmount = 105.00m,
                        DueReceivedAmount = 105.00m,
                        ReceivedAmount = 0.00m,
                        ItemName = "ItemName1",
                        Volume = 1,
                        Unit = Constants.KILOGRAM,
                        Quantity = 1.00m,
                        Price = 100.00m,
                        Amount = 100.00m,
                        ItemNo = 1
                    },
                    new InvoiceReportView()
                    {
                        MemberId = "M0002",
                        Name = "Name2",
                        Address = "Address2",
                        ContactNo = 1111111111,
                        AccountNo = "AccountNo2",
                        InvoiceNo = "InvoiceNo2",
                        ActionType = "ActionType2",
                        EndOfDay = "2078-01-02",
                        SubTotal = 200.00m,
                        Discount = 5.00m,
                        DeliveryCharge = 10.00m,
                        TotalAmount = 205.00m,
                        DueReceivedAmount = 205.00m,
                        ReceivedAmount = 0.00m,
                        ItemName = "ItemName2",
                        Volume = 2,
                        Unit = Constants.KILOGRAM,
                        Quantity = 2.00m,
                        Price = 200.00m,
                        Amount = 200.00m,
                        ItemNo = 2
                    }
                });

            var invoiceReportView = _sut.GetInvoiceReport(string.Empty);

            Assert.AreEqual(2, invoiceReportView.ToList().Count);
        }
    }
}
