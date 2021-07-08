using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlBankDetailRepository : IBankDetailRepository
    {
        private readonly string connectionString;

        public MSSqlBankDetailRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Bank> GetBankDetails()
        {
            var bankDetails = new List<Bank>();
            var query = @"SELECT " +
                "[Id], [Name], [AccountNo], [Date] " +
                "FROM " + Constants.TABLE_BANK;

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
                                var bankDetail = new Bank
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

        public Bank GetBankDetail(long bankId)
        {
            var bankDetail = new Bank();
            var query = @"SELECT " +
                "[Id], [Name], [AccountNo], [Date] " +
                "FROM " + Constants.TABLE_BANK + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id";

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

        public Bank AddBankDetail(Bank bankDetail)
        {
            string query = @"INSERT INTO " + 
                    " " + Constants.TABLE_BANK + " " +
                    "( " +
                        "[Name], [AccountNo], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Name, @AccountNo, @Date " +
                    ") ";
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

        public Bank UpdateBankDetail(long bankId, Bank bankDetail)
        {
            string query = @"UPDATE " + Constants.TABLE_BANK + " " +
                    "SET " + 
                    "[Name] = @Name, [AccountNo] = @AccountNo " +
                    "WHERE 1 = 1 " + 
                    "AND [Id] = @Id";
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
            string query = @"DELETE " + 
                    "FROM " + Constants.TABLE_BANK + " " +
                    "WHERE 1 = 1 " +
                    "[Id] = @Id";
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
    }
}
