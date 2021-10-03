using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
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
                "[Id], [EndOfDay], [BankId], [TransactionId], [Action], " +
                "[Debit], [Credit], [Narration], [AddedDate] " +
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
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    BankId = Convert.ToInt64(reader["BankId"].ToString()),
                                    TransactionId = reader.IsDBNull(2) ? 0 : Convert.ToInt64(reader["TransactionId"].ToString()),
                                    Action = reader.IsDBNull(3) ? '1' : Convert.ToChar(reader["Action"].ToString()),
                                    Debit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(5) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader.IsDBNull(6) ? string.Empty : reader["Narration"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
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

        public BankTransaction GetBankTransaction(long id)
        {
            var bankTransaction = new BankTransaction();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [BankId], [TransactionId], [Action], " +
                "[Debit], [Credit], [Narration], [AddedDate], [UpdatedDate] " + 
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
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bankTransaction.Id = Convert.ToInt64(reader["Id"].ToString());
                                bankTransaction.EndOfDay = reader["EndOfDay"].ToString();
                                bankTransaction.BankId = Convert.ToInt64(reader["BankId"].ToString());
                                bankTransaction.TransactionId = reader.IsDBNull(2) ? 0 : Convert.ToInt64(reader["TransactionId"].ToString());
                                bankTransaction.Action = reader.IsDBNull(3) ? '1' : Convert.ToChar(reader["Action"].ToString());
                                bankTransaction.Debit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString());
                                bankTransaction.Credit = reader.IsDBNull(5) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString());
                                bankTransaction.Narration = reader.IsDBNull(6) ? string.Empty : reader["Narration"].ToString();
                                bankTransaction.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                bankTransaction.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

        public IEnumerable<BankTransaction> GetBankTransactions(long bankId)
        {
            var bankTransactions = new List<BankTransaction>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [BankId], [TransactionId], [Action], " +
                "[Debit], [Credit], [Narration], [AddedDate], [UpdatedDate] " +
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
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    BankId = Convert.ToInt64(reader["BankId"].ToString()),
                                    TransactionId = reader.IsDBNull(2) ? 0 : Convert.ToInt64(reader["TransactionId"].ToString()),
                                    Action = reader.IsDBNull(3) ? '1' : Convert.ToChar(reader["Action"].ToString()),
                                    Debit = reader.IsDBNull(4) ? 0.0m : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(5) ? 0.0m : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader.IsDBNull(6) ? string.Empty : reader["Narration"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
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
                "[Id], [EndOfDay], " +
                "CASE WHEN [Action] = '1' THEN 'Deposit' ELSE 'Withdrawl' END AS Description, [Narration], " +
                "[Debit], [Credit], " +
                "(SELECT SUM(ISNULL(b.[Debit], 0) - ISNULL(b.[Credit], 0)) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " b " +
                "WHERE b.[AddedDate] <= a.[AddedDate] AND [BankId] = @BankId) as 'Balance' " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " a " +
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
                                var bankTransactionView = new BankTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
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

        public IEnumerable<BankTransactionView> GetBankTransactionViews(BankTransactionFilter bankTransactionFilter)
        {
            var bankTransactionViews = new List<BankTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "CASE WHEN [Action] = '1' THEN 'Deposit' ELSE 'Withdrawl' END AS Description, [Narration], " +
                "[Debit], [Credit], " +
                "(SELECT SUM(ISNULL(b.[Debit], 0) - ISNULL(b.[Credit], 0)) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " b " +
                "WHERE b.[AddedDate] <= a.[AddedDate]) as 'Balance' " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " a " +
                "WHERE 1 = 1 ";

            if (!char.IsWhiteSpace((char)bankTransactionFilter?.Action))
            {
                query += "AND [Action] = @Action ";
            }

            if (!string.IsNullOrEmpty(bankTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(bankTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Action", ((object)bankTransactionFilter.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateFrom", ((object)bankTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)bankTransactionFilter.DateTo) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var bankTransactionView = new BankTransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
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

        public decimal GetTotalBalance(BankTransactionFilter bankTransactionFilter)
        {
            decimal bankBalance = 0.0m;
            var query = @"SELECT " +
                "ISNUll(SUM(ISNULL([Debit], 0) - ISNULL([Credit], 0)), 0) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 ";

            if(!string.IsNullOrWhiteSpace(bankTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(bankTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if(bankTransactionFilter?.BankId > 0)
            {
                query += "AND [BankId] = @BankId ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)bankTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)bankTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransactionFilter?.BankId) ?? DBNull.Value);
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

        public decimal GetTotalBalance(long bankId)
        {
            decimal bankBalance = 0.0m;
            var query = @"SELECT " +
                "ISNUll(SUM(ISNULL([Debit], 0) - ISNULL([Credit], 0)), 0) " + 
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

        public decimal GetTotalDeposit(BankTransactionFilter bankTransactionFilter)
        {
            decimal total = 0.0m;
            var query = @"SELECT " +
                "ISNUll(SUM(ISNULL([Debit], 0)), 0) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 ";

            if(!string.IsNullOrWhiteSpace(bankTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(bankTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!char.IsWhiteSpace((char)(bankTransactionFilter?.Action)) || bankTransactionFilter?.Action != null)
            {
                query += "AND [Action] = @Action ";
            }

            if (!string.IsNullOrWhiteSpace(bankTransactionFilter?.Narration))
            {
                query += "AND [Narration] = @Narration ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)bankTransactionFilter.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)bankTransactionFilter.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)bankTransactionFilter.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)bankTransactionFilter.Narration) ?? DBNull.Value);

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
            string query = @"INSERT INTO " + Constants.TABLE_BANK_TRANSACTION + " " +
                    "( " +
                        "[EndOfDay], [Username], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [AddedDate], [UpdatedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Username, @BankId, @TransactionId, @Action, @Debit, @Credit, @Narration, @AddedDate, @UpdatedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)bankTransaction.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Username", ((object)bankTransaction.Username) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TransactionId", ((object)bankTransaction.TransactionId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)bankTransaction.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Debit", ((object)bankTransaction.Debit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Credit", ((object)bankTransaction.Credit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)bankTransaction.Narration) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)bankTransaction.AddedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)bankTransaction.UpdatedDate) ?? DBNull.Value);

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

        public BankTransaction UpdateBankTransaction(long id, BankTransaction bankTransaction)
        {

            string query = @"UPDATE " + Constants.TABLE_BANK_TRANSACTION + " " +
                    "SET " +
                    "[EndOfDay] = @EndOfDay " +
                    "[BankId] = @BankId, [TransactionId] = @TransactionId, " +
                    "[Action] = @Action, [Debit] = @Debit, " +
                    "[Credit] = @Credit, [Narration] = @Narration, " +
                    "[UpdatedDate] = @UpdatedDate " +
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
                        command.Parameters.AddWithValue("@EndOfDay", ((object)bankTransaction.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TransactionId", ((object)bankTransaction.TransactionId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)bankTransaction.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Debit", ((object)bankTransaction.Debit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Credit", ((object)bankTransaction.Credit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Narration", ((object)bankTransaction.Narration) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)bankTransaction.UpdatedDate) ?? DBNull.Value);
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

        public bool DeleteBankTransactionByUserTransaction(long userTransactionId)
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
                        command.Parameters.AddWithValue("@TransactionId", ((object)userTransactionId) ?? DBNull.Value);
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

        public bool DeleteBankTransactionAfterEndOfDay(string endOfDay)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [EndOfDay] > @EndOfDay ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)endOfDay) ?? DBNull.Value);
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
