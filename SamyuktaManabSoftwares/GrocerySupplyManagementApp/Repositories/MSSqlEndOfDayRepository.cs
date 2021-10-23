using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlEndOfDayRepository : IEndOfDayRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlEndOfDayRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public EndOfDay GetEndOfDay(string date)
        {
            var endOfDay = new EndOfDay();
            var query = @"SELECT " +
                "[Id], [DateInAd], [DateInBs] " +
                "FROM " + Constants.TABLE_END_OF_DAY + " " +
                "WHERE 1 = 1 " +
                "AND [DateInBs] = @DateInBs";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateInBs", ((object)date) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    endOfDay.Id = Convert.ToInt64(reader["Id"].ToString());
                                    endOfDay.DateInAd = Convert.ToDateTime(reader["DateInAd"].ToString());
                                    endOfDay.DateInBs = reader["DateInBs"].ToString();
                                }
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

            return endOfDay;
        }

        public EndOfDay GetNextEndOfDay(long id)
        {
            var endOfDay = new EndOfDay();
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id], [DateInAd], [DateInBs] " +
                "FROM " + Constants.TABLE_END_OF_DAY + " " +
                "WHERE 1 = 1 " +
                "AND [Id] > @Id " + 
                "ORDER BY [Id]";

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
                                    endOfDay.Id = Convert.ToInt64(reader["Id"].ToString());
                                    endOfDay.DateInAd = Convert.ToDateTime(reader["DateInAd"].ToString());
                                    endOfDay.DateInBs = reader["DateInBs"].ToString();
                                }
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

            return endOfDay;
        }

        public bool IsEndOfDayExist(string endOfDay)
        {
            var result = false;
            var query = @"SELECT " +
                "TOP 1 " +
                "[Id] " +
                "FROM " + Constants.TABLE_END_OF_DAY + " " +
                "WHERE 1 = 1 " +
                "AND [DateInBs] = @DateInBS ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateInBS", ((object)endOfDay) ?? DBNull.Value);
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
    }
}
