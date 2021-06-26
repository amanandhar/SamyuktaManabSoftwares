using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPosInvoiceRepository : IPosInvoiceRepository
    {
        private const string DB_CONNECTION_STRING = "DBConnectionString";
        private const string TABLE_NAME = "PosInvoice";
        
        public MSSqlPosInvoiceRepository()
        {

        }

        public IEnumerable<PosInvoice> GetPosInvoices()
        {
            var posInvoices = new List<PosInvoice>();
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM " + TABLE_NAME + " ORDER BY Id";
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
                                var posInvoice = new PosInvoice
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                                    MemberId = reader["MemberId"].ToString(),
                                    PaymentType = reader["PaymentType"].ToString(),
                                    SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                                    DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString()),
                                    Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                                    VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString()),
                                    Vat = Convert.ToDecimal(reader["Vat"].ToString()),
                                    DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString()),
                                    DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Balance = Convert.ToDecimal(reader["Balance"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };


                                posInvoices.Add(posInvoice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posInvoices;
        }

        public IEnumerable<PosInvoice> GetPosInvoicesByMemberId(string memberId)
        {
            var posInvoices = new List<PosInvoice>();
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM " + TABLE_NAME + " WHERE MemberId = @MemberId ORDER BY Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", ((object)memberId) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var posInvoice = new PosInvoice
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                                    MemberId = reader["MemberId"].ToString(),
                                    PaymentType = reader["PaymentType"].ToString(),
                                    SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                                    DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString()),
                                    Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                                    VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString()),
                                    Vat = Convert.ToDecimal(reader["Vat"].ToString()),
                                    DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString()),
                                    DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                    ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                    Balance = Convert.ToDecimal(reader["Balance"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString())
                                };
                                    
                                posInvoices.Add(posInvoice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posInvoices;
        }

        public PosInvoice GetPosInvoice(long posInvoiceId)
        {
            throw new NotImplementedException();
        }

        public PosInvoice GetPosInvoice(string invoiceNo)
        {
            var posInvoice = new PosInvoice();
            string connectionString = GetConnectionString();
            var query = @"SELECT * FROM " + TABLE_NAME + " WHERE InvoiceNo = @InvoiceNo";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                posInvoice.Id = Convert.ToInt64(reader["Id"].ToString());
                                posInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                                posInvoice.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                                posInvoice.MemberId = reader["MemberId"].ToString();
                                posInvoice.PaymentType = reader["PaymentType"].ToString();
                                posInvoice.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                posInvoice.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                posInvoice.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                posInvoice.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                posInvoice.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                posInvoice.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                posInvoice.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                posInvoice.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                                posInvoice.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                posInvoice.Balance = Convert.ToDecimal(reader["Balance"].ToString());
                                posInvoice.Date = Convert.ToDateTime(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posInvoice;
        }

        public PosInvoice AddPosInvoice(PosInvoice posInvoice)
        {
            string connectionString = GetConnectionString();
            string query = "INSERT INTO " + TABLE_NAME +
                            " (" +
                                " [InvoiceNo], [InvoiceDate], [MemberId], [PaymentType], [SubTotal], " + 
                                " [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], " +
                                " [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Balance], [Date] " +
                            " ) " +
                            " VALUES" +
                            " (" +
                                " @InvoiceNo, @InvoiceDate, @MemberId, @PaymentType, @SubTotal, " +
                                " @DiscountPercent, @Discount, @VatPercent, @Vat, @DeliveryChargePercent, " +
                                " @DeliveryCharge, @TotalAmount, @ReceivedAmount, @Balance, @Date " +
                            " )";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", posInvoice.InvoiceNo);
                        command.Parameters.AddWithValue("@InvoiceDate", posInvoice.InvoiceDate);
                        command.Parameters.AddWithValue("@MemberId", posInvoice.MemberId);
                        command.Parameters.AddWithValue("@PaymentType", posInvoice.PaymentType);
                        command.Parameters.AddWithValue("@SubTotal", posInvoice.SubTotal);
                        command.Parameters.AddWithValue("@DiscountPercent", posInvoice.DiscountPercent);
                        command.Parameters.AddWithValue("@Discount", posInvoice.Discount);
                        command.Parameters.AddWithValue("@VatPercent", posInvoice.VatPercent);
                        command.Parameters.AddWithValue("@Vat", posInvoice.Vat);
                        command.Parameters.AddWithValue("@DeliveryChargePercent", posInvoice.DeliveryChargePercent);
                        command.Parameters.AddWithValue("@DeliveryCharge", posInvoice.DeliveryCharge);
                        command.Parameters.AddWithValue("@TotalAmount", posInvoice.TotalAmount);
                        command.Parameters.AddWithValue("@ReceivedAmount", ((object)posInvoice.ReceivedAmount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Balance", posInvoice.Balance);
                        command.Parameters.AddWithValue("@Date", posInvoice.Date);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return posInvoice;
        }

        public PosInvoice UpdatePosInvoice(long posInvoiceId, PosInvoice posInvoice)
        {
            throw new NotImplementedException();
        }

        public bool DeletePosInvoice(long posInvoiceId, PosInvoice posInvoice)
        {
            throw new NotImplementedException();
        }

        public string GetLastInvoiceNo()
        {
            string connectionString = GetConnectionString();
            string query = "SELECT TOP 1 [InvoiceNo] FROM " + TABLE_NAME + " ORDER BY Id DESC";
            string invoiceNo = string.Empty;
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
                            invoiceNo = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceNo;
        }

        public decimal GetTotalBalance(string memberId)
        {
            string connectionString = GetConnectionString();
            string query = "SELECT SUM([Balance]) FROM " + TABLE_NAME + " WHERE MemberId = @MemberId ";
            decimal balance = 0.0m;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberId", ((object)memberId) ?? DBNull.Value);
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            balance = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return balance;
        }

        private string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
