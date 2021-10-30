using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlSupplierRepository : ISupplierRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlSupplierRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            var suppliers = new List<Supplier>();
            var query = @"SELECT " +
                "[Id], [Counter], [SupplierId], [Name], " +
                "[Address], [ContactNo], [Email], [Owner], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "ORDER BY [SupplierId] ";
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
                                var supplier = new Supplier
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Counter = Convert.ToInt64(reader["Counter"].ToString()),
                                    SupplierId = reader["SupplierId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    ContactNo = Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    Owner = reader["Owner"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = reader.IsDBNull(9) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                suppliers.Add(supplier);
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

            return suppliers;
        }

        public Supplier GetSupplier(string supplierId)
        {
            var query = @"SELECT " +
                "[Id], [Counter], [SupplierId], [Name], " +
                "[Address], [ContactNo], [Email], [Owner], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId ";
            var supplier = new Supplier();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplierId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                supplier.Id = Convert.ToInt64(reader["Id"].ToString());
                                supplier.Counter = Convert.ToInt64(reader["Counter"].ToString());
                                supplier.SupplierId = reader["SupplierId"].ToString();
                                supplier.Name = reader["Name"].ToString();
                                supplier.Address = reader["Address"].ToString();
                                supplier.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                supplier.Email = reader["Email"].ToString();
                                supplier.Owner = reader["Owner"].ToString();
                                supplier.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                supplier.UpdatedDate = reader.IsDBNull(9) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

            return supplier;
        }

        public long GetLastSupplierId()
        {
            long id = 0;
            string query = @"SELECT " +
                "TOP 1 [Counter] " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "ORDER BY [Counter] DESC ";

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
                            id = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return id;
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SUPPLIER + " " +
                    "( " +
                        "[EndOfDay], [Counter], [SupplierId], [Name], [Address], [ContactNo], [Email], [Owner], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "(  " +
                        "@EndOfDay, @Counter, @SupplierId, @Name, @Address, @ContactNo, @Email, @Owner, @AddedBy, @AddedDate " +
                    ")";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", supplier.EndOfDay);
                        command.Parameters.AddWithValue("@Counter", supplier.Counter);
                        command.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@ContactNo", supplier.ContactNo);
                        command.Parameters.AddWithValue("@Email", supplier.Email);
                        command.Parameters.AddWithValue("@Owner", supplier.Owner);
                        command.Parameters.AddWithValue("@AddedBy", supplier.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", supplier.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return supplier;
        }

        // Atomic Transaction
        public UserTransaction AddSupplierPayment(UserTransaction userTransaction, BankTransaction bankTransaction, string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Add row into the user transaction table
                        string insertUserTransaction = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                            "(" +
                                "[EndOfDay], [Action], [ActionType], " +
                                "[PartyId], [PartyNumber], [BankName], [Narration], " +
                                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                                "[AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @Action, @ActionType, " +
                                "@PartyId, @PartyNumber, @BankName, @Narration, " +
                                "@DueReceivedAmount, @DuePaymentAmount, @ReceivedAmount, @PaymentAmount, " +
                                "@AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", userTransaction.EndOfDay);
                            command.Parameters.AddWithValue("@Action", userTransaction.Action);
                            command.Parameters.AddWithValue("@ActionType", userTransaction.ActionType);
                            command.Parameters.AddWithValue("@PartyId", ((object)userTransaction.PartyId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@PartyNumber", ((object)userTransaction.PartyNumber) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@BankName", ((object)userTransaction.BankName) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Narration", ((object)userTransaction.Narration) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DueReceivedAmount", ((object)userTransaction.DueReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@DuePaymentAmount", ((object)userTransaction.DuePaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@ReceivedAmount", ((object)userTransaction.ReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@PaymentAmount", ((object)userTransaction.PaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@AddedBy", userTransaction.AddedBy);
                            command.Parameters.AddWithValue("@AddedDate", userTransaction.AddedDate);

                            command.ExecuteNonQuery();
                        }

                        // Get the last id from the user transaction table
                        long lastUserTransactionId = 0;
                        string selectLastTransaction = @"SELECT " +
                            "TOP 1 " +
                            "[Id] " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND ([PartyNumber] IS NOT NULL " +
                            "AND DATALENGTH([PartyNumber]) > 0) " +
                            "AND [Action] = '" + Constants.PAYMENT + "' " +
                            "AND [AddedBy] = @AddedBy " +
                            "ORDER BY[Id] DESC ";

                        using (SqlCommand command = new SqlCommand(selectLastTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@AddedBy", ((object)username) ?? DBNull.Value);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lastUserTransactionId = Convert.ToInt64(reader["Id"].ToString());
                                }
                            }
                        }

                        // Insert into bank transaction table
                        bankTransaction.TransactionId = lastUserTransactionId;
                        string insertBankTransaction = @"INSERT INTO " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "( " +
                                "[EndOfDay], [BankId], [Type], [Action], [TransactionId], [Debit], [Credit], [Narration], [AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @BankId, @Type, @Action, @TransactionId, @Debit, @Credit, @Narration, @AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertBankTransaction, connection, sqlTransaction))
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

                        sqlTransaction.Commit();
                    }
                    catch
                    {
                        userTransaction = null;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return userTransaction;
        }

        public Supplier UpdateSupplier(string supplierId, Supplier supplier)
        {
            string query = @"UPDATE " + Constants.TABLE_SUPPLIER + " " +
                "SET " +
                "[SupplierId] = @SupplierId, " +
                "[Name] = @Name, " +
                "[Address] = @Address, " +
                "[ContactNo] = @ContactNo, " +
                "[Email] = @Email, " +
                "[Owner] = @Owner, " +
                "[UpdatedBy] = @UpdatedBy, " +
                "[UpdatedDate] = @UpdatedDate " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplierId);
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@ContactNo", supplier.ContactNo);
                        command.Parameters.AddWithValue("@Email", supplier.Email);
                        command.Parameters.AddWithValue("@Owner", supplier.Owner);
                        command.Parameters.AddWithValue("@UpdatedBy", supplier.UpdatedBy);
                        command.Parameters.AddWithValue("@UpdatedDate", supplier.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return supplier;
        }

        public bool DeleteSupplier(string name)
        {
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "WHERE 1 = 1 " +
                "AND [Name] = @Name ";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
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

        // Atomic Transaction
        public bool DeleteSupplierPayment(long id)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from bank transaction table
                        var deleteBankTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [Action] = '" + Constants.PAYMENT + "' " +
                            "AND [TransactionId] = @TransactionId ";

                        using (SqlCommand command = new SqlCommand(deleteBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@TransactionId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from user transaction table
                        string deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [Action] = '" + Constants.PAYMENT + "' " +
                            "AND [Id] = @Id ";

                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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
