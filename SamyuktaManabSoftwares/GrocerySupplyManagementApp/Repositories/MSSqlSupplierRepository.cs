using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlSupplierRepository : ISupplierRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";

        public MSSqlSupplierRepository()
        {

        }

        /// <summary>
        /// Returns list of suppliers
        /// </summary>
        /// <returns>List of Suppliers</returns>
        public IEnumerable<Supplier> GetSuppliers()
        {
            var suppliers = new List<Supplier>();
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM Supplier";
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
                            var supplier = new Supplier
                            {
                                Id = Convert.ToInt64(reader["Id"].ToString()),
                                SupplierId = reader["SupplierId"].ToString(),
                                Name = reader["Name"].ToString(),
                                Address = reader["Address"].ToString(),
                                ContactNumber = Convert.ToInt64(reader["ContactNumber"].ToString()),
                                Email = reader["Email"].ToString()
                            };

                            suppliers.Add(supplier);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return suppliers;
        }

        /// <summary>
        /// Returns a supplier with matching supplier id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns>Supplier</returns>
        public Supplier GetSupplier(string supplierId)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM Supplier WHERE SupplierId = @SupplierId";
            var supplier = new Supplier();
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
                            supplier.Id = Convert.ToInt64(reader["Id"].ToString());
                            supplier.SupplierId = reader["SupplierId"].ToString();
                            supplier.Name = reader["Name"].ToString();
                            supplier.Address = reader["Address"].ToString();
                            supplier.ContactNumber = Convert.ToInt64(reader["ContactNumber"].ToString());
                            supplier.Email = reader["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return supplier;
        }

        /// <summary>
        /// Add a new supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns>Supplier</returns>
        public Supplier AddSupplier(Supplier supplier)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO Supplier " +
                            "(" +
                                "SupplierId, Name, Address, ContactNumber, Email " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@SupplierId, @Name, @Address, @ContactNumber, @Email " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@ContactNumber", supplier.ContactNumber);
                        command.Parameters.AddWithValue("@Email", supplier.Email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return supplier;
        }

        /// <summary>
        /// Update supplier with supplier id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="supplier"></param>
        /// <returns>Supplier</returns>
        public Supplier UpdateSupplier(string supplierId, Supplier supplier)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE Supplier SET " +
                    "SupplierId = @SupplierId, " +
                    "Name = @Name, " +
                    "Address = @Address, " +
                    "ContactNumber = @ContactNumber, " +
                    "Email = @Email " +
                    "WHERE " +
                    "SupplierId = @SupplierId";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplierId);
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@ContactNumber", supplier.ContactNumber);
                        command.Parameters.AddWithValue("@Email", supplier.Email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return supplier;
        }

        /// <summary>
        /// Delete supplier with supplier id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns>bool</returns>
        public bool DeleteSupplier(string supplierId)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM Supplier " +
                    "WHERE " +
                    "SupplierId = @SupplierId";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplierId);
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
