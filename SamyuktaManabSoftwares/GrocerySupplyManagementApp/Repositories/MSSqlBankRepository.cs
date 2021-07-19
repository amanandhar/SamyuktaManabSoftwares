﻿using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlBankRepository : IBankRepository
    {
        private readonly string connectionString;

        public MSSqlBankRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Bank> GetBanks()
        {
            var banks = new List<Bank>();
            var query = @"SELECT " +
                "[Id], [Name], [AccountNo], [Date] " +
                "FROM " + Constants.TABLE_BANK;

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
                                var bank = new Bank
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    AccountNo = reader["AccountNo"].ToString(),
                                    Date = reader.IsDBNull(3) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString()),
                                };

                                banks.Add(bank);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return banks;
        }

        public Bank GetBank(long id)
        {
            var banks = new Bank();
            var query = @"SELECT " +
                "[Id], [Name], [AccountNo], [Date] " +
                "FROM " + Constants.TABLE_BANK + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id";

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
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    banks.Id = Convert.ToInt64(reader["Id"].ToString());
                                    banks.Name = reader["Name"].ToString();
                                    banks.AccountNo = reader["AccountNo"].ToString();
                                    banks.Date = reader.IsDBNull(3) ? DateTime.Now : Convert.ToDateTime(reader["Date"].ToString());
                                }
                            }
                                
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return banks;
        }

        public Bank AddBank(Bank bank)
        {
            string query = @"INSERT INTO " + 
                    " " + Constants.TABLE_BANK + " " +
                    "( " +
                        "[Name], [AccountNo], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Name, @AccountNo, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", ((object)bank.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AccountNo", ((object)bank.AccountNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Date", ((object)bank.Date) ?? DBNull.Value);
                        command.ExecuteNonQuery();  
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bank;
        }

        public Bank UpdateBank(long id, Bank bank)
        {
            string query = @"UPDATE " + Constants.TABLE_BANK + " " +
                    "SET " + 
                    "[Name] = @Name, [AccountNo] = @AccountNo " +
                    "WHERE 1 = 1 " + 
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)bank.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AccountNo", ((object)bank.AccountNo) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bank;
        }

        public bool DeleteBank(long id)
        {
            bool result = false;
            string query = @"DELETE " + 
                    "FROM " + Constants.TABLE_BANK + " " +
                    "WHERE 1 = 1 " +
                    "[Id] = @Id";
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
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}