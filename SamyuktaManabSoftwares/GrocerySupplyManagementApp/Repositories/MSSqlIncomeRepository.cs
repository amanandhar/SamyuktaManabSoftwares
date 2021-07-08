using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlIncomeRepository : IIncomeRepository
    {
        private readonly string connectionString;

        public MSSqlIncomeRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Income> GetIncomes()
        {
            var incomes = new List<Income>();
            var query = @"SELECT " +
                "[Id], [EndOfDate], [Type], [Amount], [Date] " +
                "FROM " + Constants.TABLE_INCOME;

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
                                var income = new Income
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    Type = reader["Type"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };

                                incomes.Add(income);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomes;
        }

        public Income GetIncome(long id)
        {
            throw new NotImplementedException();
        }

        public Income AddIncome(Income income)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_INCOME + " " +
                    "( " +
                        "[EndOfDate], [Type], [Amount], [Date] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDate, @Type, @Amount, @Date " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDate", ((object)income.EndOfDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)income.Type) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", ((object)income.Amount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Date", ((object)income.Date) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return income;
        }

        public bool DeleteIncome(long id)
        {
            throw new NotImplementedException();
        }

        public Income UpdateIncome(long id, Income income)
        {
            throw new NotImplementedException();
        }
    }
}
