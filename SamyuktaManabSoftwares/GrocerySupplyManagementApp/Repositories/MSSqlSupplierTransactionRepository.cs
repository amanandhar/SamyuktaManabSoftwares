using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlSupplierTransactionRepository : ISupplierTransactionRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        public MSSqlSupplierTransactionRepository()
        {

        }

        /// <summary>
        /// Returns list of SupplierTransactions
        /// </summary>
        /// <returns>List of SupplierTransactions</returns>
        public IEnumerable<DTOs.SupplierTransaction> GetSupplierTransactions(string supplierName)
        {
            var SupplierTransactions = new List<DTOs.SupplierTransaction>();
            string connectionString = GetConnectionString();
            var query = @"SELECT Date, CASE WHEN Status = 'Purchase' THEN BillNo ELSE RepaymentType END AS Particulars, " + 
                "Debit, Credit, " +
                "(SELECT SUM(ISNULL(b.DEBIT,0) - ISNULL(b.Credit,0)) " +
                "FROM [dbo].[SupplierTransaction] b " +
                "WHERE b.Date <= a.Date) as Balance " +
                "FROM [dbo].[SupplierTransaction] a " +
                "WHERE SupplierName = @SupplierName";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var SupplierTransaction = new DTOs.SupplierTransaction
                                {
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
                                    Particulars = reader["Particulars"].ToString(),
                                    Debit = Convert.ToDecimal(reader.IsDBNull(2) ? "0" : reader["Debit"].ToString()),
                                    Credit = Convert.ToDecimal(reader.IsDBNull(3) ? "0" : reader["Credit"].ToString()),
                                    Balance = Convert.ToDecimal(reader.IsDBNull(4) ? "0" : reader["Balance"].ToString()),
                                };

                                SupplierTransactions.Add(SupplierTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SupplierTransactions;
        }

        /// <summary>
        /// Returns balance
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns>balance</returns>
        public decimal GetBalance(string supplierName)
        {
            var balance = 0.0m;
            string connectionString = GetConnectionString();
            var query = @"SELECT ISNUll(SUM(ISNULL(DEBIT,0) - ISNULL(Credit,0)),0) FROM [dbo].[SupplierTransaction] WHERE SupplierName = @SupplierName";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
                        balance = Convert.ToDecimal(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return balance;
        }

        /// <summary>
        /// Returns a SupplierTransaction with matching supplier name
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns>SupplierTransaction</returns>
        public SupplierTransaction GetSupplierTransaction(string supplierName)
        {
            string connectionString = GetConnectionString();
            var query = @"SELECT SupplierName, Status, BillNo, RepaymentType, Bank, Debit, Credit, Date FROM SupplierTransaction WHERE SupplierName = @SupplierName";
            var SupplierTransaction = new SupplierTransaction();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SupplierTransaction.SupplierName = reader["SupplierName"].ToString();
                                SupplierTransaction.Status = reader["Status"].ToString();
                                SupplierTransaction.BillNo = reader["BillNo"].ToString();
                                SupplierTransaction.RepaymentType = reader["RepaymentType"].ToString();
                                SupplierTransaction.Bank = reader["Bank"].ToString();
                                SupplierTransaction.Debit = Convert.ToDecimal(reader["Debit"].ToString());
                                SupplierTransaction.Credit = Convert.ToDecimal(reader["Credit"].ToString());
                                SupplierTransaction.Date = Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SupplierTransaction;
        }

        /// <summary>
        /// Add a new SupplierTransaction
        /// </summary>
        /// <param name="SupplierTransaction"></param>
        /// <returns>SupplierTransaction</returns>
        public SupplierTransaction AddSupplierTransaction(SupplierTransaction SupplierTransaction)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO SupplierTransaction " +
                            "(" +
                                "SupplierName, Status, BillNo, RepaymentType, Bank, Debit, Credit, Date " +
                            ") " +
                            "VALUES " +
                            "(" +
                                "@SupplierName, @Status, @BillNo, @RepaymentType, @Bank, @Debit, @Credit, @Date " +
                            ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", SupplierTransaction.SupplierName);
                        command.Parameters.AddWithValue("@Status", SupplierTransaction.Status);
                        command.Parameters.AddWithValue("@BillNo", ((object)SupplierTransaction.BillNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RepaymentType", ((object)SupplierTransaction.RepaymentType) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Bank", ((object)SupplierTransaction.Bank) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Debit", ((object)SupplierTransaction.Debit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Credit", ((object)SupplierTransaction.Credit) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Date", SupplierTransaction.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SupplierTransaction;
        }

        /// <summary>
        /// Update SupplierTransaction with SupplierTransaction name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="SupplierTransaction"></param>
        /// <returns>SupplierTransaction</returns>
        public SupplierTransaction UpdateSupplierTransaction(string supplierName, SupplierTransaction SupplierTransaction)
        {
            string connectionString = GetConnectionString();
            string query = "UPDATE SupplierTransaction SET " +
                    "SupplierName = @SupplierName, " +
                    "Status = @Status, " +
                    "BillNo = @BillNo, " +
                    "RepaymentType = @RepaymentType, " +
                    "Bank = @Bank, " +
                    "Debit = @Debit, " +
                    "Credit = @Credit, " +
                    "Date = @Date " +
                    "WHERE " +
                    "SupplierName = @SupplierName";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
                        command.Parameters.AddWithValue("@Status", SupplierTransaction.Status);
                        command.Parameters.AddWithValue("@BillNo", SupplierTransaction.BillNo);
                        command.Parameters.AddWithValue("@RepaymentType", SupplierTransaction.RepaymentType);
                        command.Parameters.AddWithValue("@Bank", SupplierTransaction.Bank);
                        command.Parameters.AddWithValue("@Debit", SupplierTransaction.Debit);
                        command.Parameters.AddWithValue("@Credit", SupplierTransaction.Credit);
                        command.Parameters.AddWithValue("@Date", SupplierTransaction.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SupplierTransaction;
        }

        /// <summary>
        /// Delete SupplierTransaction with supplier name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        public bool DeleteSupplierTransaction(string supplierName)
        {
            string connectionString = GetConnectionString();
            string query = "DELETE FROM SupplierTransaction " +
                    "WHERE " +
                    "SupplierName = @SupplierName";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
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
