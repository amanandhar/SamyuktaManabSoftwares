using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlQuantitySettingRepository : IQuantitySettingRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlQuantitySettingRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public QuantitySetting GetQuantitySetting(long itemId)
        {
            var quantitySetting = new QuantitySetting();
            var query = @"SELECT " +
                "[Id], [ItemId], [Box], [Packet], " +
                "[AddedBy], [AddedDate], [UpdatedBy], [UpdatedDate] " +
                "FROM " + Constants.TABLE_QUANTITY_SETTING + " " +
                "WHERE 1 = 1 " +
                "AND ItemId = @ItemId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                quantitySetting.Id = Convert.ToInt64(reader["Id"].ToString());
                                quantitySetting.ItemId = Convert.ToInt64(reader["ItemId"].ToString());
                                quantitySetting.Box = Convert.ToDecimal(reader["Box"].ToString());
                                quantitySetting.Packet = Convert.ToDecimal(reader["Packet"].ToString());
                                quantitySetting.AddedBy = reader["AddedBy"].ToString();
                                quantitySetting.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                quantitySetting.UpdatedBy = reader["UpdatedBy"].ToString();
                                quantitySetting.UpdatedDate = reader.IsDBNull(7) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

            return quantitySetting;
        }

        public QuantitySetting AddQuantitySetting(QuantitySetting quantitySetting)
        {
            string query = @"INSERT INTO " + Constants.TABLE_QUANTITY_SETTING + " " +
                    "( " +
                        "[ItemId], [Box], [Packet], " +
                        "[AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@ItemId, @Box, @Packet, " +
                        "@AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", quantitySetting.ItemId);
                        command.Parameters.AddWithValue("@Box", quantitySetting.Box);
                        command.Parameters.AddWithValue("@Packet", quantitySetting.Packet);
                        command.Parameters.AddWithValue("@AddedBy", quantitySetting.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", quantitySetting.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return quantitySetting;
        }

        public QuantitySetting UpdateQuantitySetting(long id, QuantitySetting quantitySetting)
        {
            string query = @"UPDATE " + Constants.TABLE_QUANTITY_SETTING + " " +
                "SET " +
                "[ItemId] = @ItemId, " +
                "[Box] = @Box, " +
                "[Packet] = @Packet, " +
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
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@ItemId", quantitySetting.ItemId);
                        command.Parameters.AddWithValue("@Box", quantitySetting.Box);
                        command.Parameters.AddWithValue("@Packet", quantitySetting.Packet);
                        command.Parameters.AddWithValue("@UpdatedBy", quantitySetting.UpdatedBy);
                        command.Parameters.AddWithValue("@UpdatedDate", quantitySetting.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return quantitySetting;
        }

    }
}
