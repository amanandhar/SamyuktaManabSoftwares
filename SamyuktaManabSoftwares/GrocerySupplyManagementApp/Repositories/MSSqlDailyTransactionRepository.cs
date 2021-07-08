﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlDailyTransactionRepository : IDailyTransactionRepository
    {
        private readonly string connectionString;

        public MSSqlDailyTransactionRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<TransactionView> GetTransactionGrids(TransactionFilter transactionFilter)
        {
            var transactionGrids = new List<TransactionView>();
            var query = @"SELECT " +
                "pt.[Id], [InvoiceDate], " +
                "CASE WHEN [MemberId] IS NULL THEN [SupplierId] ELSE [MemberId] END AS [MemberSupplierId], " +
                "[Action], " +
                "CASE WHEN [ActionType]='Cheque' THEN ([ActionType] + ' - ' + [Bank]) ELSE [ActionType] END AS [ActionType], " + 
                "CASE WHEN [MemberId] IS NULL THEN pt.[BillNo] ELSE pt.[InvoiceNo] END AS [InvoiceBillNo], " +
                "[ItemCode], [ItemName], [Quantity], [Price] AS [ItemPrice], " +
                "CASE " +
                "WHEN [Action]='Purchase' AND [ActionType]='Credit' THEN [TotalAmount] " +
                "WHEN [Action]='Purchase' AND [ActionType]='Cash' THEN [ReceivedAmount] " +
                "WHEN [Action]='Sales' AND [ActionType]='Credit' THEN CAST(([Quantity] * [Price]) AS DECIMAL(18,2)) " +
                "WHEN [Action]='Sales' AND [ActionType]='Cash' THEN CAST(([Quantity] * [Price]) AS DECIMAL(18,2)) " +
                "WHEN [Action]='Receipt' AND [ActionType]='Credit' THEN [TotalAmount] " +
                "WHEN [Action]='Receipt' AND [ActionType]='Cash' THEN [ReceivedAmount] " +
                "WHEN [Action]='Receipt' AND [ActionType]='Cheque' THEN [ReceivedAmount] " +
                "WHEN [Action]='Payment' AND [ActionType]='Credit' THEN [TotalAmount] " +
                "WHEN [Action]='Payment' AND [ActionType]='Cash' THEN [ReceivedAmount] " +
                "WHEN [Action]='Payment' AND [ActionType]='Cheque' THEN [ReceivedAmount] " +
                "WHEN [Action]='Expense' AND [ActionType]='Credit' THEN [TotalAmount] " +
                "WHEN [Action]='Expense' AND [ActionType]='Cash' THEN [TotalAmount] " +
                "WHEN [Action]='Transfer' AND [ActionType]='Cash' THEN [TotalAmount] " +
                "WHEN [Action]='Transfer' AND [ActionType]='Cheque' THEN [TotalAmount] " +
                "ELSE pt.[TotalAmount] END  AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " pt LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " psi " +
                "ON pt.InvoiceNo = psi.InvoiceNo " +
                "WHERE 1 = 1 ";

            if (transactionFilter.Date != null)
            {
                query += "AND pt.[InvoiceDate] = '" + transactionFilter.Date + "' " ;
            }

            if (transactionFilter.Purchase != null)
            {
                query += " AND pt.[Action] = '" + Constants.PURCHASE + "' AND pt.[ActionType] = '" + transactionFilter.Purchase + "' ";
            }
            else if (transactionFilter.Sales != null)
            {
                query += " AND pt.[Action] = '" + Constants.SALES + "' AND pt.[ActionType] = '" + transactionFilter.Sales + "' ";
            }
            else if (transactionFilter.Receipt != null)
            {
                query += " AND pt.[Action] = '" + Constants.RECEIPT + "' AND pt.[ActionType] = '" + transactionFilter.Receipt + "' ";
            }
            else if (transactionFilter.Payment != null)
            {
                query += " AND pt.[Action] = '" + Constants.PAYMENT + "' AND pt.[ActionType] = '" + transactionFilter.Payment + "' ";
            }
            else if (transactionFilter.Expense != null)
            {
                query += " AND pt.[Action] = '" + Constants.EXPENSE + "' AND pt.[ActionType] = '" + transactionFilter.Expense + "' ";
            }
            else if (transactionFilter.BankTransfer != null)
            {
                query += " AND pt.[Action] = '" + Constants.TRANSFER + "' AND pt.[ActionType] = '" + transactionFilter.BankTransfer + "' ";
            }
            else if (transactionFilter.ItemCode != null)
            {
                query += " AND [ItemCode] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND pt.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
            }
            else if (transactionFilter.User != null)
            {
                query += " AND 1=2 ";
            }
            else
            {
                query += " ";
            }

            query += "ORDER BY [DATE] ";
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
                                var transactionGrid = new TransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString()),
                                    MemberSupplierId = reader.IsDBNull(2) ? string.Empty : reader["MemberSupplierId"].ToString(),
                                    Action = reader.IsDBNull(3) ? string.Empty : reader["Action"].ToString(),
                                    ActionType = reader.IsDBNull(4) ? string.Empty : reader["ActionType"].ToString(),
                                    InvoiceBillNo = reader.IsDBNull(5) ? string.Empty : reader["InvoiceBillNo"].ToString(),
                                    ItemCode = reader.IsDBNull(6) ? string.Empty : reader["ItemCode"].ToString(),
                                    ItemName = reader.IsDBNull(7) ? string.Empty : reader["ItemName"].ToString(),
                                    Quantity = reader.IsDBNull(8) ? 0.0m : Convert.ToDecimal(reader["Quantity"].ToString()),
                                    ItemPrice = reader.IsDBNull(9) ? 0.0m : Convert.ToDecimal(reader["ItemPrice"].ToString()),
                                    Amount = reader.IsDBNull(10) ? 0.0m : Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                transactionGrids.Add(transactionGrid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return transactionGrids;
        }

        public decimal GetSumTransactionGrids(TransactionFilter transactionFilter)
        {
            decimal total = 0.0m;
            var query = @"SELECT " +
                "SUM(pt.[TotalAmount]) - SUM(pt.[ReceivedAmount]) AS [TOTAL] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " pt " +
                "LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " psi " +
                "ON pt.InvoiceNo = psi.InvoiceNo " +
                "WHERE 1 = 1 ";

            if (transactionFilter.Date != null)
            {
                query += " AND pt.[InvoiceDate] = '" + transactionFilter.Date + "' ";
            }

            if (transactionFilter.Purchase != null)
            {
                query += " AND pt.[Action] = '" + Constants.PURCHASE + "' AND pt.[ActionType] = '" + transactionFilter.Purchase + "' ";
            }
            else if (transactionFilter.Sales != null)
            {
                query += " AND pt.[Action] = '" + Constants.SALES + "' AND pt.[ActionType] = '" + transactionFilter.Sales + "' ";
            }
            else if (transactionFilter.Payment != null)
            {
                query += " AND pt.[Action] = '" + Constants.PAYMENT + "' AND pt.[ActionType] = '" + transactionFilter.Payment + "' ";
            }
            else if (transactionFilter.Receipt != null)
            {
                query += " AND pt.[Action] = '" + Constants.RECEIPT + "' AND pt.[ActionType] = '" + transactionFilter.Receipt + "' ";
            }
            else if (transactionFilter.Expense != null)
            {
                query += " AND pt.[Action] = '" + Constants.EXPENSE + "' AND pt.[ActionType] = '" + transactionFilter.Expense + "' ";
            }
            else if (transactionFilter.ItemCode != null)
            {
                query += " AND [ItemCode] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND pt.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
            }
            else if (transactionFilter.User != null)
            {
                query += " AND 1=2 ";
            }
            else
            {
                query += " ";
            }

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
                            total = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return total;
        }

        public IEnumerable<string> GetMemberIds()
        {
            var memberIds = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [MemberId] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "ORDER BY [MemberId] ";
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
                                var memberId = reader["MemberId"].ToString();

                                memberIds.Add(memberId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return memberIds;
        }

        public IEnumerable<string> GetSalesItems()
        {
            var itemCodes = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [ItemCode] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " " +
                "WHERE 1 = 1 " +
                "ORDER BY [ItemCode] ";
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
                                var itemCode = reader["ItemCode"].ToString();

                                itemCodes.Add(itemCode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return itemCodes;
        }

        public IEnumerable<string> GetInvoices()
        {
            var invoices = new List<string>();
            var query = @"SELECT " +
                "DISTINCT [InvoiceNo] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [InvoiceNo] LIKE 'IN%' " +
                "ORDER BY [InvoiceNo] ";
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
                                var invoice = reader["InvoiceNo"].ToString();

                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoices;
        }

        public bool DeleteTransactionGrids(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND Id = @Id ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
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
