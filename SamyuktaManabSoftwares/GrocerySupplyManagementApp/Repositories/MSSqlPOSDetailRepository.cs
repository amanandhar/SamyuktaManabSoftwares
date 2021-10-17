﻿using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlPOSDetailRepository : IPOSDetailRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlPOSDetailRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<POSDetail> GetPOSDetails()
        {
            var posDetails = new List<POSDetail>();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge] " +
                "FROM " + Constants.TABLE_POS_DETAIL;

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
                                var posDetail = new POSDetail
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    InvoiceNo = reader["InvoiceNo"].ToString(),
                                    SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                                    DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString()),
                                    Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                                    VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString()),
                                    Vat = Convert.ToDecimal(reader["Vat"].ToString()),
                                    DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString()),
                                    DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString())
                                };

                                posDetails.Add(posDetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return posDetails;
        }

        public POSDetail GetPOSDetail(long id)
        {
            var posDetail = new POSDetail();
            var query = @"SELECT " +
                "[Id], [InvoiceNo], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge] " +
                "FROM " + Constants.TABLE_POS_DETAIL + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id";

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
                                    posDetail.Id = Convert.ToInt64(reader["Id"].ToString());
                                    posDetail.InvoiceNo = reader["InvoiceNo"].ToString();
                                    posDetail.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                    posDetail.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                    posDetail.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                    posDetail.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                    posDetail.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                    posDetail.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                    posDetail.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                }        
                            }            
                        }                
                    }                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return posDetail;
        }

        public POSDetailView GetPOSDetailView(string invoiceNo)
        {
            var posDetailView = new POSDetailView();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDay], ut.[InvoiceNo], ut.[BillNo], ut.[MemberId], " +
                "ut.[SupplierId], ut.[DeliveryPersonId], ut.[Action], ut.[ActionType], ut.[Bank], ut.[Income], ut.[Expense], " +
                "ut.[DueReceivedAmount], ut.[ReceivedAmount], ut.[AddedBy], ut.[AddedDate], ut.[UpdatedBy], ut.[UpdatedDate], " +
                "pd.[SubTotal], pd.[DiscountPercent], pd.[Discount], pd.[VatPercent], pd.[Vat], pd.[DeliveryChargePercent], pd.[DeliveryCharge] " +
                "FROM " + Constants.TABLE_POS_DETAIL + " pd " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON ISNULL(pd.[InvoiceNo], '') = ut.[InvoiceNo] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(pd.[InvoiceNo], '') = @InvoiceNo";

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
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    posDetailView.Id = Convert.ToInt64(reader["Id"].ToString());
                                    posDetailView.EndOfDay = reader["EndOfDay"].ToString();
                                    posDetailView.InvoiceNo = reader["InvoiceNo"].ToString();
                                    posDetailView.BillNo = reader["BillNo"].ToString();
                                    posDetailView.MemberId = reader["MemberId"].ToString();
                                    posDetailView.SupplierId = reader["SupplierId"].ToString();
                                    posDetailView.DeliveryPersonId = reader["DeliveryPersonId"].ToString();
                                    posDetailView.Action = reader["Action"].ToString();
                                    posDetailView.ActionType = reader["ActionType"].ToString();
                                    posDetailView.Bank = reader["Bank"].ToString();
                                    posDetailView.Income = reader["Income"].ToString();
                                    posDetailView.Expense = reader["Expense"].ToString();
                                    posDetailView.DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString());
                                    posDetailView.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                    posDetailView.AddedBy = reader["AddedBy"].ToString();
                                    posDetailView.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    posDetailView.UpdatedBy = reader["UpdatedBy"].ToString();
                                    posDetailView.UpdatedDate = reader.IsDBNull(17) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                    posDetailView.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                    posDetailView.DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"].ToString());
                                    posDetailView.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                    posDetailView.VatPercent = Convert.ToDecimal(reader["VatPercent"].ToString());
                                    posDetailView.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                    posDetailView.DeliveryChargePercent = Convert.ToDecimal(reader["DeliveryChargePercent"].ToString());
                                    posDetailView.DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return posDetailView;
        }

        public POSDetail AddPOSDetail(POSDetail posDetail)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_POS_DETAIL + " " +
                    "( " +
                        "[EndOfDay], [InvoiceNo], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @InvoiceNo, @SubTotal, @DiscountPercent, @Discount, @VatPercent, @Vat, @DeliveryChargePercent, @DeliveryCharge " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)posDetail.EndOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)posDetail.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SubTotal", ((object)posDetail.SubTotal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiscountPercent", ((object)posDetail.DiscountPercent) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Discount", ((object)posDetail.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VatPercent", ((object)posDetail.VatPercent) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)posDetail.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryChargePercent", ((object)posDetail.DeliveryChargePercent) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)posDetail.DeliveryCharge) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return posDetail;
        }

        public POSDetail UpdatePOSDetail(long id, POSDetail posDetail)
        {
            string query = @"UPDATE " + Constants.TABLE_BANK + " " +
                    "SET " +
                    "[InvoiceNo] = @InvoiceNo, " +
                    "[SubTotal] = @SubTotal, " +
                    "[DiscountPercent] = @DiscountPercent, " +
                    "[Discount] = @Discount, " +
                    "[VatPercent] = @VatPercent, " +
                    "[Vat] = @Vat, " +
                    "[DeliveryChargePercent] = @DeliveryChargePercent, " +
                    "[DeliveryCharge] = @DeliveryCharge " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)posDetail.InvoiceNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SubTotal", ((object)posDetail.SubTotal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DiscountPercent", ((object)posDetail.DiscountPercent) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Discount", ((object)posDetail.Discount) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VatPercent", ((object)posDetail.VatPercent) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Vat", ((object)posDetail.Vat) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryChargePercent", ((object)posDetail.DeliveryChargePercent) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryCharge", ((object)posDetail.DeliveryCharge) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return posDetail;
        }

        public bool DeletePOSDetail(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_POS_DETAIL + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return result;
        }

        public bool DeletePOSDetail(string invoiceNo)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_POS_DETAIL + " " +
                    "WHERE 1 = 1 " +
                    "AND ISNULL([InvoiceNo], '') = @InvoiceNo";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return result;
        }
    }
}
