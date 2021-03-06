using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    class MSSqlSettingRepository : ISettingRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlSettingRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Setting> GetSettings()
        {
            var settings = new List<Setting>();
            var query = @"SELECT " +
                "[Id], [StartingInvoiceNo], [StartingBillNo], [StartingDate], " +
                "[FiscalYear], [Discount], [Vat], [DeliveryCharge], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_SETTING + " " +
                "WHERE 1 = 1 ";

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
                                var setting = new Setting
                                {
                                    Id = reader.IsDBNull(0) ? 0 : Convert.ToInt64(reader["Id"].ToString()),
                                    StartingInvoiceNo = reader.IsDBNull(1) ? null : reader["StartingInvoiceNo"].ToString(),
                                    StartingBillNo = reader.IsDBNull(2) ? null : reader["StartingBillNo"].ToString(),
                                    StartingDate = reader.IsDBNull(3) ? null : reader["StartingDate"].ToString(),
                                    FiscalYear = reader.IsDBNull(4) ? null : reader["FiscalYear"].ToString(),
                                    Discount = reader.IsDBNull(5) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Discount"].ToString()),
                                    Vat = reader.IsDBNull(6) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Vat"].ToString()),
                                    DeliveryCharge = reader.IsDBNull(7) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                    AddedBy = reader.IsDBNull(8) ? null : reader["AddedBy"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedBy = reader.IsDBNull(10) ? null : reader["UpdatedBy"].ToString(),
                                    UpdatedDate = reader.IsDBNull(11) ? (DateTime?) null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                settings.Add(setting);
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

            return settings;
        }

        public Setting AddSetting(Setting setting, bool truncate = false)
        {
            if (truncate)
            {
                string truncateQuery = @"TRUNCATE TABLE " + Constants.TABLE_SETTING;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(truncateQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    throw ex;
                }
            }

            string query = @"INSERT INTO " + Constants.TABLE_SETTING + " " +
                    "(" +
                        "[StartingInvoiceNo], [StartingBillNo], [StartingDate], [FiscalYear], [Discount], [Vat], [DeliveryCharge], " +
                        "[AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@StartingInvoiceNo, @StartingBillNo, @StartingDate, @FiscalYear, @Discount, @Vat, @DeliveryCharge, " +
                        "@AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartingInvoiceNo", ((object)setting.StartingInvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingBillNo", ((object)setting.StartingBillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)setting.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FiscalYear", ((object)setting.FiscalYear) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Discount", ((object)setting.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)setting.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)setting.DeliveryCharge) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)setting.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)setting.AddedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return setting;
        }

        public Setting UpdateSetting(long id, Setting setting)
        {
            string query = @"UPDATE " + Constants.TABLE_SETTING + " " +
                    "SET " +
                    "[StartingInvoiceNo] = @StartingInvoiceNo, " +
                    "[StartingBillNo] = @StartingBillNo, " +
                    "[StartingDate] = @StartingDate, " +
                    "[FiscalYear] = @FiscalYear, " +
                    "[Discount] = @Discount, " +
                    "[Vat] = @Vat, " +
                    "[DeliveryCharge] = @DeliveryCharge, " +
                    "[UpdatedBy] = @UpdatedBy, " +
                    "[UpdatedDate] = @UpdatedDate " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingInvoiceNo", ((object)setting.StartingInvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingBillNo", ((object)setting.StartingBillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)setting.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FiscalYear", ((object)setting.FiscalYear) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Discount", ((object)setting.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)setting.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)setting.DeliveryCharge) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", ((object)setting.UpdatedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)setting.UpdatedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return setting;
        }

        public bool DeletePreviousTransactions(string endOfDay)
        {
            bool result = false;
            string query = @" " +
                "DELETE FROM " + Constants.TABLE_BANK_TRANSACTION + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_EMPLOYEE + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_ITEM_CATEGORY + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_MEMBER + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_POS_DETAIL + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_PRICED_ITEM + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_PURCHASED_ITEM + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_SHARE_MEMBER + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_SOLD_ITEM + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_SUPPLIER + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_ITEM + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_BANK + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_INCOME_EXPENSE + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                "DELETE FROM " + Constants.TABLE_USER_TRANSACTION + " WHERE 1 = 1 AND [EndOfDay] > @EndOfDay; " +
                " ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", endOfDay);
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
