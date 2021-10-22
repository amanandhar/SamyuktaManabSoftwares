using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class CompanyInfoServiceTest
    {
        private Mock<ICompanyInfoRepository> _companyInfoRepository;
        private CompanyInfoService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _companyInfoRepository = new Mock<ICompanyInfoRepository>();
            _sut = new CompanyInfoService(_companyInfoRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CompanyInfoService")]
        public void GetCompanyInfo_ReturnsCompanyInfo()
        {
            _companyInfoRepository.Setup(repo => repo.GetCompanyInfo())
                .Returns(new CompanyInfo()
                {
                    Name = "Test Company Name",
                    ShortName = "TEST",
                    Type = "Test Suppliers",
                    Address = "NewYork",
                    ContactNo = 123456789,
                    EmailId = "test.test@gmail.com",
                    Website = "test.com.np",
                    FacebookPage = "Test Suppliers",
                    RegistrationNo = "1111-22",
                    RegistrationDate = "2078-06-07",
                    PanVatNo = "117308174",
                    LogoPath = @"D:\Images\CompanyLogo.jpg",
                    AddedBy = "TestUser",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var companyInfo = _sut.GetCompanyInfo();

            Assert.AreEqual("Test Company Name", companyInfo.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CompanyInfoService")]
        public void AddCompanyInfo_ReturnsCompanyInfo_WhenCompanyInfoIsPassed()
        {
            _companyInfoRepository.Setup(repo => repo.AddCompanyInfo(It.IsAny<CompanyInfo>()))
                .Returns(new CompanyInfo()
                {
                    Name = "Test Company Name",
                    ShortName = "TEST",
                    Type = "Test Suppliers",
                    Address = "NewYork",
                    ContactNo = 123456789,
                    EmailId = "test.test@gmail.com",
                    Website = "test.com.np",
                    FacebookPage = "Test Suppliers",
                    RegistrationNo = "1111-22",
                    RegistrationDate = "2078-06-07",
                    PanVatNo = "117308174",
                    LogoPath = @"D:\Images\CompanyLogo.jpg",
                    AddedBy = "TestUser",
                    AddedDate = DateTime.Parse("2078-01-01"),
                    UpdatedBy = null,
                    UpdatedDate = null
                });

            var companyInfo = _sut.AddCompanyInfo(new CompanyInfo());

            Assert.AreEqual("Test Company Name", companyInfo.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.CompanyInfoService")]
        public void DeleteCompanyInfo_ReturnsTrue()
        {
            _companyInfoRepository.Setup(repo => repo.DeleteCompanyInfo())
                .Returns(true);

            var result = _sut.DeleteCompanyInfo();

            Assert.IsTrue(result);
        }
    }
}
