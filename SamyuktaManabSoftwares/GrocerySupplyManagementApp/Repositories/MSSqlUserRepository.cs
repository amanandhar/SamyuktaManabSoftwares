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
                "[Id], [Username], [Type], " +
                "[Password], [IsReadOnly], [Bank], [DailyExpense], " +
                "[DailySummary], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Report], [Setting], " +
                "[Stock], [Supplier], [AddedDate], [UpdatedDate] " +
                "FROM [" + Constants.TABLE_USER + "] ";

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
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    IsReadOnly = Convert.ToBoolean(reader["IsReadOnly"].ToString()),
                                    Bank = Convert.ToBoolean(reader["Bank"].ToString()),
                                    DailyExpense = Convert.ToBoolean(reader["DailyExpense"].ToString()),
                                    DailySummary = Convert.ToBoolean(reader["DailySummary"].ToString()),
                                    Employee = Convert.ToBoolean(reader["Employee"].ToString()),
                                    EOD = Convert.ToBoolean(reader["EOD"].ToString()),
                                    ItemPricing = Convert.ToBoolean(reader["ItemPricing"].ToString()),
                                    Member = Convert.ToBoolean(reader["Member"].ToString()),
                                    POS = Convert.ToBoolean(reader["POS"].ToString()),
                                    Report = Convert.ToBoolean(reader["Report"].ToString()),
                                    Setting = Convert.ToBoolean(reader["Setting"].ToString()),
                                    Stock = Convert.ToBoolean(reader["Stock"].ToString()),
                                    Supplier = Convert.ToBoolean(reader["Supplier"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
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
                "[Id], [Username], [Type], " +
                "[Password], [IsReadOnly], [Bank], [DailyExpense], " +
                "[DailySummary], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Report], [Setting], " +
                "[Stock], [Supplier], [AddedDate], [UpdatedDate] " +
                "FROM [" + Constants.TABLE_USER + "] " + 
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
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    user.Id = Convert.ToInt64(reader["Id"].ToString());
                                    user.Username = reader["Username"].ToString();
                                    user.Password = reader["Password"].ToString();
                                    user.Type = reader["Type"].ToString();
                                    user.IsReadOnly = Convert.ToBoolean(reader["IsReadOnly"].ToString());
                                    user.Bank = Convert.ToBoolean(reader["Bank"].ToString());
                                    user.DailyExpense = Convert.ToBoolean(reader["DailyExpense"].ToString());
                                    user.DailySummary = Convert.ToBoolean(reader["DailySummary"].ToString());
                                    user.Employee = Convert.ToBoolean(reader["Employee"].ToString());
                                    user.EOD = Convert.ToBoolean(reader["EOD"].ToString());
                                    user.ItemPricing = Convert.ToBoolean(reader["ItemPricing"].ToString());
                                    user.Member = Convert.ToBoolean(reader["Member"].ToString());
                                    user.POS = Convert.ToBoolean(reader["POS"].ToString());
                                    user.Report = Convert.ToBoolean(reader["Report"].ToString());
                                    user.Setting = Convert.ToBoolean(reader["Setting"].ToString());
                                    user.Stock = Convert.ToBoolean(reader["Stock"].ToString());
                                    user.Supplier = Convert.ToBoolean(reader["Supplier"].ToString());
                                    user.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    user.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
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

        public bool IsUserExist(string username, string password)
        {
            var result = false;
            var query = @"SELECT " +
                "[Id], [Username], [Type], " +
                "[Password], [IsReadOnly], [Bank], [DailyExpense], " +
                "[DailySummary], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Report], [Setting], " +
                "[Stock], [Supplier], [AddedDate], [UpdatedDate] " +
                "FROM [" + Constants.TABLE_USER + "] " +
                "WHERE 1 = 1 " +
                "AND [Username] = @Username " +
                "AND [Password] = @Password ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)username) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", ((object)password) ?? DBNull.Value);
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
                throw new Exception(ex.Message);
            }

            return result;
        }

        public User AddUser(User user)
        {
            string query = @"INSERT INTO " +
                    " [" + Constants.TABLE_USER + "] " +
                    "( " +
                        "[Username], [Type], " +
                        "[Password], [IsReadOnly], [Bank], [DailyExpense], " +
                        "[DailySummary], [Employee], [EOD], [ItemPricing], " +
                        "[Member], [POS], [Report], [Setting], " +
                        "[Stock], [Supplier], [AddedDate], [UpdatedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Username, @Type, " +
                        "@Password, @IsReadOnly, @Bank, @DailyExpense, " +
                        "@DailySummary, @Employee, @EOD, @ItemPricing, " +
                        "@Member, @POS, @Report, @Setting, " +
                        "@Stock, @Supplier, @AddedDate, @UpdatedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)user.Username) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", ((object)user.Password) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)user.Type) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsReadOnly", ((object)user.IsReadOnly) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Bank", ((object)user.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailyExpense", ((object)user.DailyExpense) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailySummary", ((object)user.DailySummary) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Employee", ((object)user.Employee) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EOD", ((object)user.EOD) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemPricing", ((object)user.ItemPricing) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Member", ((object)user.Member) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@POS", ((object)user.POS) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Report", ((object)user.Report) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Setting", ((object)user.Setting) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Stock", ((object)user.Stock) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Supplier", ((object)user.Supplier) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)user.AddedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)user.UpdatedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

        public User UpdateUser(long id, User user)
        {
            string query = @"UPDATE [" + Constants.TABLE_USER + "] " +
                    "SET " +
                    "[Username] = @Username, [Type] = @Type, " +
                    "[Password] = @Password, [IsReadOnly] = @IsReadOnly, [Bank] = @Bank, " +
                    "[DailyExpense] = @DailyExpense, [DailySummary] = @DailySummary, [Employee] = @Employee, " +
                    "[EOD] = @EOD, [ItemPricing] = @ItemPricing, [Member] = @Member, " +
                    "[POS] = @POS, [Report] = @Report, [Setting] = @Setting, " +
                    "[Stock] = @Stock, [Supplier] = @Supplier, [UpdatedDate] = @UpdatedDate " +
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
                        command.Parameters.AddWithValue("@Username", ((object)user.Username) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", ((object)user.Password) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)user.Type) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsReadOnly", ((object)user.IsReadOnly) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Bank", ((object)user.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailyExpense", ((object)user.DailyExpense) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailySummary", ((object)user.DailySummary) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Employee", ((object)user.Employee) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EOD", ((object)user.EOD) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemPricing", ((object)user.ItemPricing) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Member", ((object)user.Member) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@POS", ((object)user.POS) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Report", ((object)user.Report) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Setting", ((object)user.Setting) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Stock", ((object)user.Stock) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Supplier", ((object)user.Supplier) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)user.UpdatedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

        public User UpdateUser(string username, User user)
        {
            string query = @"UPDATE [" + Constants.TABLE_USER + "] " +
                    "SET " +
                    "[Type] = @Type, " +
                    "[Password] = @Password, [IsReadOnly] = @IsReadOnly, [Bank] = @Bank, " +
                    "[DailyExpense] = @DailyExpense, [DailySummary] = @DailySummary, [Employee] = @Employee, " +
                    "[EOD] = @EOD, [ItemPricing] = @ItemPricing, [Member] = @Member, " +
                    "[POS] = @POS, [Report] = @Report, [Setting] = @Setting, " +
                    "[Stock] = @Stock, [Supplier] = @Supplier, [UpdatedDate] = @UpdatedDate " +
                    "WHERE 1 = 1 " +
                    "AND [Username] = @Username";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)username) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", ((object)user.Password) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)user.Type) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsReadOnly", ((object)user.IsReadOnly) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Bank", ((object)user.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailyExpense", ((object)user.DailyExpense) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailySummary", ((object)user.DailySummary) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Employee", ((object)user.Employee) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EOD", ((object)user.EOD) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemPricing", ((object)user.ItemPricing) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Member", ((object)user.Member) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@POS", ((object)user.POS) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Report", ((object)user.Report) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Setting", ((object)user.Setting) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Stock", ((object)user.Stock) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Supplier", ((object)user.Supplier) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)user.UpdatedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

        public bool UpdatePassword(string username, string password)
        {
            var result = false;
            string query = @"UPDATE [" + Constants.TABLE_USER + "] " +
                    "SET " +
                    "[Password] = @Password " +
                    "WHERE 1 = 1 " +
                    "AND [Username] = @Username";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)username) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", ((object)password) ?? DBNull.Value);

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

        public bool DeleteUser(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM [" + Constants.TABLE_USER + "] " +
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

        public bool DeleteUser(string username)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM [" + Constants.TABLE_USER + "] " +
                    "WHERE 1 = 1 " +
                    "AND [Username] = @Username";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)username) ?? DBNull.Value);
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
