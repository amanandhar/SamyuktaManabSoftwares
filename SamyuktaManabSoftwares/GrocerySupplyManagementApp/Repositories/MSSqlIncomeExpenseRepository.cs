using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlIncomeExpenseRepository : IIncomeExpenseRepository
    {
        private readonly string connectionString;

        public MSSqlIncomeExpenseRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public decimal GetTotalIncome(string endOfDay)
        {
            try
            {
                var totalPurchaseBonus = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.PURCHASE_BONUS });
                var totalDeliveryCharge = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.DELIVERY_CHARGE });
                var totalMemberFee = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.MEMBER_FEE });
                var totalOtherIncome = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.OTHER_INCOME });
                var totalSalesProfit = GetSalesProfit(new IncomeTransactionFilter() { DateTo = endOfDay }).ToList().Sum(x => x.Amount);
                var totalStockAdjustment = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, Income = Constants.STOCK_ADJUSTMENT });

                var totalIncome = totalPurchaseBonus + totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit + totalStockAdjustment;

                return totalIncome;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetTotalExpense(string endOfDay)
        {
            try
            {
                var totalAsset = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.ASSET });
                var totalDeliveryCharge = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.DELIVERY_CHARGE });
                var totalElectricity = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.ELECTRICITY });
                var totalFuelAndTransportation = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.FUEL_TRANSPORTATION });
                var totalGuestHospitality = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.GUEST_HOSPITALITY });
                var totalLoanInterest = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.LOAN_INTEREST });
                var totalMiscellaneous = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.MISCELLANEOUS });
                var totalOfficeRent = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.OFFICE_RENT });
                var totalRepairMaintenance = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.REPAIR_MAINTENANCE });
                var totalSalesDiscount = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.SALES_DISCOUNT });
                var totalSalesReturn = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.SALES_RETURN });
                var totalStaffAllowance = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.STAFF_ALLOWANCE });
                var totalStaffSalary = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.STAFF_SALARY });
                var totalStockAdjustment = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.STOCK_ADJUSTMENT });
                var totalTelephoneInternet = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, Expense = Constants.TELEPHONE_INTERNET });

                var totalExpense = totalAsset + totalDeliveryCharge + totalElectricity + totalFuelAndTransportation + totalGuestHospitality
                    + totalLoanInterest + totalMiscellaneous + totalOfficeRent + totalRepairMaintenance + totalSalesDiscount
                    + totalSalesReturn + totalStaffAllowance + totalStaffSalary + totalStockAdjustment + totalTelephoneInternet;

                return totalExpense;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetTotalIncome(IncomeTransactionFilter incomeTransactionFilter)
        {
            try
            {
                decimal total = 0.00m;
                string query = @"SELECT " +
                        "SUM([DueReceivedAmount] + [ReceivedAmount])" +
                        "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                        "WHERE 1 = 1 " +
                        "AND ISNULL([Action], '') = '" + Constants.INCOME + "' ";

                if (!string.IsNullOrWhiteSpace(incomeTransactionFilter?.DateFrom))
                {
                    query += " AND [EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrWhiteSpace(incomeTransactionFilter?.DateTo))
                {
                    query += " AND [EndOfDay] <= @DateTo ";
                }

                if (!string.IsNullOrWhiteSpace(incomeTransactionFilter?.Income))
                {
                    query += " AND ISNULL([Income], '') = @Income ";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Income", ((object)incomeTransactionFilter?.Income) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            total = Convert.ToDecimal(result.ToString());
                        }
                    }
                }

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter)
        {
            try
            {
                decimal total = 0.00m;
                string query = @"SELECT " +
                        "SUM([DuePaymentAmount] + [PaymentAmount])" +
                        "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                        "WHERE 1 = 1 " +
                        "AND ISNULL([Action], '') = '" + Constants.EXPENSE + "' ";

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateFrom))
                {
                    query += " AND [EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateTo))
                {
                    query += " AND [EndOfDay] <= @DateTo ";
                }

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.Expense))
                {
                    query += " AND ISNULL([Expense], '') = @Expense ";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Expense", ((object)expenseTransactionFilter?.Expense) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            total = Convert.ToDecimal(result.ToString());
                        }
                    }
                }

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<IncomeTransactionView> GetIncomeTransactions(IncomeTransactionFilter incomeTransactionFilter)
        {
            try
            {
                var incomeDetails = new List<IncomeTransactionView>();
                var query = @"SELECT " +
                    "[Id], [EndOfDay], [Income], [Bank], [ReceivedAmount] AS [Amount], [AddedDate] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND ISNULL([Action], '') = '" + Constants.INCOME + "' ";

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateFrom))
                {
                    query += "AND [EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateTo))
                {
                    query += "AND [EndOfDay] <= @DateTo ";
                }

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.Income))
                {
                    query += "AND ISNULL([Income], '') = @Income ";
                }

                query += "ORDER BY [Id] ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Income", ((object)incomeTransactionFilter.Income) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Income"].ToString(),
                                    InvoiceNo = reader.IsDBNull(3) ? string.Empty : reader["InvoiceNo"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = reader["Bank"].ToString(),
                                    Quantity = 0.00m,
                                    Profit = 0.00m,
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }

                return incomeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter)
        {
            try
            {
                var expenseTransactionViews = new List<ExpenseTransactionView>();
                var query = @"SELECT " +
                    "[Id], [EndOfDay], [Action], " +
                    "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [Bank] ELSE [ActionType] END AS [ActionType], " +
                    "[Expense], [Narration], [DuePaymentAmount], [PaymentAmount], " +
                    "(ISNULL([DuePaymentAmount], 0) - ISNULL([PaymentAmount], 0)) AS [Amount] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Action] = '" + Constants.EXPENSE + "' ";


                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateFrom))
                {
                    query += " AND [EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateTo))
                {
                    query += " AND [EndOfDay] <= @DateTo ";
                }

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.Expense))
                {
                    query += " AND [Expense] = @Expense ";
                }

                query += "ORDER BY [Id] ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Expense", ((object)expenseTransactionFilter?.Expense) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var expenseTransactionView = new ExpenseTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Expense = reader["Expense"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    DuePaymentAmount = Convert.ToDecimal(reader["DuePaymentAmount"].ToString()),
                                    PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                expenseTransactionViews.Add(expenseTransactionView);
                            }
                        }
                    }
                }

                return expenseTransactionViews; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<IncomeTransactionView> GetSalesProfit(IncomeTransactionFilter incomeTransactionFilter)
        {
            try
            {
                var incomeDetails = new List<IncomeTransactionView>();
                var query = @"SELECT " +
                    "si.[Id] AS [Id], si.[EndOfDay] AS [EndOfDay], " +
                    "'" + Constants.SALES_PROFIT + "' AS [Description], si.[InvoiceNo] AS [InvoiceNo], " +
                    "i.[Code] AS [ItemCode], i.[Name] AS [ItemName], " +
                    "si.[Quantity] AS [Quantity], si.[Profit] AS [Profit], " +
                    "CAST((si.[Quantity] * si.[Profit]) AS DECIMAL(18, 2)) AS [Amount], si.[AddedDate] AS [AddedDate] " +
                    "FROM " + Constants.TABLE_ITEM + " i " +
                    "INNER JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                    "ON i.[Id] = si.[ItemId] " +
                    "WHERE 1 = 1 ";

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateFrom))
                {
                    query += "AND si.[EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateTo))
                {
                    query += "AND si.[EndOfDay] <= @DateTo ";
                }

                query += "ORDER BY si.[AddedDate] DESC ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter?.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Profit = Convert.ToDecimal(reader["Profit"].ToString()),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }

                return incomeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    }
}
