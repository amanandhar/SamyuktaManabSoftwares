using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlSupplierRepository : ISupplierRepository
    {
        private readonly string connectionString;

        public MSSqlSupplierRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            var suppliers = new List<Supplier>();
            var query = @"SELECT " +
                "* " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "ORDER BY SupplierId ";
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

        public Supplier GetSupplier(string name)
        {
            var query = @"SELECT " +
                "* " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "WHERE 1 = 1 " +
                "AND Name = @Name ";
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

        public Supplier AddSupplier(Supplier supplier)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SUPPLIER + " " +
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

        public Supplier UpdateSupplier(string id, Supplier supplier)
        {
            string query = @"UPDATE " + Constants.TABLE_SUPPLIER + " " +
                "SET " +
                "SupplierId = @SupplierId, " +
                "Name = @Name, " +
                "Owner = @Owner, " +
                "Address = @Address, " +
                "ContactNumber = @ContactNumber, " +
                "Email = @Email " +
                "WHERE 1 = 1 " +
                "AND SupplierId = @SupplierId ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", id);
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

        public bool DeleteSupplier(string name)
        {
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "WHERE 1 = 1 " +
                "AND Name = @Name ";
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
    }
}
