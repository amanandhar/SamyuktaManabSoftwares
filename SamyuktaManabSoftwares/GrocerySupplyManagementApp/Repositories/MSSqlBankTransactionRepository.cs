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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlBankTransactionRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<BankTransaction> GetBankTransactions(long bankId)
        {
            var bankTransactions = new List<BankTransaction>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], [BankId], [Type], [Action], [TransactionId], " +
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
                                    Type = reader.IsDBNull(3) ? '1' : Convert.ToChar(reader["Type"].ToString()),
                                    Action = reader["Action"].ToString(),
                                    TransactionId = reader.IsDBNull(5) ? 0 : Convert.ToInt64(reader["TransactionId"].ToString()),
                                    Debit = reader.IsDBNull(6) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(7) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader["Narration"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = reader.IsDBNull(10) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                bankTransactions.Add(bankTransaction);
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

            return bankTransactions;
        }

        public IEnumerable<BankTransactionView> GetBankTransactionViews(long bankId)
        {
            var bankTransactionViews = new List<BankTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "CASE WHEN [Type] = '1' THEN 'Deposit' ELSE 'Withdrawl' END AS Description, " +
                "[TransactionId], [Debit], [Credit], [Narration], " +
                "( " +
                "SELECT SUM(ISNULL(b.[Debit], 0) - ISNULL(b.[Credit], 0)) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " b " +
                "WHERE b.[AddedDate] <= a.[AddedDate] AND [BankId] = @BankId " +
                ") " +
                "AS 'Balance' " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " a " +
                "WHERE 1 = 1 " +
                "AND [BankId] = @BankId " +
                "ORDER BY [AddedDate] ";

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
                                    TransactionId = Convert.ToInt64(reader["TransactionId"].ToString()),
                                    Debit = reader.IsDBNull(4) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(5) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Narration = reader["Narration"].ToString(),
                                    Balance = reader.IsDBNull(7) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Balance"].ToString()),
                                };

                                bankTransactionViews.Add(bankTransactionView);
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

            return bankTransactionViews;
        }

        public IEnumerable<BankTransactionView> GetBankTransactionViews(BankTransactionFilter bankTransactionFilter)
        {
            var bankTransactionViews = new List<BankTransactionView>();
            var query = @"SELECT " +
                "[Id], [EndOfDay], " +
                "CASE WHEN [Type] = '1' THEN 'Deposit' ELSE 'Withdrawl' END AS Description, [Narration], " +
                "[Debit], [Credit], " +
                "(SELECT SUM(ISNULL(b.[Debit], 0) - ISNULL(b.[Credit], 0)) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " b " +
                "WHERE b.[AddedDate] <= a.[AddedDate]) as 'Balance' " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " a " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(bankTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrEmpty(bankTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (bankTransactionFilter?.BankId != null)
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
                                    Debit = reader.IsDBNull(4) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(5) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Balance = reader.IsDBNull(6) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Balance"].ToString()),
                                };

                                bankTransactionViews.Add(bankTransactionView);
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

            return bankTransactionViews;
        }

        public decimal GetTotalBalance(BankTransactionFilter bankTransactionFilter)
        {
            decimal bankBalance = Constants.DEFAULT_DECIMAL_VALUE;
            var query = @"SELECT " +
                "ISNUll(SUM(ISNULL([Debit], 0) - ISNULL([Credit], 0)), 0) " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(bankTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(bankTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if(!string.IsNullOrWhiteSpace(bankTransactionFilter?.Action))
            {
                query += "AND [Action] = @Action ";
            }

            if (bankTransactionFilter?.BankId > 0)
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
                        command.Parameters.AddWithValue("@Action", ((object)bankTransactionFilter?.Action) ?? DBNull.Value);
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
                logger.Error(ex);
                throw ex;
            }

            return bankBalance;
        }

        public BankTransaction AddBankTransaction(BankTransaction bankTransaction)
        {
            string query = @"INSERT INTO " + Constants.TABLE_BANK_TRANSACTION + " " +
                    "( " +
                        "[EndOfDay], [BankId], [Type], [Action], [TransactionId], [Debit], [Credit], [Narration], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @BankId, @Type, @Action, @TransactionId, @Debit, @Credit, @Narration, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)bankTransaction.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BankId", ((object)bankTransaction.BankId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)bankTransaction.Type) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)bankTransaction.Action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TransactionId", ((object)bankTransaction.TransactionId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Debit", ((object)bankTransaction.Debit) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@Credit", ((object)bankTransaction.Credit) ?? Constants.DEFAULT_DECIMAL_VALUE);
                        command.Parameters.AddWithValue("@Narration", ((object)bankTransaction.Narration) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)bankTransaction.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)bankTransaction.AddedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return bankTransaction;
        }

        public bool DeleteBankTransaction(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.BANK_TRANSFER + "', '" + Constants.OWNER_EQUITY + "') " + 
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
                logger.Error(ex);
                throw ex;
            }

            return result;
        }

        public bool DeleteShareMemberTransaction(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id " +
                "AND [Action] = '" + Constants.SHARE_CAPITAL + "' ";
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
