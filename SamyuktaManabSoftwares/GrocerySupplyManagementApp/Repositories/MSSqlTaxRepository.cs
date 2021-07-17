using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlTaxRepository : ITaxRepository
    {
        private readonly string connectionString;

        public MSSqlTaxRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public Tax GetTax()
        {
            var Tax = new Tax();
            var query = @"SELECT " +
                "[Discount], [Vat], [DeliveryCharge] " +
                "FROM " + Constants.TABLE_TAX;

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
                                Tax.Discount = reader.IsDBNull(0) ? 0.0m : Convert.ToDecimal(reader["Discount"].ToString());
                                Tax.Vat = reader.IsDBNull(1) ? 0.0m : Convert.ToDecimal(reader["Vat"].ToString());
                                Tax.DeliveryCharge = reader.IsDBNull(2) ? 0.0m : Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Tax;
        }

        public bool AddTax(Tax Tax, bool truncate = false)
        {
            var result = false;
            if (truncate)
            {
                string truncateQuery = @"TRUNCATE TABLE " + Constants.TABLE_TAX;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(truncateQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            string query = @"INSERT INTO " + Constants.TABLE_TAX + " " +
                    "( " +
                        "[Discount], [Vat], [DeliveryCharge] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Discount, @Vat, @DeliveryCharge " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Discount", ((object)Tax.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)Tax.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)Tax.DeliveryCharge) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool UpdateTax(Tax Tax)
        {
            var result = false;
            string query = @"UPDATE " + Constants.TABLE_TAX + " " +
                    "SET " +
                    "[Discount] = @Discount, [Vat] = @DeliveryCharge, [DeliveryCharge] = @DeliveryCharge ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Discount", ((object)Tax.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)Tax.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)Tax.DeliveryCharge) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
