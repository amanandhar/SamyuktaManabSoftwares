using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlEndOfDayRepository : IEndOfDayRepository
    {
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
                throw new Exception(ex.Message);
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
                "AND [Id] > @Id" + 
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
                throw new Exception(ex.Message);
            }

            return endOfDay;
        }
    }
}
