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
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlUserRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<User> GetUsers(string username, string type)
        {
            var users = new List<User>();
            var query = @"SELECT " +
                "[Id], [Username], [Type], " +
                "[Password], [IsReadOnly], [Bank], [DailySummary], " +
                "[DailyTransaction], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Reports], [Settings], " +
                "[StockSummary], [Supplier], [AddedDate], [UpdatedDate] " +
                "FROM [" + Constants.TABLE_USER + "] " +
                "WHERE 1 = 1 ";

            if(type == Constants.STAFF || type == Constants.GUEST)
            {
                query += "AND ISNULL([Username], '') = @Username ";
            }

            query += "ORDER BY [Username] ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)username) ?? DBNull.Value);

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
                                    DailySummary = Convert.ToBoolean(reader["DailySummary"].ToString()),
                                    DailyTransaction = Convert.ToBoolean(reader["DailyTransaction"].ToString()),
                                    Employee = Convert.ToBoolean(reader["Employee"].ToString()),
                                    EOD = Convert.ToBoolean(reader["EOD"].ToString()),
                                    ItemPricing = Convert.ToBoolean(reader["ItemPricing"].ToString()),
                                    Member = Convert.ToBoolean(reader["Member"].ToString()),
                                    POS = Convert.ToBoolean(reader["POS"].ToString()),
                                    Reports = Convert.ToBoolean(reader["Reports"].ToString()),
                                    Settings = Convert.ToBoolean(reader["Settings"].ToString()),
                                    StockSummary = Convert.ToBoolean(reader["StockSummary"].ToString()),
                                    Supplier = Convert.ToBoolean(reader["Supplier"].ToString()),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = reader.IsDBNull(18) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                users.Add(user);
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

            return users;
        }

        public User GetUser(long id)
        {
            var user = new User();
            var query = @"SELECT " +
                "[Id], [Username], [Type], " +
                "[Password], [IsReadOnly], [Bank], [DailySummary], " +
                "[DailyTransaction], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Reports], [Settings], " +
                "[StockSummary], [Supplier], [AddedDate], [UpdatedDate] " +
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
                                    user.DailySummary = Convert.ToBoolean(reader["DailySummary"].ToString());
                                    user.DailyTransaction = Convert.ToBoolean(reader["DailyTransaction"].ToString());
                                    user.Employee = Convert.ToBoolean(reader["Employee"].ToString());
                                    user.EOD = Convert.ToBoolean(reader["EOD"].ToString());
                                    user.ItemPricing = Convert.ToBoolean(reader["ItemPricing"].ToString());
                                    user.Member = Convert.ToBoolean(reader["Member"].ToString());
                                    user.POS = Convert.ToBoolean(reader["POS"].ToString());
                                    user.Reports = Convert.ToBoolean(reader["Reports"].ToString());
                                    user.Settings = Convert.ToBoolean(reader["Settings"].ToString());
                                    user.StockSummary = Convert.ToBoolean(reader["StockSummary"].ToString());
                                    user.Supplier = Convert.ToBoolean(reader["Supplier"].ToString());
                                    user.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    user.UpdatedDate = reader.IsDBNull(18) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
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

            return user;
        }

        public User GetUser(string username)
        {
            var user = new User();
            var query = @"SELECT " +
                "[Id], [Username], [Type], " +
                "[Password], [IsReadOnly], [Bank], [DailySummary], " +
                "[DailyTransaction], [Employee], [EOD], [ItemPricing], " +
                "[Member], [POS], [Reports], [Settings], " +
                "[StockSummary], [Supplier], [AddedDate], [UpdatedDate] " +
                "FROM [" + Constants.TABLE_USER + "] " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Username], '') = @Username ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)username) ?? DBNull.Value);
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
                                    user.DailySummary = Convert.ToBoolean(reader["DailySummary"].ToString());
                                    user.DailyTransaction = Convert.ToBoolean(reader["DailyTransaction"].ToString());
                                    user.Employee = Convert.ToBoolean(reader["Employee"].ToString());
                                    user.EOD = Convert.ToBoolean(reader["EOD"].ToString());
                                    user.ItemPricing = Convert.ToBoolean(reader["ItemPricing"].ToString());
                                    user.Member = Convert.ToBoolean(reader["Member"].ToString());
                                    user.POS = Convert.ToBoolean(reader["POS"].ToString());
                                    user.Reports = Convert.ToBoolean(reader["Reports"].ToString());
                                    user.Settings = Convert.ToBoolean(reader["Settings"].ToString());
                                    user.StockSummary = Convert.ToBoolean(reader["StockSummary"].ToString());
                                    user.Supplier = Convert.ToBoolean(reader["Supplier"].ToString());
                                    user.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    user.UpdatedDate = reader.IsDBNull(18) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
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

            return user;
        }

        public bool IsUserExist(string username)
        {
            var result = false;
            var query = @"SELECT " +
                "1 " +
                "FROM [" + Constants.TABLE_USER + "] " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Username], '') = @Username ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", ((object)username) ?? DBNull.Value);
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

        public bool IsUserExist(string username, string password)
        {
            var result = false;
            var query = @"SELECT " +
                "1 " +
                "FROM [" + Constants.TABLE_USER + "] " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Username], '') = @Username " +
                "AND ISNULL([Password], '') = @Password ";

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
                logger.Error(ex);
                throw ex;
            }

            return result;
        }

        public User AddUser(User user)
        {
            string query = @"INSERT INTO " +
                    " [" + Constants.TABLE_USER + "] " +
                    "( " +
                        "[Username], [Type], " +
                        "[Password], [IsReadOnly], [Bank], [DailySummary], " +
                        "[DailyTransaction], [Employee], [EOD], [ItemPricing], " +
                        "[Member], [POS], [Reports], [Settings], " +
                        "[StockSummary], [Supplier], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Username, @Type, " +
                        "@Password, @IsReadOnly, @Bank, @DailySummary, " +
                        "@DailyTransaction, @Employee, @EOD, @ItemPricing, " +
                        "@Member, @POS, @Reports, @Settings, " +
                        "@StockSummary, @Supplier, @AddedBy, @AddedDate " +
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
                        command.Parameters.AddWithValue("@DailySummary", ((object)user.DailySummary) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailyTransaction", ((object)user.DailyTransaction) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Employee", ((object)user.Employee) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EOD", ((object)user.EOD) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemPricing", ((object)user.ItemPricing) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Member", ((object)user.Member) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@POS", ((object)user.POS) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Reports", ((object)user.Reports) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Settings", ((object)user.Settings) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StockSummary", ((object)user.StockSummary) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Supplier", ((object)user.Supplier) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", ((object)user.AddedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)user.AddedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return user;
        }

        public User UpdateUser(string username, User user)
        {
            string query = @"UPDATE [" + Constants.TABLE_USER + "] " +
                    "SET " +
                    "[Type] = @Type, " +
                    "[Password] = @Password, [IsReadOnly] = @IsReadOnly, [Bank] = @Bank, " +
                    "[DailySummary] = @DailySummary, [DailyTransaction] = @DailyTransaction, [Employee] = @Employee, " +
                    "[EOD] = @EOD, [ItemPricing] = @ItemPricing, [Member] = @Member, " +
                    "[POS] = @POS, [Reports] = @Reports, [Settings] = @Settings, " +
                    "[StockSummary] = @StockSummary, [Supplier] = @Supplier, [UpdatedBy] = @UpdatedBy, [UpdatedDate] = @UpdatedDate " +
                    "WHERE 1 = 1 " +
                    "AND ISNULL([Username], '') = @Username";
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
                        command.Parameters.AddWithValue("@DailySummary", ((object)user.DailySummary) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DailyTransaction", ((object)user.DailyTransaction) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Employee", ((object)user.Employee) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EOD", ((object)user.EOD) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemPricing", ((object)user.ItemPricing) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Member", ((object)user.Member) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@POS", ((object)user.POS) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Reports", ((object)user.Reports) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Settings", ((object)user.Settings) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StockSummary", ((object)user.StockSummary) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Supplier", ((object)user.Supplier) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", ((object)user.UpdatedBy) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)user.UpdatedDate) ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return user;
        }

        public bool DeleteUser(string username)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM [" + Constants.TABLE_USER + "] " +
                    "WHERE 1 = 1 " +
                    "AND ISNULL([Username], '') = @Username";
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
                logger.Error(ex);
                throw ex;
            }

            return result;
        }
    }
}
