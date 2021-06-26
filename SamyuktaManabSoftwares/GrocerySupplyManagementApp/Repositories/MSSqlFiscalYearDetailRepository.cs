using GrocerySupplyManagementApp.Entities;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlFiscalYearDetailRepository: IFiscalYearDetailRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "FiscalYearDetail";

        public FiscalYearDetail GetFiscalYearDetail()
        {
            var fiscalYearDetail = new FiscalYearDetail();
            string connectionString = GetConnectionString();
            var query = @"SELECT InvoiceNo, BillNo, StartingDate, FiscalYear FROM " + TABLE_NAME;

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
                                fiscalYearDetail.InvoiceNo = reader.IsDBNull(0) ? string.Empty : reader["InvoiceNo"].ToString();
                                fiscalYearDetail.BillNo = reader.IsDBNull(0) ? string.Empty : reader["BillNo"].ToString();
                                fiscalYearDetail.StartingDate = reader.IsDBNull(1) ? DateTime.Today : Convert.ToDateTime(reader["StartingDate"].ToString());
                                fiscalYearDetail.FiscalYear = reader.IsDBNull(2) ? string.Empty : reader["FiscalYear"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fiscalYearDetail;
        }

        public bool AddFiscalYearDetail(FiscalYearDetail fiscalYearDetail, bool truncate = false)
        {
            var result = false;
            string connectionString = GetConnectionString();
            if(truncate)
            {
                string truncateQuery = @"TRUNCATE TABLE " + TABLE_NAME;

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
            string query = "INSERT INTO " + TABLE_NAME + " " +
                            "(" +
                                "InvoiceNo, BillNo, StartingDate, FiscalYear " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@InvoiceNo, @BillNo, @StartingDate, @FiscalYear " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)fiscalYearDetail.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)fiscalYearDetail.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)fiscalYearDetail.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FiscalYear", ((object)fiscalYearDetail.FiscalYear) ?? DBNull.Value);
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

        public bool UpdateFiscalYearDetail(FiscalYearDetail fiscalYearDetail)
        {
            var result = false;
            string connectionString = GetConnectionString();
            string query = "UPDATE " + TABLE_NAME + " " +
                            "SET " +
                            "InvoiceNo = @InvoiceNo, BillNo = @BillNo, StartingDate = @StartingDate, FiscalYear = @FiscalYear";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)fiscalYearDetail.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)fiscalYearDetail.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)fiscalYearDetail.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FiscalYear", ((object)fiscalYearDetail.FiscalYear) ?? DBNull.Value);
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
