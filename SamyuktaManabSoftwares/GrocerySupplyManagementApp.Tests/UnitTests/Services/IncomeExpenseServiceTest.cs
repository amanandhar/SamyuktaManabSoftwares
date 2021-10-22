using GrocerySupplyManagementApp.DTOs;
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
    public class IncomeExpenseServiceTest
    {
        private Mock<IIncomeExpenseRepository> _incomeExpenseRepository;
        private IncomeExpenseService _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _incomeExpenseRepository = new Mock<IIncomeExpenseRepository>();
            _sut = new IncomeExpenseService(_incomeExpenseRepository.Object);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.IncomeExpenseService")]
        public void GetTotalIncome_ReturnsTotalIncome_WhenEndOfDayIsPassed()
        {
            _incomeExpenseRepository.Setup(repo => repo.GetTotalIncome(It.IsAny<string>()))
                .Returns(101.01m);

            var totalIncome = _sut.GetTotalIncome(string.Empty);

            Assert.AreEqual(101.01m, totalIncome);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.IncomeExpenseService")]
        public void GetTotalExpense_ReturnsTotalExpense_WhenEndOfDayIsPassed()
        {
            _incomeExpenseRepository.Setup(repo => repo.GetTotalExpense(It.IsAny<string>()))
                .Returns(202.02m);

            var totalExpense = _sut.GetTotalExpense(string.Empty);

            Assert.AreEqual(202.02m, totalExpense);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.IncomeExpenseService")]
        public void GetTotalIncome_ReturnsTotalIncome_WhenIncomeTransactionFilterIsPassed()
        {
            _incomeExpenseRepository.Setup(repo => repo.GetTotalIncome(It.IsAny<IncomeTransactionFilter>()))
                .Returns(303.03m);

            var totalIncome = _sut.GetTotalIncome(new IncomeTransactionFilter());

            Assert.AreEqual(303.03m, totalIncome);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.IncomeExpenseService")]
        public void GetTotalExpense_ReturnsTotalExpense_WhenExpenseTransactionFilterIsPassed()
        {
            _incomeExpenseRepository.Setup(repo => repo.GetTotalExpense(It.IsAny<ExpenseTransactionFilter>()))
                .Returns(404.04m);

            var totalExpense = _sut.GetTotalExpense(new ExpenseTransactionFilter());

            Assert.AreEqual(404.04m, totalExpense);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.IncomeExpenseService")]
        public void GetIncomeTransactions_ReturnsIncomeTransactionViews_WhenIncomeTransactionFilterIsPassed()
        {
            _incomeExpenseRepository.Setup(repo => repo.GetIncomeTransactions(It.IsAny<IncomeTransactionFilter>()))
                .Returns(new List<IncomeTransactionView>() { 
                    new IncomeTransactionView() { 
                        Id = 1, 
                        EndOfDay = "2078-01-01", 
                        Description = "Test1",
                        InvoiceNo = "TestInvoiceNo1",
                        ItemCode = "TestItemCode1",
                        ItemName = "TestItemName1",
                        Quantity = 1.00m,
                        Profit = 10.00m,
                        Amount = 110.00m,
                        AddedDate = DateTime.Parse("2021-01-01")
                    },
                    new IncomeTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Description = "Test2",
                        InvoiceNo = "TestInvoiceNo2",
                        ItemCode = "TestItemCode2",
                        ItemName = "TestItemName2",
                        Quantity = 2.00m,
                        Profit = 20.00m,
                        Amount = 220.00m,
                        AddedDate = DateTime.Parse("2021-01-02")
                    }
                });

            var incomeTransactions = _sut.GetIncomeTransactions(new IncomeTransactionFilter());

            Assert.AreEqual(2, incomeTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.IncomeExpenseService")]
        public void GetExpenseTransactions_ReturnsExpenseTransactionViews_WhenExpenseTransactionFilterIsPassed()
        {
            _incomeExpenseRepository.Setup(repo => repo.GetExpenseTransactions(It.IsAny<ExpenseTransactionFilter>()))
                .Returns(new List<ExpenseTransactionView>() {
                    new ExpenseTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Action = "Expense",
                        ActionType = Constants.CASH,
                        Expense = "Assets",
                        Narration = "Assets",
                        Amount = 110.00m
                    },
                    new ExpenseTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Action = "Expense",
                        ActionType = Constants.CHEQUE,
                        Expense = "Electricity",
                        Narration = "Electricity",
                        Amount = 220.00m
                    }
                });

            var expenseTransactions = _sut.GetExpenseTransactions(new ExpenseTransactionFilter());

            Assert.AreEqual(2, expenseTransactions.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTests"), TestCategory("Services.IncomeExpenseService")]
        public void GetSalesProfit_ReturnsIncomeTransactionViews_WhenIncomeTransactionFilterIsPassed()
        {
            _incomeExpenseRepository.Setup(repo => repo.GetSalesProfit(It.IsAny<IncomeTransactionFilter>()))
                .Returns(new List<IncomeTransactionView>() {
                    new IncomeTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Description = "Test1",
                        InvoiceNo = "TestInvoiceNo1",
                        ItemCode = "TestItemCode1",
                        ItemName = "TestItemName1",
                        Quantity = 1.00m,
                        Profit = 10.00m,
                        Amount = 110.00m,
                        AddedDate = DateTime.Parse("2021-01-01")
                    },
                    new IncomeTransactionView() {
                        Id = 1,
                        EndOfDay = "2078-01-01",
                        Description = "Test2",
                        InvoiceNo = "TestInvoiceNo2",
                        ItemCode = "TestItemCode2",
                        ItemName = "TestItemName2",
                        Quantity = 2.00m,
                        Profit = 20.00m,
                        Amount = 220.00m,
                        AddedDate = DateTime.Parse("2021-01-02")
                    }
                });

            var incomeTransactions = _sut.GetSalesProfit(new IncomeTransactionFilter());

            Assert.AreEqual(2, incomeTransactions.ToList().Count);
        }
    }
}
