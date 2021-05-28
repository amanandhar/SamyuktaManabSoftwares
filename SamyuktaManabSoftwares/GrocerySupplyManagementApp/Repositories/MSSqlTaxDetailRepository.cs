using GrocerySupplyManagementApp.Entities;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlTaxDetailRepository : ITaxDetailRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";

        public TaxDetail GetTaxDetail()
        {
            var TaxDetail = new TaxDetail();
            string connectionString = GetConnectionString();
            var query = @"SELECT Discount, Vat, DeliveryCharge FROM TaxDetail";

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
            string connectionString = GetConnectionString();
            if (truncate)
            {
                string truncateQuery = @"TRUNCATE TABLE TaxDetail";

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
            string query = "INSERT INTO TaxDetail " +
                            "(" +
                                "Discount, Vat, DeliveryCharge " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@Discount, @Vat, @DeliveryCharge " +
                            ")";
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
            string connectionString = GetConnectionString();
            string query = "UPDATE TaxDetail " +
                            "SET " +
                            "Discount = @Discount, Vat = @DeliveryCharge, DeliveryCharge = @DeliveryCharge";
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

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
