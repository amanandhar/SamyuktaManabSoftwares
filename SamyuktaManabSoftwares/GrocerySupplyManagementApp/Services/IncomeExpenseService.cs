using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class IncomeExpenseService : IIncomeExpenseService
    {
        private readonly IIncomeExpenseRepository _incomeExpenseRepository;

        public IncomeExpenseService(IIncomeExpenseRepository incomeExpenseRepository)
        {
            _incomeExpenseRepository = incomeExpenseRepository;
        }

        public decimal GetTotalIncome(string endOfDay)
        {
            return _incomeExpenseRepository.GetTotalIncome(endOfDay);
        }

        public decimal GetTotalExpense(string endOfDay)
        {
            return _incomeExpenseRepository.GetTotalExpense(endOfDay);
        }

        public decimal GetTotalIncome(IncomeTransactionFilter incomeTransactionFilter)
        {
            return _incomeExpenseRepository.GetTotalIncome(incomeTransactionFilter);
        }

        public decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter)
        {
            return _incomeExpenseRepository.GetTotalExpense(expenseTransactionFilter);
        }

        public IEnumerable<IncomeTransactionView> GetIncomeTransactions(IncomeTransactionFilter incomeTransactionFilter)
        {
            return _incomeExpenseRepository.GetIncomeTransactions(incomeTransactionFilter);
        }

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter)
        {
            return _incomeExpenseRepository.GetExpenseTransactions(expenseTransactionFilter);
        }

        public IEnumerable<IncomeTransactionView> GetSalesProfit(IncomeTransactionFilter incomeTransactionFilter)
        {
            return _incomeExpenseRepository.GetSalesProfit(incomeTransactionFilter);
        }

        public decimal GetTotalDeliveryCharge(IncomeTransactionFilter incomeTransactionFilter)
        {
            return _incomeExpenseRepository.GetTotalDeliveryCharge(incomeTransactionFilter);
        }

        public IEnumerable<IncomeTransactionView> GetDeliveryChargeTransactions(IncomeTransactionFilter incomeTransactionFilter)
        {
            return _incomeExpenseRepository.GetDeliveryChargeTransactions(incomeTransactionFilter);
        }

        public decimal GetTotalSalesDiscount(ExpenseTransactionFilter expenseTransactionFilter)
        {
            return _incomeExpenseRepository.GetTotalSalesDiscount(expenseTransactionFilter);
        }

        public IEnumerable<ExpenseTransactionView> GetSalesDiscountTransactions(ExpenseTransactionFilter expenseTransactionFilter)
        {
            return _incomeExpenseRepository.GetSalesDiscountTransactions(expenseTransactionFilter);
        }
    }
}
