using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlMemberRepository : IMemberRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlMemberRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Member> GetMembers()
        {
            var members = new List<Member>();
            var query = @"SELECT " +
                "[Id], [MemberId], [Name], " +
                "[Address], [ContactNo], [Email], [AccountNo], [ImagePath], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_MEMBER;
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
                                var member = new Member
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    MemberId = reader["MemberId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    ContactNo = Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    AccountNo = reader["AccountNo"].ToString(),
                                    ImagePath = reader["ImagePath"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = reader.IsDBNull(9) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                members.Add(member);
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

            return members;
        }

        public Member GetMember(string memberId)
        {
            var member = new Member();
            var query = @"SELECT " +
                "[Id], [MemberId], [ShareMemberId], [Name], " +
                "[Address], [ContactNo], [Email], [AccountNo], [ImagePath], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_MEMBER + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([MemberId], '') = @MemberId ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", memberId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                member.Id = Convert.ToInt64(reader["Id"].ToString());
                                member.MemberId = reader["MemberId"].ToString();
                                member.ShareMemberId = reader["ShareMemberId"].ToString();
                                member.Name = reader["Name"].ToString();
                                member.Address = reader["Address"].ToString();
                                member.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                member.Email = reader["Email"].ToString();
                                member.AccountNo = reader["AccountNo"].ToString();
                                member.ImagePath = reader["ImagePath"].ToString();
                                member.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                member.UpdatedDate = reader.IsDBNull(10) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

            return member;
        }

        public bool IsMemberExist(string memberId)
        {
            var result = false;
            var query = @"SELECT " +
                "1 " +
                "FROM " + Constants.TABLE_MEMBER + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([MemberId], '') = @MemberId ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", ((object)memberId) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                result = true;
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

            return result;
        }

        public Member AddMember(Member member)
        {
            string query = @"INSERT INTO " + Constants.TABLE_MEMBER + " " +
                    "( " +
                        "[EndOfDay], [MemberId], [ShareMemberId], [Name], [Address], [ContactNo], [Email], [AccountNo], [ImagePath], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @MemberId, @ShareMemberId, @Name, @Address, @ContactNo, @Email, @AccountNo, @ImagePath, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", member.EndOfDay);
                        command.Parameters.AddWithValue("@MemberId", member.MemberId);
                        command.Parameters.AddWithValue("@ShareMemberId", member.ShareMemberId);
                        command.Parameters.AddWithValue("@Name", member.Name);
                        command.Parameters.AddWithValue("@Address", member.Address);
                        command.Parameters.AddWithValue("@ContactNo", member.ContactNo);
                        command.Parameters.AddWithValue("@Email", member.Email);
                        command.Parameters.AddWithValue("@AccountNo", member.AccountNo);
                        command.Parameters.AddWithValue("@ImagePath", ((object)member.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", member.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", member.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return member;
        }

        // Atomic Transaction
        public UserTransaction AddMemberReceipt(UserTransaction userTransaction, BankTransaction bankTransaction, string username)
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
                            "AND [Action] = '" + Constants.RECEIPT + "' " +
                            "AND [AddedBy] = @AddedBy " +
                            "ORDER BY [Id] DESC ";

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

        public Member UpdateMember(string memberId, Member member)
        {
            string query = @"UPDATE " + Constants.TABLE_MEMBER + " " +
                "SET " +
                "[MemberId] = @MemberId, " +
                "[ShareMemberId] = @ShareMemberId, " +
                "[Name] = @Name, " +
                "[Address] = @Address, " +
                "[ContactNo] = @ContactNo, " +
                "[Email] = @Email, " +
                "[AccountNo] = @AccountNo, " +
                "[ImagePath] = @ImagePath, " +
                "[UpdatedBy] = @UpdatedBy, " +
                "[UpdatedDate] = @UpdatedDate " +
                "WHERE 1 = 1 " +
                "AND ISNULL([MemberId], '') = @MemberId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", memberId);
                        command.Parameters.AddWithValue("@ShareMemberId", member.ShareMemberId);
                        command.Parameters.AddWithValue("@Name", member.Name);
                        command.Parameters.AddWithValue("@Address", member.Address);
                        command.Parameters.AddWithValue("@ContactNo", member.ContactNo);
                        command.Parameters.AddWithValue("@Email", member.Email);
                        command.Parameters.AddWithValue("@AccountNo", member.AccountNo);
                        command.Parameters.AddWithValue("@ImagePath", ((object)member.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", member.UpdatedBy);
                        command.Parameters.AddWithValue("@UpdatedDate", member.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return member;
        }

        public bool DeleteMember(string memberId)
        {
            string query = @"DELETE FROM " + Constants.TABLE_MEMBER + " " +
                    "WHERE 1 = 1 " +
                    "AND ISNULL([MemberId], '') = @MemberId ";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", memberId);
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
        public bool DeleteMemberReceipt(long id)
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
                            "AND [Action] = '" + Constants.RECEIPT + "' " +
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
                            "AND [Action] = '" + Constants.RECEIPT + "' " +
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
