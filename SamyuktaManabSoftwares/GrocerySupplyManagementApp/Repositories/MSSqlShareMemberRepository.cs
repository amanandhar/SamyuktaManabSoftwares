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
    public class MSSqlShareMemberRepository : IShareMemberRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlShareMemberRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<ShareMemberView> GetShareMembers()
        {
            var shareMemberViewList = new List<ShareMemberView>();
            var query = @"SELECT " +
                "sm.[Id], sm.[Name], sm.[ContactNo], (bt.[Debit] - bt.[Credit]) AS [Balance] " +
                "FROM " + Constants.TABLE_SHARE_MEMBER + " sm " +
                "LEFT JOIN " + Constants.TABLE_BANK_TRANSACTION + " bt " +
                "ON sm.[Id] = bt.[TransactionId] " +
                "WHERE 1 = 1 " +
                "ORDER BY sm.[Name] ";

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
                                var shareMemberView = new ShareMemberView
                                {
                                    Id = reader.IsDBNull(0) ? 0 : Convert.ToInt64(reader["Id"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    ContactNo = reader.IsDBNull(2) ? 0 : Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Balance = reader.IsDBNull(3) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Balance"].ToString())
                                };

                                shareMemberViewList.Add(shareMemberView);
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

            return shareMemberViewList;
        }

        public ShareMember GetShareMember(long id)
        {
            var query = @"SELECT " +
                "[Id], [Name], " +
                "[Address], [ContactNo], [ImagePath], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_SHARE_MEMBER + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";
            var shareMember = new ShareMember();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                shareMember.Id = Convert.ToInt64(reader["Id"].ToString());
                                shareMember.Name = reader["Name"].ToString();
                                shareMember.Address = reader["Address"].ToString();
                                shareMember.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                shareMember.ImagePath = reader["ImagePath"].ToString();
                                shareMember.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                shareMember.UpdatedDate = reader.IsDBNull(6) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

            return shareMember;
        }

        public IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(ShareMemberTransactionFilter shareMemberTransactionFilter)
        {
            var shareMemberTransactionViewList = new List<ShareMemberTransactionView>();
            var query = @"SELECT " +
                "sm.[Id], sm.[EndOfDay], sm.[Name], sm.[ContactNo], " +
                "bt.[Narration] AS [Description], " +
                "CASE WHEN bt.[Type] = 1 THEN '" + Constants.DEPOSIT + "' ELSE '" + Constants.WITHDRAWL + "' END AS [Type], " +
                "bt.[Debit], bt.[Credit], (bt.[Debit] - bt.[Credit]) AS [Balance] " +
                "FROM " + Constants.TABLE_SHARE_MEMBER + " sm " +
                "INNER JOIN " + Constants.TABLE_BANK_TRANSACTION + " bt " +
                "ON sm.[Id] = bt.[TransactionId] " +
                "WHERE 1 = 1 " +
                "AND bt.[Action] = '" + Constants.SHARE_CAPITAL + "' ";

            if (!string.IsNullOrWhiteSpace(shareMemberTransactionFilter?.DateFrom))
            {
                query += "AND sm.[EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(shareMemberTransactionFilter?.DateTo))
            {
                query += "AND sm.[EndOfDay] <= @DateTo ";
            }

            if (shareMemberTransactionFilter?.ShareMemberId != 0)
            {
                query += "AND sm.[Id] = @Id ";
            }

            query += "ORDER BY sm.[AddedDate] DESC ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)shareMemberTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)shareMemberTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Id", ((object)shareMemberTransactionFilter?.ShareMemberId) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var shareMemberTransactionView = new ShareMemberTransactionView
                                {
                                    Id = reader.IsDBNull(0) ? 0 : Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDay = reader["EndOfDay"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    ContactNo = reader.IsDBNull(3) ? 0 : Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Description = reader["Description"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    Debit = reader.IsDBNull(6) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Debit"].ToString()),
                                    Credit = reader.IsDBNull(7) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Credit"].ToString()),
                                    Balance = reader.IsDBNull(8) ? Constants.DEFAULT_DECIMAL_VALUE : Convert.ToDecimal(reader["Balance"].ToString())
                                };

                                shareMemberTransactionViewList.Add(shareMemberTransactionView);
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

            return shareMemberTransactionViewList;
        }

        public ShareMember AddShareMember(ShareMember shareMember)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SHARE_MEMBER + " " +
                    "( " +
                        "[EndOfDay], [Name], [Address], [ContactNo], [ImagePath], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Name, @Address, @ContactNo, @ImagePath, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", shareMember.EndOfDay);
                        command.Parameters.AddWithValue("@Name", shareMember.Name);
                        command.Parameters.AddWithValue("@Address", shareMember.Address);
                        command.Parameters.AddWithValue("@ContactNo", shareMember.ContactNo);
                        command.Parameters.AddWithValue("@ImagePath", ((object)shareMember.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", shareMember.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", shareMember.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return shareMember;
        }

        public ShareMember UpdateShareMember(long id, ShareMember shareMember)
        {
            string query = @"UPDATE " + Constants.TABLE_SHARE_MEMBER + " " +
                "SET " +
                "[Name] = @Name, " +
                "[Address] = @Address, " +
                "[ContactNo] = @ContactNo, " +
                "[ImagePath] = @ImagePath, " +
                "[UpdatedBy] = @UpdatedBy, " +
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
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Name", shareMember.Name);
                        command.Parameters.AddWithValue("@Address", shareMember.Address);
                        command.Parameters.AddWithValue("@ContactNo", shareMember.ContactNo);
                        command.Parameters.AddWithValue("@ImagePath", ((object)shareMember.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", shareMember.UpdatedBy);
                        command.Parameters.AddWithValue("@UpdatedDate", shareMember.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return shareMember;
        }

        public bool DeleteShareMember(long id)
        {
            string query = @"DELETE FROM " + Constants.TABLE_SHARE_MEMBER + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id ";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
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
