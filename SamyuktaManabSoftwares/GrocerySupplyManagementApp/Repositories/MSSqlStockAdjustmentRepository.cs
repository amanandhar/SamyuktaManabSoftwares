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

        public IEnumerable<StockAdjustment> GetStockAdjustments()
        {
            var stockAdjustments = new List<StockAdjustment>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [ItemId], [Unit], [Action], [Quantity], [Price], [AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT;

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
                                var stockAdjustment = new StockAdjustment
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    ItemId = Convert.ToInt64(reader["ItemId"].ToString()),
                                    Unit = reader["Unit"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    AddedBy = reader["AddedBy"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedBy = reader["UpdatedBy"].ToString(),
                                    UpdatedDate = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                stockAdjustments.Add(stockAdjustment);
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

            return stockAdjustments;
        }

        public StockAdjustment GetStockAdjustment(long id)
        {
            var stockAdjustment = new StockAdjustment();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [ItemId], [Unit], [Action], [Quantity], [Price], [AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    stockAdjustment.Id = Convert.ToInt64(reader["Id"].ToString());
                                    stockAdjustment.EndOfDay = reader["EndOfDay"].ToString();
                                    stockAdjustment.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                    stockAdjustment.Unit = reader["Unit"].ToString();
                                    stockAdjustment.Action = reader["Action"].ToString();
                                    stockAdjustment.Quantity = Convert.ToDecimal(reader["Quantity"].ToString());
                                    stockAdjustment.Price = Convert.ToDecimal(reader["Price"].ToString());
                                    stockAdjustment.AddedBy = reader["AddedBy"].ToString();
                                    stockAdjustment.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    stockAdjustment.UpdatedBy = reader["UpdatedBy"].ToString();
                                    stockAdjustment.UpdatedDate = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
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

            return stockAdjustment;
        }

        public IEnumerable<StockAdjustmentView> GetStockAdjustmentViewList()
        {
            var stockAdjustmentViewList = new List<StockAdjustmentView>();
            var query = @"SELECT " +
                "sa.[Id], sa.[EndOfDay], sa.[Action], ut.[Narration], i.[Code], i.[Name], sa.[Quantity], sa.[Price] " +
                "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " sa " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON sa.[ItemId] = i.[Id] " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON sa.[UserTransactionId] = ut.[Id] " +
                "WHERE 1 = 1 " +
                "ORDER BY sa.[AddedDate] ";

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

        public StockAdjustment AddStockAdjustment(StockAdjustment stockAdjustment)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                    "( " +
                        "[EndOfDay], [UserTransactionId], [ItemId], [Unit], [Action], [Quantity], [Price], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @UserTransactionId, @ItemId, @Unit, @Action, @Quantity, @Price, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)stockAdjustment.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserTransactionId", ((object)stockAdjustment.UserTransactionId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemId", ((object)stockAdjustment.ItemId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Unit", ((object)stockAdjustment.Unit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)stockAdjustment.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", ((object)stockAdjustment.Quantity) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", ((object)stockAdjustment.Price) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)stockAdjustment.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)stockAdjustment.AddedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
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

        public StockAdjustment UpdateStockAdjustment(long id, StockAdjustment stockAdjustment)
        {
            string query = @"UPDATE " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                    "SET " +
                    "[EndOfDay] = @EndOfDay " +
                    "[ItemId] = @ItemId, " +
                    "[Unit] = @Unit, " +
                    "[Action] = @Action, " +
                    "[Quantity] = @Quantity, " +
                    "[Price] = @Price, " +
                    "[UpdatedBy] = @UpdatedBy, " +
                    "[UpdatedDate] = @UpdatedDate " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EndOfDay", ((object)stockAdjustment.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemId", ((object)stockAdjustment.ItemId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Unit", ((object)stockAdjustment.Unit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)stockAdjustment.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", ((object)stockAdjustment.Quantity) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", ((object)stockAdjustment.Price) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", ((object)stockAdjustment.UpdatedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)stockAdjustment.UpdatedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
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

        public bool DeleteStockAdjustment(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
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

        public bool DeleteStockAdjustmentByUserTransaction(long userTrasactionId)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                    "WHERE 1 = 1 " +
                    "AND [UserTransactionId] = @UserTransactionId";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserTransactionId", ((object)userTrasactionId) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
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
