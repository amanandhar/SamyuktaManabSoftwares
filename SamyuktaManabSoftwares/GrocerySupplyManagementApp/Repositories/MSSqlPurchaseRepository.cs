using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPurchaseRepository : IPurchaseRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";

        public MSSqlPurchaseRepository()
        {

        }

        /// <summary>
        /// Returns list of purchases
        /// </summary>
        /// <returns>List of Purchases</returns>
        public IEnumerable<Purchase> GetPurchases()
        {
            var purchases = new List<Purchase>();
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM Purchase";
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
                            var purchase = new Purchase
                            {
                                Id = Convert.ToInt64(reader["Id"].ToString()),
                                PurchaseId = Convert.ToInt64(reader["PurchaseId"].ToString()),
                                ItemName = reader["ItemName"].ToString(),
                                BrandName = reader["BrandName"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                BillNo = reader["BillNo"].ToString()
                            };

                            purchases.Add(purchase);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchases;
        }

        /// <summary>
        /// Returns a purchase with matching purchase id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns>Purchase</returns>
        public Purchase GetPurchase(string purchaseId)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM Purchase WHERE PurchaseId = @PurchaseId";
            var purchase = new Purchase();
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
                            purchase.Id = Convert.ToInt64(reader["Id"].ToString());
                            purchase.PurchaseId = Convert.ToInt64(reader["PurchaseId"].ToString());
                            purchase.ItemName = reader["ItemName"].ToString();
                            purchase.BrandName = reader["BrandName"].ToString();
                            purchase.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                            purchase.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                            purchase.BillNo = reader["BillNo"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchase;
        }

        /// <summary>
        /// Add a new purchase
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns>Purchase</returns>
        public Purchase AddPurchase(Purchase purchase)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO Purchase " +
                            "(" +
                                "PurchaseId, ItemName, BrandName, Quantity, TotalAmount, BillNo " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@PurchaseId, @ItemName, @BrandName, @Quantity, @TotalAmount, @BillNo " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseId", purchase.PurchaseId);
                        command.Parameters.AddWithValue("@ItemName", purchase.ItemName);
                        command.Parameters.AddWithValue("@BrandName", purchase.BrandName);
                        command.Parameters.AddWithValue("@Quantity", purchase.Quantity);
                        command.Parameters.AddWithValue("@TotalAmount", purchase.TotalAmount);
                        command.Parameters.AddWithValue("@BillNo", purchase.BillNo);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchase;
        }

        /// <summary>
        /// Update purchase with purchase id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="purchase"></param>
        /// <returns>Purchase</returns>
        public Purchase UpdatePurchase(string purchaseId, Purchase purchase)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE Purchase SET " +
                    "PurchaseId = @PurchaseId, " +
                    "ItemName = @ItemName, " +
                    "BrandName = @BrandName, " +
                    "Quantity = @Quantity, " +
                    "TotalAmount = @TotalAmount, " +
                    "BillNo = @BillNo " +
                    "WHERE " +
                    "PurchaseId = @PurchaseId";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseId", purchase.PurchaseId);
                        command.Parameters.AddWithValue("@ItemName", purchase.ItemName);
                        command.Parameters.AddWithValue("@BrandName", purchase.BrandName);
                        command.Parameters.AddWithValue("@Quantity", purchase.Quantity);
                        command.Parameters.AddWithValue("@TotalAmount", purchase.TotalAmount);
                        command.Parameters.AddWithValue("@BillNo", purchase.BillNo);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchase;
        }

        /// <summary>
        /// Delete purchase with purchase id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns>bool</returns>
        public bool DeletePurchase(string purchaseId)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM Purchase " +
                    "WHERE " +
                    "PurchaseId = @PurchaseId";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseId", purchaseId);
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

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
