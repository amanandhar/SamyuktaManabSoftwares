using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlBankRepository : IBankRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlBankRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Bank> GetBanks()
        {
            var banks = new List<Bank>();
            var query = @"SELECT " +
                "[Id], [Name], [AccountNo], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_BANK + " " +
                "ORDER BY [Name] ";

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
                                var bank = new Bank
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    AccountNo = reader["AccountNo"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = reader.IsDBNull(4) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                banks.Add(bank);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return banks;
        }

        public Bank GetBank(long id)
        {
            Bank bank = null;
            var query = @"SELECT " +
                "[Id], [Name], [AccountNo], [AddedDate], [UpdatedDate] " +
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
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                bank = new Bank();
                                while (reader.Read())
                                {
                                    bank.Id = Convert.ToInt64(reader["Id"].ToString());
                                    bank.Name = reader["Name"].ToString();
                                    bank.AccountNo = reader["AccountNo"].ToString();
                                    bank.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    bank.UpdatedDate = reader.IsDBNull(4) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return bank;
        }

        public Bank AddBank(Bank bank)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_BANK + " " +
                    "( " +
                        "[EndOfDay], [Name], [AccountNo], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Name, @AccountNo, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)bank.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)bank.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AccountNo", ((object)bank.AccountNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)bank.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)bank.AddedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return bank;
        }

        public Bank UpdateBank(long id, Bank bank)
        {
            string query = @"UPDATE " + Constants.TABLE_BANK + " " +
                    "SET " +
                    "[Name] = @Name, [AccountNo] = @AccountNo, [UpdatedBy] = @UpdatedBy, [UpdatedDate] = @UpdatedDate " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)bank.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AccountNo", ((object)bank.AccountNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", ((object)bank.UpdatedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)bank.UpdatedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return bank;
        }

        public bool DeleteBank(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_BANK + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return result;
        }
    }
}
