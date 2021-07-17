using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlFiscalYearRepository: IFiscalYearRepository
    {
        private readonly string connectionString;

        public MSSqlFiscalYearRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public FiscalYear GetFiscalYear()
        {
            var fiscalYear = new FiscalYear();
            var query = @"SELECT " + 
                "[InvoiceNo], [BillNo], [StartingDate], [Year] " +
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
                                fiscalYear.InvoiceNo = reader.IsDBNull(0) ? string.Empty : reader["InvoiceNo"].ToString();
                                fiscalYear.BillNo = reader.IsDBNull(0) ? string.Empty : reader["BillNo"].ToString();
                                fiscalYear.StartingDate = reader.IsDBNull(1) ? DateTime.Today : Convert.ToDateTime(reader["StartingDate"].ToString());
                                fiscalYear.Year = reader.IsDBNull(2) ? string.Empty : reader["Year"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fiscalYear;
        }

        public bool AddFiscalYear(FiscalYear fiscalYear, bool truncate = false)
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
                        "[InvoiceNo], [BillNo], [StartingDate], [Year] " +
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
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)fiscalYear.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)fiscalYear.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)fiscalYear.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Year", ((object)fiscalYear.Year) ?? DBNull.Value);
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

        public bool UpdateFiscalYear(FiscalYear fiscalYear)
        {
            var result = false;
            string query = @"UPDATE " + Constants.TABLE_FISCAL_YEAR + " " +
                    "SET " +
                    "[InvoiceNo] = @InvoiceNo, " +
                    "[BillNo] = @BillNo, " +
                    "[StartingDate] = @StartingDate, " +
                    "[Year] = @Year ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)fiscalYear.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillNo", ((object)fiscalYear.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)fiscalYear.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Year", ((object)fiscalYear.Year) ?? DBNull.Value);
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
