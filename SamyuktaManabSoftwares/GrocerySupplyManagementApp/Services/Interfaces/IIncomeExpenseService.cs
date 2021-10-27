using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IIncomeExpenseService
    {
        decimal GetTotalIncome(string endOfDay);
        decimal GetTotalExpense(string endOfDay);
        decimal GetTotalIncome(IncomeTransactionFilter incomeTransactionFilter);
        decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter);
        IEnumerable<IncomeTransactionView> GetIncomeTransactions(IncomeTransactionFilter incomeTransactionFilter);
        IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter);
        IEnumerable<IncomeTransactionView> GetSalesProfit(IncomeTransactionFilter incomeTransactionFilter);
        decimal GetTotalDeliveryCharge(IncomeTransactionFilter incomeTransactionFilter);
        IEnumerable<IncomeTransactionView> GetDeliveryChargeTransactions(IncomeTransactionFilter incomeTransactionFilter);
        decimal GetTotalSalesDiscount(ExpenseTransactionFilter expenseTransactionFilter);
        IEnumerable<ExpenseTransactionView> GetSalesDiscountTransactions(ExpenseTransactionFilter expenseTransactionFilter);
    }
}
