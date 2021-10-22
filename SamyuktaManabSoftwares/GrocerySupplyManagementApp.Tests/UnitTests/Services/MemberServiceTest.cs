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
    public class MemberServiceTest
    {
        private Mock<IMemberRepository> _memberRepository;
        private MemberService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _memberRepository = new Mock<IMemberRepository>();
            _sut = new MemberService(_memberRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.MemberService")]
        public void GetMembers_ReturnsMembers()
        {
            _memberRepository.Setup(repo => repo.GetMembers())
                .Returns(new List<Member>() {
                new Member() { Id = 1, EndOfDay = "2078-01-01", Counter = 1, MemberId = "M0001", Name = "Name1", Address = "Address1", ContactNo = 1234567890, Email = "test1@gmail.com", AccountNo = "TestAccNo1" , ImagePath = @"D:\Images\Member1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null },
                new Member() { Id = 2, EndOfDay = "2078-02-02", Counter = 2, MemberId = "M0002", Name = "Name2", Address = "Address2", ContactNo = 9999999999, Email = "test2@gmail.com", AccountNo = "TestAccNo2" , ImagePath = @"D:\Images\Member2.jpg", AddedBy = "TestUser2", AddedDate = DateTime.Parse("2078-02-02"), UpdatedBy = null, UpdatedDate = null }
            });

            var members = _sut.GetMembers();

            Assert.AreEqual(2, members.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.MemberService")]
        public void GetMember_ReturnsMember_WhenMemberIdIsPassed()
        {
            _memberRepository.Setup(repo => repo.GetMember(It.IsAny<string>()))
                .Returns(
                new Member() { Id = 1, EndOfDay = "2078-01-01", Counter = 1, MemberId = "M0001", Name = "Name1", Address = "Address1", ContactNo = 1234567890, Email = "test1@gmail.com", AccountNo = "TestAccNo1" , ImagePath = @"D:\Images\Member1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var member = _sut.GetMember(string.Empty);

            Assert.AreEqual("M0001", member.MemberId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.MemberService")]
        public void AddMember_ReturnsMember_WhenMemberIsPassed()
        {
            _memberRepository.Setup(repo => repo.AddMember(It.IsAny<Member>()))
                .Returns(
                new Member() { Id = 1, EndOfDay = "2078-01-01", Counter = 1, MemberId = "M0001", Name = "Name1", Address = "Address1", ContactNo = 1234567890, Email = "test1@gmail.com", AccountNo = "TestAccNo1", ImagePath = @"D:\Images\Member1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var member = _sut.AddMember(new Member());

            Assert.AreEqual("M0001", member.MemberId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.MemberService")]
        public void UpdateMember_ReturnsMember_WhenMemberIdAndMemberArePassed()
        {
            string memberId = "M0001";
            _memberRepository.Setup(repo => repo.UpdateMember(It.IsAny<string>(), It.IsAny<Member>()))
                .Returns(
                new Member() { Id = 1, EndOfDay = "2078-01-01", Counter = 1, MemberId = "M0001", Name = "Name1", Address = "Address1", ContactNo = 1234567890, Email = "test1@gmail.com", AccountNo = "TestAccNo1", ImagePath = @"D:\Images\Member1.jpg", AddedBy = "TestUser1", AddedDate = DateTime.Parse("2078-01-01"), UpdatedBy = null, UpdatedDate = null }
            );

            var member = _sut.UpdateMember(memberId, new Member());

            Assert.AreEqual("M0001", member.MemberId);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.MemberService")]
        public void DeleteMember_ReturnsTrue_WhenMemberIdIsPassed()
        {
            string memberId = "M0001";
            _memberRepository.Setup(repo => repo.DeleteMember(It.IsAny<string>()))
                .Returns(true);

            var result = _sut.DeleteMember(memberId);

            Assert.IsTrue(result);
        }
    }
}
