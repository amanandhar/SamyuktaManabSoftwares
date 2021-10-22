using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class SupplierServiceTest
    {
        private Mock<ISupplierRepository> _supplierRepository;
        private SupplierService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _supplierRepository = new Mock<ISupplierRepository>();
            _sut = new SupplierService(_supplierRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SupplierService")]
        public void GetSuppliers_ReturnsSuppliers()
        {
            _supplierRepository.Setup(repo => repo.GetSuppliers())
                .Returns(new List<Supplier>() {
                    new Supplier() { Id = 1, EndOfDay = "2078-01-01", Counter = 1, SupplierId = "S0001", Name = "SupplierName1", Address = "Address1", ContactNo = 1111111111, Email = "Email1", Owner = "Owner1", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null },
                    new Supplier() { Id = 2, EndOfDay = "2078-01-02", Counter = 2, SupplierId = "S0002", Name = "SupplierName2", Address = "Address2", ContactNo = 9999999999, Email = "Email2", Owner = "Owner2", AddedBy = "TestUser2", AddedDate = DateTime.Parse("2078-01-02"), UpdatedBy = null, UpdatedDate = null }
                });
            
            var suppliers = _sut.GetSuppliers();

            Assert.AreEqual(2, suppliers.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SupplierService")]
        public void GetSupplier_ReturnsSupplier_WhenSupplierIdIsPassed()
        {
            string supplierId = "S0001";
            _supplierRepository.Setup(repo => repo.GetSupplier(It.IsAny<string>()))
                .Returns(
                    new Supplier() { 
                        Id = 1, 
                        EndOfDay = "2078-01-01", 
                        Counter = 1, 
                        SupplierId = "S0001", 
                        Name = "SupplierName1", 
                        Address = "Address1", 
                        ContactNo = 1111111111, 
                        Email = "Email1", 
                        Owner = "Owner1", 
                        AddedBy = "TestUser1", 
                        AddedDate = DateTime.Parse("2078-01-01"), 
                        UpdatedBy = null, 
                        UpdatedDate = null 
                    }
                );

            var supplier = _sut.GetSupplier(supplierId);

            Assert.AreEqual(supplierId, supplier.SupplierId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SupplierService")]
        public void GetNewSupplierId_ReturnsSupplierId()
        {
            _supplierRepository.Setup(repo => repo.GetLastSupplierId())
                .Returns(1);

            var supplierId = _sut.GetNewSupplierId();

            Assert.AreEqual("S0002", supplierId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SupplierService")]
        public void AddSupplier_ReturnsSupplier_WhenSupplierIsPassed()
        {
            _supplierRepository.Setup(repo => repo.AddSupplier(It.IsAny<Supplier>()))
                .Returns(
                    new Supplier() { 
                        Id = 1, 
                        EndOfDay = "2078-01-01", 
                        Counter = 1, 
                        SupplierId = "S0001",
                        Name = "SupplierName1", 
                        Address = "Address1", 
                        ContactNo = 1111111111, 
                        Email = "Email1", 
                        Owner = "Owner1", 
                        AddedBy = "TestUser1", 
                        AddedDate = DateTime.Parse("2078-01-01"), 
                        UpdatedBy = null, 
                        UpdatedDate = null 
                    }
                );

            var supplier = _sut.AddSupplier(new Supplier());

            Assert.AreEqual("S0001", supplier.SupplierId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SupplierService")]
        public void UpdateSupplier_ReturnsSupplier_WhenSupplierIdAndSupplierArePassed()
        {
            _supplierRepository.Setup(repo => repo.UpdateSupplier(It.IsAny<string>(), It.IsAny<Supplier>()))
                .Returns(
                    new Supplier() { 
                        Id = 1, 
                        EndOfDay = "2078-01-01", 
                        Counter = 1, 
                        SupplierId = "S0001", 
                        Name = "SupplierName1", 
                        Address = "Address1", 
                        ContactNo = 1111111111, 
                        Email = "Email1", 
                        Owner = "Owner1", 
                        AddedBy = "TestUser1", 
                        AddedDate = DateTime.Parse("2078-01-01"), 
                        UpdatedBy = null, 
                        UpdatedDate = null 
                    }
                );

            var supplier = _sut.UpdateSupplier(string.Empty, new Supplier());

            Assert.AreEqual("S0001", supplier.SupplierId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.SupplierService")]
        public void DeleteSupplier_ReturnsTrue_WhenSupplierIdIsPassed()
        {
            _supplierRepository.Setup(repo => repo.DeleteSupplier(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteSupplier(string.Empty);

            Assert.IsTrue(result);
        }
    }
}
