using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlFiscalYearDetailRepository: IFiscalYearDetailRepository
    {
        private readonly string connectionString;

        public MSSqlFiscalYearDetailRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public FiscalYear GetFiscalYearDetail()
        {
            var fiscalYearDetail = new FiscalYear();
            var query = @"SELECT " + 
                "InvoiceNo, BillNo, StartingDate, Year " +
                "FROM " + Constants.TABLE_FISCAL_YEAR;

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
                                fiscalYearDetail.Year = reader.IsDBNull(2) ? string.Empty : reader["Year"].ToString();
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

        public bool AddFiscalYearDetail(FiscalYear fiscalYearDetail, bool truncate = false)
        {
            var result = false;
            if(truncate)
            {
                string truncateQuery = @"TRUNCATE TABLE " + Constants.TABLE_FISCAL_YEAR;

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
            string query = @"INSERT INTO " + Constants.TABLE_FISCAL_YEAR + " " +
                    "(" +
                        "InvoiceNo, BillNo, StartingDate, Year " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@InvoiceNo, @BillNo, @StartingDate, @Year " +
                    ") ";
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
                        command.Parameters.AddWithValue("@Year", ((object)fiscalYearDetail.Year) ?? DBNull.Value);
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

        public bool UpdateFiscalYearDetail(FiscalYear fiscalYearDetail)
        {
            var result = false;
            string query = @"UPDATE " + Constants.TABLE_FISCAL_YEAR + " " +
                    "SET " +
                    "InvoiceNo = @InvoiceNo, BillNo = @BillNo, " +
                    "StartingDate = @StartingDate, " +
                    "Year = @Year ";
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
                        command.Parameters.AddWithValue("@Year", ((object)fiscalYearDetail.Year) ?? DBNull.Value);
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
