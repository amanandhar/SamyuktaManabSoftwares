using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GrocerySupplyManagementApp.Tests.UnitTests.Services
{
    [TestClass]
    public class ShareMemberServiceTest
    {
        private Mock<IShareMemberRepository> _shareMemberRepository;
        private ShareMemberService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _shareMemberRepository = new Mock<IShareMemberRepository>();
            _sut = new ShareMemberService(_shareMemberRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ShareMemberService")]
        public void GetShareMember_ReturnsShareMember_WhenIdIsPassed()
        {
            long id = 1;
            _shareMemberRepository.Setup(repo => repo.GetShareMember(It.IsAny<long>()))
                .Returns(
                new ShareMember() { Id = 1, EndOfDay = "2078-01-01", Name = "ShareMember1", Address = "Address1", ContactNo = 9999999999, ImagePath = @"D:\Images\ShareMember1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var shareMember = _sut.GetShareMember(id);

            Assert.AreEqual("ShareMember1", shareMember.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ShareMemberService")]
        public void AddShareMember_ReturnsShareMember_WhenShareMemberIsPassed()
        {
            _shareMemberRepository.Setup(repo => repo.AddShareMember(It.IsAny<ShareMember>()))
                .Returns(
                new ShareMember() { Id = 1, EndOfDay = "2078-01-01", Name = "ShareMember1", Address = "Address1", ContactNo = 9999999999, ImagePath = @"D:\Images\ShareMember1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var shareMember = _sut.AddShareMember(new ShareMember());

            Assert.AreEqual("ShareMember1", shareMember.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ShareMemberService")]
        public void UpdateShareMember_ReturnsShareMember_WhenIdAndShareMemberArePassed()
        {
            long id = 1;
            _shareMemberRepository.Setup(repo => repo.UpdateShareMember(It.IsAny<long>(), It.IsAny<ShareMember>()))
                .Returns(
                new ShareMember() { Id = 1, EndOfDay = "2078-01-01", Name = "ShareMember1", Address = "Address1", ContactNo = 9999999999, ImagePath = @"D:\Images\ShareMember1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var shareMember = _sut.UpdateShareMember(id, new ShareMember());

            Assert.AreEqual("ShareMember1", shareMember.Name);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.ShareMemberService")]
        public void DeleteShareMember_ReturnsTrue_WhenIdIsPassed()
        {
            long id = 1;
            _shareMemberRepository.Setup(repo => repo.DeleteShareMember(It.IsAny<long>()))
                .Returns(true);

            var result = _sut.DeleteShareMember(id);

            Assert.IsTrue(result);
        }
    }
}
