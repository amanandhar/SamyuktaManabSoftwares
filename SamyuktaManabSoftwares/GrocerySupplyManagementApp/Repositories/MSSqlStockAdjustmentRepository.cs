using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlStockAdjustmentRepository : IStockAdjustmentRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlStockAdjustmentRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<StockAdjustmentView> GetStockAdjustmentViewList()
        {
            var stockAdjustmentViewList = new List<StockAdjustmentView>();
            var query = @"SELECT " +
                "sa.[Id], sa.[EndOfDay], sa.[IncomeExpenseId], sa.[Action], ie.[Narration], i.[Code], i.[Name], sa.[Quantity], sa.[Price] " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " sa " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON sa.[ItemId] = i.[Id] " +
                "INNER JOIN " + Constants.TABLE_INCOME_EXPENSE + " ie " +
                "ON sa.[IncomeExpenseId] = ie.[Id] " +
                "WHERE 1 = 1 " +
                "ORDER BY sa.[AddedDate] DESC ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var stockAdjustmentView = new StockAdjustmentView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    IncomeExpenseId = Convert.ToInt64(reader["IncomeExpenseId"].ToString()),
                                    Action = reader["Action"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    ItemCode = reader["Code"].ToString(),
                                    ItemName = reader["Name"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString())
                                };

                                stockAdjustmentViewList.Add(stockAdjustmentView);
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

            return stockAdjustmentViewList;
        }

        public decimal GetAddedStockTotalQuantity(StockFilter stockFilter)
        {
            decimal totalCount = Constants.DEFAULT_DECIMAL_VALUE;
            var query = @"SELECT " +
                "SUM([Quantity]) AS 'Quantity' " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " sa " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON sa.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Action], '') = '" + Constants.ADD + "' ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND sa.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND sa.[EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND ISNULL(i.[Code], '') = @Code ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)stockFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)stockFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Code", ((object)stockFilter.ItemCode) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalCount = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalCount;
        }

        public decimal GetDeductedStockTotalQuantity(StockFilter stockFilter)
        {
            decimal totalCount = Constants.DEFAULT_DECIMAL_VALUE;
            var query = @"SELECT " +
                "SUM([Quantity]) AS 'Quantity' " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " sa " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON sa.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Action], '') = '" + Constants.DEDUCT + "' ";

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateFrom))
            {
                query += "AND sa.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.DateTo))
            {
                query += "AND sa.[EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(stockFilter?.ItemCode))
            {
                query += "AND ISNULL(i.[Code], '') = @Code ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)stockFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)stockFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Code", ((object)stockFilter.ItemCode) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            totalCount = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return totalCount;
        }

        // Atomic Transaction
        public StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment, IncomeExpense incomeExpense, string incomeExpenseType, string username)
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
                            "[Id] " +
                            "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
                            "WHERE 1 = 1 " +
                            "AND ISNULL([Action], '') = @Action " +
                            "AND ISNULL([AddedBy], '') = @AddedBy " +
                            "ORDER BY [Id] DESC ";

                        using (SqlCommand command = new SqlCommand(selectLastIncomeExpense, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Action", ((object)incomeExpenseType) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AddedBy", ((object)username) ?? DBNull.Value);
                            
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lastIncomeExpenseId = Convert.ToInt64(reader["Id"].ToString());
                                }
                            }
                        }

                        // Insert into stock adjustment table
                        stockAdjustment.IncomeExpenseId = lastIncomeExpenseId;
                        string insertStockAdjustment = @"INSERT INTO " +
                            " " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                            "( " +
                                "[EndOfDay], [IncomeExpenseId], [ItemId], [Unit], [Action], [Quantity], [Price], [AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @IncomeExpenseId, @ItemId, @Unit, @Action, @Quantity, @Price, @AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertStockAdjustment, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", ((object)stockAdjustment.EndOfDay) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@IncomeExpenseId", ((object)stockAdjustment.IncomeExpenseId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@ItemId", ((object)stockAdjustment.ItemId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Unit", ((object)stockAdjustment.Unit) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Action", ((object)stockAdjustment.Action) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Quantity", ((object)stockAdjustment.Quantity) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Price", ((object)stockAdjustment.Price) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AddedBy", ((object)stockAdjustment.AddedBy) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@AddedDate", ((object)stockAdjustment.AddedDate) ?? DBNull.Value);
                            command.ExecuteNonQuery();

                        }

                        sqlTransaction.Commit();
                    }
                    catch
                    {
                        stockAdjustment = null;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return stockAdjustment;
        }

        // Atomic Transaction
        public bool DeleteStockAdjustment(long id, long incomeExpenseId)
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
                        // Delete row from stock adjustment table
                        string deleteStockAdjustment = @"DELETE " +
                            "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                            "WHERE 1 = 1 " +
                            "AND [Id] = @Id ";
                        using (SqlCommand command = new SqlCommand(deleteStockAdjustment, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from income expense table
                        var deleteIncomeExpense = @"DELETE " +
                            "FROM " + Constants.TABLE_INCOME_EXPENSE + " " +
                            "WHERE 1 = 1 " +
                            "AND [Id] = @Id ";
                        using (SqlCommand command = new SqlCommand(deleteIncomeExpense, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)incomeExpenseId) ?? DBNull.Value);
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
