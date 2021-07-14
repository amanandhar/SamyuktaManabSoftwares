using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlBankTransactionRepository : IBankTransactionRepository
    {
        private readonly string connectionString;

        public MSSqlBankTransactionRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<BankTransaction> GetBankTransactions()
        {
            var bankTransactions = new List<BankTransaction>();
            var query = @"SELECT " +
                "[Id], [BankId], [TransactionId], [Action], " +
                "[Debit], [Credit], [Narration], [Date] " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION;

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
                                    TransactionId = reader.IsDBNull(2) ? 0 : Convert.ToInt64(reader["TransactionId"].ToString()),
                                    Action = reader.IsDBNull(3) ? '1' : Convert.ToChar(reader["Action"].ToString()),
                                    Debit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(5) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader.IsDBNull(6) ? string.Empty : reader["Narration"].ToString(),
                                    Date = reader.IsDBNull(7) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString()),
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
            var query = @"SELECT " +
                "[Id], [BankId], [TransactionId], [Action], " + 
                "[Debit], [Credit], [Narration], [Date] " + 
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [BankId] = @BankId ";

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
                                    TransactionId = reader.IsDBNull(2) ? 0 : Convert.ToInt64(reader["TransactionId"].ToString()),
                                    Action = reader.IsDBNull(3) ? '1' : Convert.ToChar(reader["Action"].ToString()),
                                    Debit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(5) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader.IsDBNull(6) ? string.Empty : reader["Narration"].ToString(),
                                    Date = reader.IsDBNull(7) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString()),
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
            var query = @"SELECT " +
                "Id, Date, " +
                "CASE WHEN Action = '1' THEN 'Deposit' ELSE 'Withdrawl' END AS Description, Narration, " +
                "Debit, Credit, " +
                "(SELECT SUM(ISNULL(b.DEBIT, 0) - ISNULL(b.Credit, 0)) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " b " +
                "WHERE b.Date <= a.Date AND BankId = @BankId) as 'Balance' " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND BankId = @BankId ";

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
            var query = @"SELECT " +
                "[Id], [BankId], [TransactionId], [Action], " +
                "[Debit], [Credit], [Narration], [Date] " + 
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";

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
                                bankTransaction.TransactionId = reader.IsDBNull(2) ? 0 : Convert.ToInt64(reader["TransactionId"].ToString());
                                bankTransaction.Action = reader.IsDBNull(3) ? '1' : Convert.ToChar(reader["Action"].ToString());
                                bankTransaction.Debit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString());
                                bankTransaction.Credit = reader.IsDBNull(5) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString());
                                bankTransaction.Narration = reader.IsDBNull(6) ? string.Empty : reader["Narration"].ToString();
                                bankTransaction.Date = reader.IsDBNull(7) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString());
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

        public decimal GetBankBalance()
        {
            decimal bankBalance = 0.0m;
            var query = @"SELECT " +
                "ISNUll(SUM(ISNULL(DEBIT, 0) - ISNULL(Credit, 0)), 0) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        public decimal GetBankBalance(long bankId)
        {
            decimal bankBalance = 0.0m;
            var query = @"SELECT " +
                "ISNUll(SUM(ISNULL(DEBIT, 0) - ISNULL(Credit, 0)), 0) " + 
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [BankId] = @BankId ";

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

        public decimal GetBankTotalDeposit(string incomeType)
        {
            decimal total = 0.0m;
            var query = @"SELECT " +
                "ISNUll(SUM(ISNULL(DEBIT, 0)), 0) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] = '1' " +
                "AND [Narration] = @IncomeType ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IncomeType", ((object)incomeType) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            total = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return total;
        }

        public BankTransaction AddBankTransaction(BankTransaction bankTransaction)
        {
            string query = @"INSERT INTO " +  Constants.TABLE_BANK_TRANSACTION  + " " +
                    "( " +
                        "[BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@BankId, @TransactionId, @Action, @Debit, @Credit, @Narration, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TransactionId", ((object)bankTransaction.TransactionId) ?? DBNull.Value);
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

            string query = @"UPDATE " + Constants.TABLE_BANK_TRANSACTION + " " +
                    "SET " +
                    "[BankId] = @BankId, [TransactionId] = @TransactionId, " +
                    "[Action] = @Action, [Debit] = @Debit, " + 
                    "[Credit] = @Credit, [Narration] = @Narration, " +
                    "[Date] = @Date " +
                    "WHERE 1 = 1 " + 
                    "AND [Id] = @Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)bankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TransactionId", ((object)bankTransaction.TransactionId) ?? DBNull.Value);
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

        public bool DeleteBankTransaction(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
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

        public bool DeleteBankTransactionByTransactionId(long transactionId)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [TransactionId] = @TransactionId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionId", ((object)transactionId) ?? DBNull.Value);
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
