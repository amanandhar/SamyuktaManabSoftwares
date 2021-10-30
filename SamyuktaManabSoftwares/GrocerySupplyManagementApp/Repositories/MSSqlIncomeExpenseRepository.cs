using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlIncomeExpenseRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public decimal GetTotalIncome(string endOfDay)
        {
            var totalIncome = Constants.DEFAULT_DECIMAL_VALUE;

            try
            {
                var totalDeliveryCharge = GetTotalDeliveryCharge(new IncomeTransactionFilter() { DateTo = endOfDay });
                var totalMemberFee = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, IncomeType = Constants.MEMBER_FEE });
                var totalOtherIncome = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, IncomeType = Constants.OTHER_INCOME });
                var totalSalesProfit = GetSalesProfit(new IncomeTransactionFilter() { DateTo = endOfDay }).ToList().Sum(x => x.Amount);
                var totalStockAdjustment = GetTotalIncome(new IncomeTransactionFilter() { DateTo = endOfDay, IncomeType = Constants.STOCK_ADJUSTMENT });

                totalIncome = totalDeliveryCharge + totalMemberFee + totalOtherIncome + totalSalesProfit + totalStockAdjustment;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalIncome;
        }

        public decimal GetTotalExpense(string endOfDay)
        {
            var totalExpense = Constants.DEFAULT_DECIMAL_VALUE;

            try
            {
                var totalAsset = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.ASSET });
                var totalElectricity = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.ELECTRICITY });
                var totalFuelAndTransportation = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.FUEL_TRANSPORTATION });
                var totalGuestHospitality = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.GUEST_HOSPITALITY });
                var totalLoanInterest = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.LOAN_INTEREST });
                var totalMiscellaneous = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.MISCELLANEOUS });
                var totalOfficeRent = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.OFFICE_RENT });
                var totalRepairMaintenance = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.REPAIR_MAINTENANCE });
                var totalSalesDiscount = GetTotalSalesDiscount(new ExpenseTransactionFilter() { DateTo = endOfDay });
                var totalSalesReturn = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.SALES_RETURN });
                var totalStaffAllowance = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.STAFF_ALLOWANCE });
                var totalStaffSalary = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.STAFF_SALARY });
                var totalStockAdjustment = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.STOCK_ADJUSTMENT });
                var totalTelephoneInternet = GetTotalExpense(new ExpenseTransactionFilter() { DateTo = endOfDay, ExpenseType = Constants.TELEPHONE_INTERNET });

                totalExpense = totalAsset + totalElectricity + totalFuelAndTransportation + totalGuestHospitality
                    + totalLoanInterest + totalMiscellaneous + totalOfficeRent + totalRepairMaintenance + totalSalesDiscount
                    + totalSalesReturn + totalStaffAllowance + totalStaffSalary + totalStockAdjustment + totalTelephoneInternet;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalExpense;
        }

        public decimal GetTotalIncome(IncomeTransactionFilter incomeTransactionFilter)
        {
            var totalIncome = Constants.DEFAULT_DECIMAL_VALUE;

            try
            {
                string query = @"SELECT " +
                        "SUM([ReceivedAmount])" +
                        "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
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

                if (!string.IsNullOrWhiteSpace(incomeTransactionFilter?.IncomeType))
                {
                    query += " AND ISNULL([Type], '') = @Type ";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)incomeTransactionFilter?.IncomeType) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalIncome = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalIncome;
        }

        public decimal GetTotalExpense(ExpenseTransactionFilter expenseTransactionFilter)
        {
            var totalExpense = Constants.DEFAULT_DECIMAL_VALUE;

            try
            {
                string query = @"SELECT " +
                        "SUM([PaymentAmount])" +
                        "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
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

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.ExpenseType))
                {
                    query += " AND ISNULL([Type], '') = @Type ";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)expenseTransactionFilter?.ExpenseType) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalExpense = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalExpense;
        }

        public IEnumerable<IncomeTransactionView> GetIncomeTransactions(IncomeTransactionFilter incomeTransactionFilter)
        {
            List<IncomeTransactionView> incomeDetails;

            try
            {
                incomeDetails = new List<IncomeTransactionView>();
                var query = @"SELECT " +
                    "[Id], [EndOfDay], [BankName], [Type], [Narration], [ReceivedAmount], [AddedDate] " +
                    "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
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

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.IncomeType))
                {
                    query += "AND ISNULL([Type], '') = @Type ";
                }

                query += "ORDER BY [AddedDate] DESC ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)incomeTransactionFilter.IncomeType) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Type"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    BankName = reader["BankName"].ToString(),
                                    ItemCode = string.Empty,
                                    ItemName = string.Empty,
                                    Amount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return incomeDetails;
        }

        public IEnumerable<ExpenseTransactionView> GetExpenseTransactions(ExpenseTransactionFilter expenseTransactionFilter)
        {
            List<ExpenseTransactionView> expenseTransactionViews;
            try
            {
                expenseTransactionViews = new List<ExpenseTransactionView>();
                var query = @"SELECT " +
                    "[Id], [EndOfDay], [Type], [Narration], " +
                    "CASE WHEN [ActionType] = '" + Constants.CHEQUE + "' THEN [ActionType] + ' - ' + [BankName] ELSE [ActionType] END AS [ActionType], " +
                    "[PaymentAmount], [AddedDate] " +
                    "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
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

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.ExpenseType))
                {
                    query += " AND ISNULL([Type], '') = @Type ";
                }

                query += "ORDER BY [AddedDate] DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)expenseTransactionFilter?.ExpenseType) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var expenseTransactionView = new ExpenseTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = reader["Type"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    ActionType = reader["ActionType"].ToString(),
                                    Amount = Convert.ToDecimal(reader["PaymentAmount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                expenseTransactionViews.Add(expenseTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return expenseTransactionViews;
        }

        public IEnumerable<IncomeTransactionView> GetSalesProfit(IncomeTransactionFilter incomeTransactionFilter)
        {
            List<IncomeTransactionView> incomeDetails;
            try
            {
                incomeDetails = new List<IncomeTransactionView>();
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
                                    Narration = string.Empty,
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    BankName = string.Empty,
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return incomeDetails;
        }

        public decimal GetTotalDeliveryCharge(IncomeTransactionFilter incomeTransactionFilter)
        {
            var total = Constants.DEFAULT_DECIMAL_VALUE;

            try
            {
                string query = @"SELECT " +
                        "SUM([DeliveryCharge])" +
                        "FROM " + Constants.TABLE_POS_DETAIL + " " +
                        "WHERE 1 = 1 ";

                if (!string.IsNullOrWhiteSpace(incomeTransactionFilter?.DateFrom))
                {
                    query += " AND [EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrWhiteSpace(incomeTransactionFilter?.DateTo))
                {
                    query += " AND [EndOfDay] <= @DateTo ";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter?.DateTo) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            total = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return total;
        }

        public IEnumerable<IncomeTransactionView> GetDeliveryChargeTransactions(IncomeTransactionFilter incomeTransactionFilter)
        {
            List<IncomeTransactionView> incomeDetails;

            try
            {
                incomeDetails = new List<IncomeTransactionView>();
                var query = @"SELECT " +
                    "pd.[Id], pd.[EndOfDay], pd.[InvoiceNo], pd.[DeliveryCharge], ut.[AddedDate] " +
                    "FROM " + Constants.TABLE_POS_DETAIL + " pd " +
                    "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                    "ON pd.[UserTransactionId] = ut.[Id] " +
                    "WHERE 1 = 1 " +
                    "AND pd.[DeliveryCharge] != 0.00 ";

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateFrom))
                {
                    query += "AND pd.[EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrEmpty(incomeTransactionFilter?.DateTo))
                {
                    query += "AND pd.[EndOfDay] <= @DateTo ";
                }

                query += "ORDER BY ut.[AddedDate] DESC ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)incomeTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)incomeTransactionFilter.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var incomeDetail = new IncomeTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = Constants.DELIVERY_CHARGE,
                                    Narration = string.Empty,
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    BankName = string.Empty,
                                    ItemCode = string.Empty,
                                    ItemName = string.Empty,
                                    Amount = Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return incomeDetails;
        }

        public decimal GetTotalSalesDiscount(ExpenseTransactionFilter expenseTransactionFilter)
        {
            var total = Constants.DEFAULT_DECIMAL_VALUE;

            try
            {
                string query = @"SELECT " +
                        "SUM([Discount])" +
                        "FROM " + Constants.TABLE_POS_DETAIL + " " +
                        "WHERE 1 = 1 ";

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateFrom))
                {
                    query += " AND [EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrWhiteSpace(expenseTransactionFilter?.DateTo))
                {
                    query += " AND [EndOfDay] <= @DateTo ";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            total = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return total;
        }

        public IEnumerable<ExpenseTransactionView> GetSalesDiscountTransactions(ExpenseTransactionFilter expenseTransactionFilter)
        {
            List<ExpenseTransactionView> expenseTransactionViews;
            try
            {
                expenseTransactionViews = new List<ExpenseTransactionView>();
                var query = @"SELECT " +
                    "pd.[Id], pd.[EndOfDay], ut.[ActionType], pd.[Discount], ut.[AddedDate] " +
                    "FROM " + Constants.TABLE_POS_DETAIL + " pd " +
                    "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                    "ON pd.[UserTransactionId] = ut.[Id] " +
                    "WHERE 1 = 1 " +
                    "AND pd.[Discount] != 0.00 ";

                if (!string.IsNullOrEmpty(expenseTransactionFilter?.DateFrom))
                {
                    query += "AND pd.[EndOfDay] >= @DateFrom ";
                }

                if (!string.IsNullOrEmpty(expenseTransactionFilter?.DateTo))
                {
                    query += "AND pd.[EndOfDay] <= @DateTo ";
                }

                query += "ORDER BY ut.[AddedDate] DESC ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)expenseTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)expenseTransactionFilter?.DateTo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var expenseTransactionView = new ExpenseTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Description = Constants.SALES_DISCOUNT,
                                    Narration = string.Empty,
                                    ActionType = reader["ActionType"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Discount"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString())
                                };

                                expenseTransactionViews.Add(expenseTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return expenseTransactionViews;
        }

        public IncomeExpense GetLastIncomeExpense(string type, string addedBy)
        {
            var incomeExpense = new IncomeExpense();
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id], [EndOfDay], [Action], [ActionType], " +
                "[BankName], [Type], [Narration], " +
                "[ReceivedAmount], [PaymentAmount], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
                "WHERE 1 = 1 ";

            if (type == Constants.INCOME)
            {
                query += "AND ISNULL([Action], '') = '" + Constants.INCOME + "' ";
            }
            else
            {
                query += "AND ISNULL([Action], '') = '" + Constants.EXPENSE + "' ";
            }

            if (!string.IsNullOrWhiteSpace(addedBy))
            {
                query += "AND ISNULL([AddedBy], '') = @AddedBy ";
            }

            query += "ORDER BY [Id] DESC ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AddedBy", ((object)addedBy) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                incomeExpense.Id = Convert.ToInt64(reader["Id"].ToString());
                                incomeExpense.EndOfDay = reader["EndOfDay"].ToString();
                                incomeExpense.Action = reader["Action"].ToString();
                                incomeExpense.ActionType = reader["ActionType"].ToString();
                                incomeExpense.BankName = reader["BankName"].ToString();
                                incomeExpense.Type = reader["Type"].ToString();
                                incomeExpense.Narration = reader["Narration"].ToString();
                                incomeExpense.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                incomeExpense.PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString());
                                incomeExpense.AddedBy = reader["AddedBy"].ToString();
                                incomeExpense.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                incomeExpense.UpdatedBy = reader["UpdatedBy"].ToString();
                                incomeExpense.UpdatedDate = reader.IsDBNull(12) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return incomeExpense;
        }

        public IncomeExpense AddIncomeExpense(IncomeExpense incomeExpense)
        {
            string query = "INSERT INTO " + Constants.TABLE_INCOME_EXPENSE + " " +
                    "(" +
                        "[EndOfDay], [Action], [ActionType], " +
                        "[BankName], [Type], [Narration], " +
                        "[ReceivedAmount], [PaymentAmount], " +
                        "[AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Action, @ActionType, " +
                        "@BankName, @Type, @Narration, " +
                        "@ReceivedAmount, @PaymentAmount, " +
                        "@AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", incomeExpense.EndOfDay);
                        command.Parameters.AddWithValue("@Action", incomeExpense.Action);
                        command.Parameters.AddWithValue("@ActionType", incomeExpense.ActionType);
                        command.Parameters.AddWithValue("@BankName", ((object)incomeExpense.BankName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)incomeExpense.Type) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)incomeExpense.Narration) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ReceivedAmount", ((object)incomeExpense.ReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@PaymentAmount", ((object)incomeExpense.PaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@AddedBy", incomeExpense.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", incomeExpense.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return incomeExpense;
        }

        // Atomic Transaction
        public IncomeExpense AddIncome(IncomeExpense incomeExpense, BankTransaction bankTransaction, string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Insert into income expense table
                        string insertIncomeExpense = "INSERT INTO " + Constants.TABLE_INCOME_EXPENSE + " " +
                            "(" +
                                "[EndOfDay], [Action], [ActionType], " +
                                "[BankName], [Type], [Narration], " +
                                "[ReceivedAmount], [PaymentAmount], " +
                                "[AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @Action, @ActionType, " +
                                "@BankName, @Type, @Narration, " +
                                "@ReceivedAmount, @PaymentAmount, " +
                                "@AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertIncomeExpense, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", incomeExpense.EndOfDay);
                            command.Parameters.AddWithValue("@Action", incomeExpense.Action);
                            command.Parameters.AddWithValue("@ActionType", incomeExpense.ActionType);
                            command.Parameters.AddWithValue("@BankName", ((object)incomeExpense.BankName) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Type", ((object)incomeExpense.Type) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Narration", ((object)incomeExpense.Narration) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@ReceivedAmount", ((object)incomeExpense.ReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@PaymentAmount", ((object)incomeExpense.PaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@AddedBy", incomeExpense.AddedBy);
                            command.Parameters.AddWithValue("@AddedDate", incomeExpense.AddedDate);

                            command.ExecuteNonQuery();
                        }

                        // Get last id from income expense table
                        long lastIncomeExpenseId = 0;
                        var selectLastIncomeExpense = @"SELECT " +
                            "TOP 1 " +
                            "[Id], [EndOfDay], [Action], [ActionType], " +
                            "[BankName], [Type], [Narration], " +
                            "[ReceivedAmount], [PaymentAmount], " +
                            "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                            "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
                            "WHERE 1 = 1 " +
                            "AND ISNULL([Action], '') = '" + Constants.INCOME + "' " +
                            "AND ISNULL([AddedBy], '') = @AddedBy " +
                            "ORDER BY [Id] DESC ";

                        using (SqlCommand command = new SqlCommand(selectLastIncomeExpense, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@AddedBy", ((object)username) ?? DBNull.Value);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lastIncomeExpenseId = Convert.ToInt64(reader["Id"].ToString());
                                }
                            }
                        }

                        // Insert into bank transaction table
                        bankTransaction.TransactionId = lastIncomeExpenseId;
                        string insertBankTransaction = @"INSERT INTO " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "( " +
                                "[EndOfDay], [BankId], [Type], [Action], [TransactionId], [Debit], [Credit], [Narration], [AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @BankId, @Type, @Action, @TransactionId, @Debit, @Credit, @Narration, @AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", ((object)bankTransaction.EndOfDay) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Type", ((object)bankTransaction.Type) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Action", ((object)bankTransaction.Action) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@TransactionId", ((object)bankTransaction.TransactionId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Debit", ((object)bankTransaction.Debit) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@Credit", ((object)bankTransaction.Credit) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@Narration", ((object)bankTransaction.Narration) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AddedBy", ((object)bankTransaction.AddedBy) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AddedDate", ((object)bankTransaction.AddedDate) ?? DBNull.Value);

                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                    }
                    catch
                    {
                        incomeExpense = null;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return incomeExpense;
        }

        // Atomic Transaction
        public IncomeExpense AddExpense(IncomeExpense incomeExpense, BankTransaction bankTransaction, string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Insert into income expense table
                        string insertIncomeExpense = "INSERT INTO " + Constants.TABLE_INCOME_EXPENSE + " " +
                            "(" +
                                "[EndOfDay], [Action], [ActionType], " +
                                "[BankName], [Type], [Narration], " +
                                "[ReceivedAmount], [PaymentAmount], " +
                                "[AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @Action, @ActionType, " +
                                "@BankName, @Type, @Narration, " +
                                "@ReceivedAmount, @PaymentAmount, " +
                                "@AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertIncomeExpense, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", incomeExpense.EndOfDay);
                            command.Parameters.AddWithValue("@Action", incomeExpense.Action);
                            command.Parameters.AddWithValue("@ActionType", incomeExpense.ActionType);
                            command.Parameters.AddWithValue("@BankName", ((object)incomeExpense.BankName) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Type", ((object)incomeExpense.Type) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Narration", ((object)incomeExpense.Narration) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@ReceivedAmount", ((object)incomeExpense.ReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@PaymentAmount", ((object)incomeExpense.PaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@AddedBy", incomeExpense.AddedBy);
                            command.Parameters.AddWithValue("@AddedDate", incomeExpense.AddedDate);

                            command.ExecuteNonQuery();
                        }

                        // Get last row from income expense table
                        var lastIncomeExpense = new IncomeExpense();
                        var selectLastIncomeExpense = @"SELECT " +
                            "TOP 1 " +
                            "[Id], [EndOfDay], [Action], [ActionType], " +
                            "[BankName], [Type], [Narration], " +
                            "[ReceivedAmount], [PaymentAmount], " +
                            "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                            "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
                            "WHERE 1 = 1 " +
                            "AND ISNULL([Action], '') = '" + Constants.EXPENSE + "' " +
                            "AND ISNULL([AddedBy], '') = @AddedBy " +
                            "ORDER BY [Id] DESC ";

                        using (SqlCommand command = new SqlCommand(selectLastIncomeExpense, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@AddedBy", ((object)username) ?? DBNull.Value);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lastIncomeExpense.Id = Convert.ToInt64(reader["Id"].ToString());
                                    lastIncomeExpense.EndOfDay = reader["EndOfDay"].ToString();
                                    lastIncomeExpense.Action = reader["Action"].ToString();
                                    lastIncomeExpense.ActionType = reader["ActionType"].ToString();
                                    lastIncomeExpense.BankName = reader["BankName"].ToString();
                                    lastIncomeExpense.Type = reader["Type"].ToString();
                                    lastIncomeExpense.Narration = reader["Narration"].ToString();
                                    lastIncomeExpense.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                    lastIncomeExpense.PaymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString());
                                    lastIncomeExpense.AddedBy = reader["AddedBy"].ToString();
                                    lastIncomeExpense.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    lastIncomeExpense.UpdatedBy = reader["UpdatedBy"].ToString();
                                    lastIncomeExpense.UpdatedDate = reader.IsDBNull(12) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
                            }
                        }

                        // Insert into bank transaction table
                        bankTransaction.TransactionId = lastIncomeExpense.Id;
                        string insertBankTransaction = @"INSERT INTO " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "( " +
                                "[EndOfDay], [BankId], [Type], [Action], [TransactionId], [Debit], [Credit], [Narration], [AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @BankId, @Type, @Action, @TransactionId, @Debit, @Credit, @Narration, @AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", ((object)bankTransaction.EndOfDay) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Type", ((object)bankTransaction.Type) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Action", ((object)bankTransaction.Action) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@TransactionId", ((object)bankTransaction.TransactionId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Debit", ((object)bankTransaction.Debit) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@Credit", ((object)bankTransaction.Credit) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@Narration", ((object)bankTransaction.Narration) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AddedBy", ((object)bankTransaction.AddedBy) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AddedDate", ((object)bankTransaction.AddedDate) ?? DBNull.Value);

                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                    }
                    catch
                    {
                        incomeExpense = null;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return incomeExpense;
        }

        // Atomic Transaction
        public bool DeleteIncomeExpense(long id, string type)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from income expense table
                        string deleteStockAdjustment = @"DELETE " +
                        "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                        "WHERE 1 = 1 " +
                        "AND [IncomeExpenseId] = @IncomeExpenseId ";

                        using (SqlCommand command = new SqlCommand(deleteStockAdjustment, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@IncomeExpenseId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from income expense table
                        string deleteIncomeExpense = @"DELETE " +
                        "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
                        "WHERE 1 = 1 " +
                        "AND [Id] = @Id " +
                        "And [Action] = @Action ";

                        using (SqlCommand command = new SqlCommand(deleteIncomeExpense, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Action", ((object)type) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from bank transaction table
                        var deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [TransactionId] = @TransactionId " +
                            "AND [Action] = @Action ";

                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@TransactionId", ((object)id) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Action", ((object)type) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return result;
        }
    }
}
