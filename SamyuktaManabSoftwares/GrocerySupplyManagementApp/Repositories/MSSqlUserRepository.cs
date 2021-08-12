using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlUserRepository : IUserRepository
    {
        private readonly string connectionString;

        public MSSqlUserRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            var query = @"SELECT " +
                "[Id], [Counter], [UserId], [Username], " +
                "[Password], [IsReadOnly], [Bank], [DailyExpense], " +
                "[DailySummary], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Report], [Setting], " +
                "[Stock], [Supplier] " +
                "FROM " + Constants.TABLE_USER;

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
                                var user = new User
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Counter = Convert.ToInt64(reader["Id"].ToString()),
                                    UserId = reader["UserId"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    IsReadOnly = reader["IsReadOnly"].ToString() == "1",
                                    Bank = reader["Bank"].ToString() == "1",
                                    DailyExpense = reader["DailyExpense"].ToString() == "1",
                                    DailySummary = reader["DailySummary"].ToString() == "1",
                                    Employee = reader["Employee"].ToString() == "1",
                                    EOD = reader["EOD"].ToString() == "1",
                                    ItemPricing = reader["ItemPricing"].ToString() == "1",
                                    Member = reader["Member"].ToString() == "1",
                                    POS = reader["POS"].ToString() == "1",
                                    Report = reader["Report"].ToString() == "1",
                                    Setting = reader["Setting"].ToString() == "1",
                                    Stock = reader["Stock"].ToString() == "1",
                                    Supplier = reader["Supplier"].ToString() == "1"
                                };

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return users;
        }

        public User GetUser(long id)
        {
            var user = new User();
            var query = @"SELECT " +
                "[Id], [Counter], [UserId], [Username], " +
                "[Password], [IsReadOnly], [Bank], [DailyExpense], " +
                "[DailySummary], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Report], [Setting], " +
                "[Stock], [Supplier] " +
                "FROM " + Constants.TABLE_USER + " " +
                "WHERE 1 = 1 " +
                "[Id] = @Id ";

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
                                    user.Id = Convert.ToInt64(reader["Id"].ToString());
                                    user.Counter = Convert.ToInt64(reader["Id"].ToString());
                                    user.UserId = reader["UserId"].ToString();
                                    user.UserName = reader["UserName"].ToString();
                                    user.Password = reader["Password"].ToString();
                                    user.IsReadOnly = reader["IsReadOnly"].ToString() == "1";
                                    user.Bank = reader["Bank"].ToString() == "1";
                                    user.DailyExpense = reader["DailyExpense"].ToString() == "1";
                                    user.DailySummary = reader["DailySummary"].ToString() == "1";
                                    user.Employee = reader["Employee"].ToString() == "1";
                                    user.EOD = reader["EOD"].ToString() == "1";
                                    user.ItemPricing = reader["ItemPricing"].ToString() == "1";
                                    user.Member = reader["Member"].ToString() == "1";
                                    user.POS = reader["POS"].ToString() == "1";
                                    user.Report = reader["Report"].ToString() == "1";
                                    user.Setting = reader["Setting"].ToString() == "1";
                                    user.Stock = reader["Stock"].ToString() == "1";
                                    user.Supplier = reader["Supplier"].ToString() == "1";
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

            return user;
        }

        public User AddUser(User user)
        {
            return new User();
        }

        public User UpdateUser(long id, User user)
        {
            return new User();
        }

        public bool DeleteUser(long id)
        {
            return false;
        }
    }
}
