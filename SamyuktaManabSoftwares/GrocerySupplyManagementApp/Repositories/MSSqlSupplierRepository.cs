﻿using GrocerySupplyManagementApp.Entities;
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
                "[Id], [Counter], [SupplierId], [Name], " +
                "[Address], [ContactNo], [Email], [Owner], " +
                "[Date] " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "ORDER BY [SupplierId] ";
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
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Counter = Convert.ToInt64(reader["Counter"].ToString()),
                                    SupplierId = reader["SupplierId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    ContactNo = Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    Owner = reader["Owner"].ToString(),
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
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

        public Supplier GetSupplier(string supplierId)
        {
            var query = @"SELECT " +
                "[Id], [Counter], [SupplierId], [Name], " +
                "[Address], [ContactNo], [Email], [Owner], " +
                "[Date] " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId ";
            var supplier = new Supplier();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierId", supplierId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                supplier.Id = Convert.ToInt64(reader["Id"].ToString());
                                supplier.Counter = Convert.ToInt64(reader["Counter"].ToString());
                                supplier.SupplierId = reader["SupplierId"].ToString();
                                supplier.Name = reader["Name"].ToString();
                                supplier.Address = reader["Address"].ToString();
                                supplier.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                supplier.Email = reader["Email"].ToString();
                                supplier.Owner = reader["Owner"].ToString();
                                supplier.Date = Convert.ToDateTime(reader["Date"].ToString());
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
                        "[Counter], [SupplierId], [Name], [Address], [ContactNo], [Email], [Owner], [Date] " +
                    ") " +
                    "VALUES " +
                    "(  " +
                        "@Counter, @SupplierId, @Name, @Address, @ContactNo, @Email, @Owner, @Date " +
                    ")";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Counter", supplier.Counter);
                        command.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@ContactNo", supplier.ContactNo);
                        command.Parameters.AddWithValue("@Email", supplier.Email);
                        command.Parameters.AddWithValue("@Owner", supplier.Owner);
                        command.Parameters.AddWithValue("@Date", supplier.Date);

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

        public Supplier UpdateSupplier(string supplierId, Supplier supplier)
        {
            string query = @"UPDATE " + Constants.TABLE_SUPPLIER + " " +
                "SET " +
                "[SupplierId] = @SupplierId, " +
                "[Name] = @Name, " +
                "[Address] = @Address, " +
                "[ContactNo] = @ContactNo, " +
                "[Email] = @Email, " +
                "[Owner] = @Owner " +
                "WHERE 1 = 1 " +
                "AND [SupplierId] = @SupplierId ";

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
                        command.Parameters.AddWithValue("@ContactNo", supplier.ContactNo);
                        command.Parameters.AddWithValue("@Email", supplier.Email);
                        command.Parameters.AddWithValue("@Owner", supplier.Owner);

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
                "AND [Name] = @Name ";
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

        public int GetLastSupplierId()
        {
            int id = 0;
            string query = @"SELECT " +
                "TOP 1 [Counter] " +
                "FROM " + Constants.TABLE_SUPPLIER + " " +
                "ORDER BY [Counter] DESC ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            id = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }
    }
}
