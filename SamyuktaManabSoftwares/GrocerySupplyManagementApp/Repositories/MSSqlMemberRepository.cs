﻿using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlMemberRepository : IMemberRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";

        public MSSqlMemberRepository()
        {

        }

        /// <summary>
        /// Returns list of members
        /// </summary>
        /// <returns>List of Members</returns>
        public IEnumerable<Member> GetMembers()
        {
            var members = new List<Member>();
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM Member";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var member = new Member
                            {
                                MemberId = reader["MemberId"].ToString(),
                                Name = reader["Name"].ToString(),
                                Address = reader["Address"].ToString(),
                                ContactNumber = Convert.ToInt64(reader["ContactNumber"].ToString()),
                                Email = reader["Email"].ToString(),
                                AccountNumber = reader["AccountNumber"].ToString()
                            };

                            members.Add(member);
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

        /// <summary>
        /// Returns a member with matching member id
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>Member</returns>
        public Member GetMember(string memberId)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM Member WHERE MemberId = @MemberId";
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
                                member.MemberId = reader["MemberId"].ToString();
                                member.Name = reader["Name"].ToString();
                                member.Address = reader["Address"].ToString();
                                member.ContactNumber = Convert.ToInt64(reader["ContactNumber"].ToString());
                                member.Email = reader["Email"].ToString();
                                member.AccountNumber = reader["AccountNumber"].ToString();
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

        /// <summary>
        /// Add a new member
        /// </summary>
        /// <param name="member"></param>
        /// <returns>Member</returns>
        public Member AddMember(Member member)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO Member " +
                            "(" +
                                "Id, MemberId, Name, Address, ContactNumber, Email, AccountNumber " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@Id, @MemberId, @Name, @Address, @ContactNumber, @Email, @AccountNumber " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", member.Id);
                        command.Parameters.AddWithValue("@MemberId", member.MemberId);
                        command.Parameters.AddWithValue("@Name", member.Name);
                        command.Parameters.AddWithValue("@Address", member.Address);
                        command.Parameters.AddWithValue("@ContactNumber", member.ContactNumber);
                        command.Parameters.AddWithValue("@Email", member.Email);
                        command.Parameters.AddWithValue("@AccountNumber", member.AccountNumber);

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

        /// <summary>
        /// Update member with member id
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="member"></param>
        /// <returns>Member</returns>
        public Member UpdateMember(string memberId, Member member)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE Member SET " +
                    "MemberId = @MemberId, " +
                    "Name = @Name, " +
                    "Address = @Address, " +
                    "ContactNumber = @ContactNumber, " +
                    "Email = @Email, " +
                    "AccountNumber = @AccountNumber " +
                    "WHERE " +
                    "MemberId = @MemberId";
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
                        command.Parameters.AddWithValue("@ContactNumber", member.ContactNumber);
                        command.Parameters.AddWithValue("@Email", member.Email);
                        command.Parameters.AddWithValue("@AccountNumber", member.AccountNumber);

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

        /// <summary>
        /// Delete member with member id
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>bool</returns>
        public bool DeleteMember(string memberId)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM Member " +
                    "WHERE " +
                    "MemberId = @MemberId";
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

        /// <summary>
        /// Get Last Member Id
        /// </summary>
        /// <returns>Id</returns>
        public int GetLastMemberId()
        {
            string connectionString = GetConnectionString();
            string query = "SELECT TOP 1 Id FROM Member ORDER BY Id DESC";
            int id = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        id = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
