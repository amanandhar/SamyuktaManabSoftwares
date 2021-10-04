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
                "[StartingInvoiceNo], [StartingBillNo], [StartingDate], [Year], [AddedDate], [UpdatedDate] " +
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
                                fiscalYear.StartingInvoiceNo = reader.IsDBNull(0) ? string.Empty : reader["StartingInvoiceNo"].ToString();
                                fiscalYear.StartingBillNo = reader.IsDBNull(0) ? string.Empty : reader["StartingBillNo"].ToString();
                                fiscalYear.StartingDate = reader["StartingDate"].ToString();
                                fiscalYear.Year = reader.IsDBNull(2) ? string.Empty : reader["Year"].ToString();
                                fiscalYear.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                fiscalYear.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
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
                        "[StartingInvoiceNo], [StartingBillNo], [StartingDate], [Year], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@StartingInvoiceNo, @StartingBillNo, @StartingDate, @Year, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartingInvoiceNo", ((object)fiscalYear.StartingInvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingBillNo", ((object)fiscalYear.StartingBillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)fiscalYear.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Year", ((object)fiscalYear.Year) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)fiscalYear.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)fiscalYear.AddedDate) ?? DBNull.Value);

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
                    "[StartingInvoiceNo] = @StartingInvoiceNo, " +
                    "[StartingBillNo] = @StartingBillNo, " +
                    "[StartingDate] = @StartingDate, " +
                    "[Year] = @Year, " +
                    "[UpdatedBy] = @UpdatedBy, " +
                    "[UpdatedDate] = @UpdatedDate ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartingInvoiceNo", ((object)fiscalYear.StartingInvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingBillNo", ((object)fiscalYear.StartingBillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartingDate", ((object)fiscalYear.StartingDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Year", ((object)fiscalYear.Year) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", ((object)fiscalYear.UpdatedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)fiscalYear.UpdatedDate) ?? DBNull.Value);

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
