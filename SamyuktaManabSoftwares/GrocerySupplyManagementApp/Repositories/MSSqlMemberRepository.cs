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
        private readonly string connectionString;

        public MSSqlMemberRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Member> GetMembers()
        {
            var members = new List<Member>();
            var query = @"SELECT " +
                "[Id], [Counter], [MemberId], [Name], " +
                "[Address], [ContactNo], [Email], [AccountNo], " +
                "[Date] " +
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
                                    Counter = Convert.ToInt64(reader["Counter"].ToString()),
                                    MemberId = reader["MemberId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    ContactNo = Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    AccountNo = reader["AccountNo"].ToString(),
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
                                };

                                members.Add(member);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return members;
        }

        public Member GetMember(string memberId)
        {
            var query = @"SELECT " +
                "[Id], [Counter], [MemberId], [Name], " +
                "[Address], [ContactNo], [Email], [AccountNo], " +
                "[Date] " +
                "FROM " + Constants.TABLE_MEMBER + " " +
                "WHERE 1 = 1 " +
                "AND [MemberId] = @MemberId ";
            var member = new Member();
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
                                member.Counter = Convert.ToInt64(reader["Counter"].ToString());
                                member.MemberId = reader["MemberId"].ToString();
                                member.Name = reader["Name"].ToString();
                                member.Address = reader["Address"].ToString();
                                member.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                member.Email = reader["Email"].ToString();
                                member.AccountNo = reader["AccountNo"].ToString();
                                member.Date = Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public Member AddMember(Member member)
        {
            string query = @"INSERT INTO " + Constants.TABLE_MEMBER + " " +
                    "( " +
                        "[Counter], [MemberId], [Name], [Address], [ContactNo], [Email], [AccountNo], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Counter, @MemberId, @Name, @Address, @ContactNo, @Email, @AccountNo, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Counter", member.Counter);
                        command.Parameters.AddWithValue("@MemberId", member.MemberId);
                        command.Parameters.AddWithValue("@Name", member.Name);
                        command.Parameters.AddWithValue("@Address", member.Address);
                        command.Parameters.AddWithValue("@ContactNo", member.ContactNo);
                        command.Parameters.AddWithValue("@Email", member.Email);
                        command.Parameters.AddWithValue("@AccountNo", member.AccountNo);
                        command.Parameters.AddWithValue("@Date", member.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public Member UpdateMember(string memberId, Member member)
        {
            string query = @"UPDATE " + Constants.TABLE_MEMBER + " " +
                "SET " +
                "[Counter] = @Counter, " +
                "[MemberId] = @MemberId, " +
                "[Name] = @Name, " +
                "[Address] = @Address, " +
                "[ContactNo] = @ContactNo, " +
                "[Email] = @Email, " +
                "[AccountNo] = @AccountNo " +
                "WHERE 1 = 1 " +
                "AND [MemberId] = @MemberId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Counter", member.Counter);
                        command.Parameters.AddWithValue("@MemberId", memberId);
                        command.Parameters.AddWithValue("@Name", member.Name);
                        command.Parameters.AddWithValue("@Address", member.Address);
                        command.Parameters.AddWithValue("@ContactNumber", member.ContactNo);
                        command.Parameters.AddWithValue("@Email", member.Email);
                        command.Parameters.AddWithValue("@AccountNo", member.AccountNo);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public bool DeleteMember(string memberId)
        {
            string query = @"DELETE FROM " + Constants.TABLE_MEMBER + " " +
                    "WHERE 1 = 1 " +
                    "AND [MemberId] = @MemberId ";
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
                throw new Exception(ex.Message);
            }

            return result;
        }

        public int GetLastMemberId()
        {
            int id = 0;
            string query = @"SELECT " +
                "TOP 1 [Counter] " +
                "FROM " + Constants.TABLE_MEMBER + " " + 
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
                throw new Exception(ex.Message);
            }

            return id;
        }
    }
}
