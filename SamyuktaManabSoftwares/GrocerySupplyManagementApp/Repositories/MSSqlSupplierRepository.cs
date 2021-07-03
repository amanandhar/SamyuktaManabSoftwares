using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlSupplierRepository : ISupplierRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "Supplier";

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
            var query = @"SELECT * FROM " + TABLE_NAME + " ORDER BY SupplierId";
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
                                var supplier = new Supplier
                                {
                                    SupplierId = reader["SupplierId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Owner = reader["Owner"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    ContactNumber = Convert.ToInt64(reader["ContactNumber"].ToString()),
                                    Email = reader["Email"].ToString()
                                };

                                suppliers.Add(supplier);
                            }
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
        /// Returns a supplier with matching supplier name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Supplier</returns>
        public Supplier GetSupplier(string name)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM " + TABLE_NAME + " WHERE Name = @Name";
            var supplier = new Supplier();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                supplier.SupplierId = reader["SupplierId"].ToString();
                                supplier.Name = reader["Name"].ToString();
                                supplier.Owner = reader["Owner"].ToString();
                                supplier.Address = reader["Address"].ToString();
                                supplier.ContactNumber = Convert.ToInt64(reader["ContactNumber"].ToString());
                                supplier.Email = reader["Email"].ToString();
                            }
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
            string query = "INSERT INTO " + TABLE_NAME + " " +
                            "( " +
                                "SupplierId, Name, Owner, Address, ContactNumber, Email " +
                            ") " +
                            "VALUES " +
                            "(  " +
                                "@SupplierId, @Name, @Owner, @Address, @ContactNumber, @Email " +
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
                        command.Parameters.AddWithValue("@Owner", supplier.Owner);
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
        /// Update supplier with supplier name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="supplier"></param>
        /// <returns>Supplier</returns>
        public Supplier UpdateSupplier(string name, Supplier supplier)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE " + TABLE_NAME + " SET " +
                    "SupplierId = @SupplierId, " +
                    "Name = @Name, " +
                    "Owner = @Owner, " +
                    "Address = @Address, " +
                    "ContactNumber = @ContactNumber, " +
                    "Email = @Email " +
                    "WHERE " +
                    "Name = @Name";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Owner", supplier.Owner);
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
        /// Delete supplier with supplier name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        public bool DeleteSupplier(string name)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM " + TABLE_NAME + " " +
                    "WHERE " +
                    "Name = @Name";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
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
