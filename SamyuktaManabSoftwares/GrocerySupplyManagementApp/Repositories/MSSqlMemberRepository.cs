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
                UtilityService.ShowExceptionMessageBox();
            }

            return members;
        }

        public Member GetMember(string memberId)
        {
            var member = new Member();
            var query = @"SELECT " +
                "[Id], [MemberId], [Name], " +
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
                                member.Name = reader["Name"].ToString();
                                member.Address = reader["Address"].ToString();
                                member.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                member.Email = reader["Email"].ToString();
                                member.AccountNo = reader["AccountNo"].ToString();
                                member.ImagePath = reader["ImagePath"].ToString();
                                member.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                member.UpdatedDate = reader.IsDBNull(9) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }

        public Member AddMember(Member member)
        {
            string query = @"INSERT INTO " + Constants.TABLE_MEMBER + " " +
                    "( " +
                        "[EndOfDay], [MemberId], [Name], [Address], [ContactNo], [Email], [AccountNo], [ImagePath], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @MemberId, @Name, @Address, @ContactNo, @Email, @AccountNo, @ImagePath, @AddedBy, @AddedDate " +
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
                UtilityService.ShowExceptionMessageBox();
            }

            return member;
        }

        public Member UpdateMember(string memberId, Member member)
        {
            string query = @"UPDATE " + Constants.TABLE_MEMBER + " " +
                "SET " +
                "[MemberId] = @MemberId, " +
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
                UtilityService.ShowExceptionMessageBox();
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
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }
    }
}
