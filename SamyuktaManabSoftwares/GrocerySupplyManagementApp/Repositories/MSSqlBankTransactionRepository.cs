using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlBankTransactionRepository : IBankTransactionRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "BankTransaction";

        public IEnumerable<BankTransaction> GetBankTransactions()
        {
            var bankTransactions = new List<BankTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT [Id], [BankId], [Action], [Debit], [Credit], [Narration], [Date] FROM " + TABLE_NAME;

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
                                var bankTransaction = new BankTransaction
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    BankId = Convert.ToInt64(reader["BankId"].ToString()),
                                    Action = reader.IsDBNull(2) ? '1' : Convert.ToChar(reader["Action"].ToString()),
                                    Debit = reader.IsDBNull(3) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(3) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader.IsDBNull(4) ? string.Empty : reader["Narration"].ToString(),
                                    Date = reader.IsDBNull(5) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString()),
                                };

                                bankTransactions.Add(bankTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankTransactions;
        }

        public IEnumerable<BankTransaction> GetBankTransactions(long bankId)
        {
            var bankTransactions = new List<BankTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT [Id], [BankId], [Action], [Debit], [Credit], [Narration], [Date] FROM " + TABLE_NAME + " WHERE [BankId] = @BankId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BankId", ((object)bankId) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var bankTransaction = new BankTransaction
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    BankId = Convert.ToInt64(reader["BankId"].ToString()),
                                    Action = reader.IsDBNull(2) ? '1' : Convert.ToChar(reader["Action"].ToString()),
                                    Debit = reader.IsDBNull(3) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(3) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader.IsDBNull(4) ? string.Empty : reader["Narration"].ToString(),
                                    Date = reader.IsDBNull(5) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString()),
                                };

                                bankTransactions.Add(bankTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankTransactions;
        }

        public IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId)
        {
            var bankTransactionViews = new List<BankTransactionView>();
            string connectionString = GetConnectionString();
            var query = @"SELECT Id, Date, CASE WHEN Action = '1' THEN 'Deposit' ELSE 'Withdrawl' END AS Description, Narration, " +
               "Debit, Credit, " +
               "(SELECT SUM(ISNULL(b.DEBIT,0) - ISNULL(b.Credit,0)) " +
               "FROM [dbo].[BankTransaction] b " +
               "WHERE b.Date <= a.Date AND BankId = @BankId) as Balance " +
               "FROM [dbo].[BankTransaction] a " +
               "WHERE BankId = @BankId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BankId", ((object)bankId) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var bankTransactionView = new BankTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
                                    Description = reader["Description"].ToString(),
                                    Narration = reader["Narration"].ToString(),
                                    Debit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(5) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Balance = reader.IsDBNull(6) ? 0.0m : Convert.ToDecimal(reader["Balance"].ToString()),
                                };

                                bankTransactionViews.Add(bankTransactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankTransactionViews;
        }

        public BankTransaction GetBankTransaction(long bankId)
        {
            var bankTransaction = new BankTransaction();
            string connectionString = GetConnectionString();
            var query = @"SELECT [Id], [BankId], [Action], [Debit], [Credit], [Narration], [Date] FROM " + TABLE_NAME + " WHERE Id = @Id";

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
                                bankTransaction.Id = Convert.ToInt64(reader["Id"].ToString());
                                bankTransaction.BankId = Convert.ToInt64(reader["BankId"].ToString());
                                bankTransaction.Action = reader.IsDBNull(2) ? '1' : Convert.ToChar(reader["Action"].ToString());
                                bankTransaction.Debit = reader.IsDBNull(3) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString());
                                bankTransaction.Credit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString());
                                bankTransaction.Narration = reader.IsDBNull(5) ? string.Empty : reader["Narration"].ToString();
                                bankTransaction.Date = reader.IsDBNull(6) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankTransaction;
        }

        public decimal GetBankBalance(long bankId)
        {
            decimal bankBalance = 0.0m;
            string connectionString = GetConnectionString();
            var query = @"SELECT ISNUll(SUM(ISNULL(DEBIT,0) - ISNULL(Credit,0)),0) FROM " + TABLE_NAME + " WHERE [BankId] = @BankId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BankId", ((object)bankId) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            bankBalance = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankBalance;
        }

        public BankTransaction AddBankTransaction(BankTransaction bankTransaction)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO " + TABLE_NAME + " " +
                            "(" +
                                "[BankId], [Action], [Debit], [Credit], [Narration], [Date] " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@BankId, @Action, @Debit, @Credit, @Narration, @Date " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)bankTransaction.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Debit", ((object)bankTransaction.Debit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Credit", ((object)bankTransaction.Credit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)bankTransaction.Narration) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Date", ((object)bankTransaction.Date) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankTransaction;
        }

        public BankTransaction UpdateBankTransaction(long bankId, BankTransaction bankTransaction)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE " + TABLE_NAME + " " +
                            " SET " +
                            " [BankId] = @BankId, [Action] = @Action, [Debit] = @Debit, [Credit] = @Credit, [Narration] = @Narration, [Date] = @Date " +
                            " WHERE [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)bankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)bankTransaction.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Debit", ((object)bankTransaction.Debit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Credit", ((object)bankTransaction.Credit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)bankTransaction.Narration) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Date", ((object)bankTransaction.Date) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bankTransaction;
        }

        public bool DeleteBankTransaction(long bankId)
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
