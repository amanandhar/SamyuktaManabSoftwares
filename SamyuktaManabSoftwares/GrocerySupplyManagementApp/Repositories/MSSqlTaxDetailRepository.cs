using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlTaxDetailRepository : ITaxDetailRepository
    {
        private readonly string connectionString;

        public MSSqlTaxDetailRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public TaxDetail GetTaxDetail()
        {
            var TaxDetail = new TaxDetail();
            var query = @"SELECT " +
                "Discount, Vat, DeliveryCharge " +
                "FROM " + Constants.TABLE_TAX_DETAIL;

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
                                TaxDetail.Discount = reader.IsDBNull(0) ? 0.0m : Convert.ToDecimal(reader["Discount"].ToString());
                                TaxDetail.Vat = reader.IsDBNull(1) ? 0.0m : Convert.ToDecimal(reader["Vat"].ToString());
                                TaxDetail.DeliveryCharge = reader.IsDBNull(2) ? 0.0m : Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return TaxDetail;
        }

        public bool AddTaxDetail(TaxDetail TaxDetail, bool truncate = false)
        {
            var result = false;
            if (truncate)
            {
                string truncateQuery = @"TRUNCATE TABLE " + Constants.TABLE_TAX_DETAIL;

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
            string query = @"INSERT INTO " + Constants.TABLE_TAX_DETAIL + " " +
                    "( " +
                        "Discount, Vat, DeliveryCharge " +
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
                        command.Parameters.AddWithValue("@Discount", ((object)TaxDetail.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)TaxDetail.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)TaxDetail.DeliveryCharge) ?? DBNull.Value);
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

        public bool UpdateTaxDetail(TaxDetail TaxDetail)
        {
            var result = false;
            string query = @"UPDATE " + Constants.TABLE_TAX_DETAIL + " " +
                    "SET " +
                    "Discount = @Discount, Vat = @DeliveryCharge, DeliveryCharge = @DeliveryCharge ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Discount", ((object)TaxDetail.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)TaxDetail.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)TaxDetail.DeliveryCharge) ?? DBNull.Value);
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
