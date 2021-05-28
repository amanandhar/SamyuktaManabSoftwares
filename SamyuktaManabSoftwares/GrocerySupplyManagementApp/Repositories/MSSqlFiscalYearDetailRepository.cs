using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlFiscalYearDetailRepository: IFiscalYearDetailRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";

        public FiscalYearDetail GetFiscalYearDetail()
        {
            var fiscalYearDetail = new FiscalYearDetail();
            string connectionString = GetConnectionString();
            var query = @"SELECT InvoiceNo, StartingDate, FiscalYear FROM FiscalYearDetail";

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
                                fiscalYearDetail.InvoiceNo = reader.IsDBNull(0) ? string.Empty : reader["InvoiceNO"].ToString();
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
                string truncateQuery = @"TRUNCATE TABLE FiscalYearDetail";

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
            string query = "INSERT INTO FiscalYearDetail " +
                            "(" +
                                "InvoiceNo, StartingDate, FiscalYear " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@InvoiceNo, @StartingDate, @FiscalYear " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)fiscalYearDetail.InvoiceNo) ?? DBNull.Value);
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
            string query = "UPDATE FiscalYearDetail " +
                            "SET " +
                            "InvoiceNo = @InvoiceNo, StartingDate = @StartingDate, FiscalYear = @FiscalYear";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)fiscalYearDetail.InvoiceNo) ?? DBNull.Value);
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
