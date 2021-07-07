using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlIncomeDetailRepository : IIncomeDetailRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        public IEnumerable<IncomeDetailView> GetIncomeDetails()
        {
            var incomeDetails = new List<IncomeDetailView>();
            string connectionString = GetConnectionString();
            var query = @"SELECT " +
                "pt.[InvoiceDate] AS 'InvoiceDate', psi.[InvoiceNo] AS 'InvoiceNo', " +
                "i.[Code] AS 'ItemCode', i.[Name] AS 'ItemName', i.[Brand] AS 'ItemBrand', " +
                "psi.[Quantity] AS 'Quantity', pi.[ProfitAmount] AS 'ProfitAmount', " +
                "CAST((psi.[Quantity] * pi.[ProfitAmount]) AS DECIMAL(18, 2)) AS 'Total' " +
                "FROM Item i " +
                "INNER JOIN " +
                "PreparedItem pi " +
                "ON i.Id = pi.ItemId " +
                "INNER JOIN " +
                "PosSoldItem psi " +
                "ON " +
                "i.Code = psi.ItemCode " +
                "INNER JOIN " +
                "PosTransaction pt " +
                "ON " +
                "psi.InvoiceNo = pt.InvoiceNo " +
                "WHERE 1=1 ";

            query += "ORDER BY Date DESC ";

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
                                var incomeDetail = new IncomeDetailView
                                {
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()).ToString("yyyy-MM-dd"),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    ItemName = reader["ItemName"].ToString(),
                                    ItemBrand = reader["ItemBrand"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                    ProfitAmount = Convert.ToDecimal(reader["Price"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"].ToString())
                                };

                                incomeDetails.Add(incomeDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return incomeDetails;
        }

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
