using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlBankDetailRepository : IBankDetailRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "BankDetail";

        public IEnumerable<BankDetail> GetBankDetails()
        {
            var bankDetails = new List<BankDetail>();
            string connectionString = GetConnectionString();
            var query = @"SELECT [Id], [Name], [AccountNo], [Date] FROM " + TABLE_NAME;

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
                                var bankDetail = new BankDetail
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    AccountNo = reader["AccountNo"].ToString(),
                                    Date = reader.IsDBNull(3) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString()),
                                };

                                bankDetails.Add(bankDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankDetails;
        }

        public BankDetail GetBankDetail(long bankId)
        {
            var bankDetail = new BankDetail();
            string connectionString = GetConnectionString();
            var query = @"SELECT [Id], [Name], [AccountNo], [Date] FROM " + TABLE_NAME + " WHERE Id = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)bankId) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bankDetail.Id = Convert.ToInt64(reader["Id"].ToString());
                                bankDetail.Name = reader["Name"].ToString();
                                bankDetail.AccountNo = reader["AccountNo"].ToString();
                                bankDetail.Date = reader.IsDBNull(3) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankDetail;
        }

        public BankDetail AddBankDetail(BankDetail bankDetail)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO " + TABLE_NAME + " " +
                            "(" +
                                "[Name], [AccountNo], [Date] " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@Name, @AccountNo, @Date " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", ((object)bankDetail.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AccountNo", ((object)bankDetail.AccountNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Date", ((object)bankDetail.Date) ?? DBNull.Value);
                        command.ExecuteNonQuery();  
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankDetail;
        }

        public BankDetail UpdateBankDetail(long bankId, BankDetail bankDetail)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE " + TABLE_NAME + " " +
                            " SET " + 
                            " [Name] = @Name, [AccountNo] = @AccountNo " +
                            " WHERE [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)bankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)bankDetail.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AccountNo", ((object)bankDetail.AccountNo) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankDetail;
        }

        public bool DeleteBankDetail(long bankId)
        {
            bool result = false;
            string connectionString = GetConnectionString();
            string query = "DELETE FROM " + TABLE_NAME + " WHERE [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)bankId) ?? DBNull.Value);
                        command.ExecuteNonQuery();
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
