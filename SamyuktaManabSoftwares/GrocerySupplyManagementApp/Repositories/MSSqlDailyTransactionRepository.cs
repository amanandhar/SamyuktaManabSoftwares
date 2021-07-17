using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
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

        public IEnumerable<TransactionView> GetTransactionViewList(TransactionFilter transactionFilter)
        {
            var transactionViewList = new List<TransactionView>();
            var query = @"SELECT " +
                "ut.[Id], ut.[EndOfDate], " +
                "CASE " +
                "WHEN ut.[MemberId] IS NULL THEN ut.[SupplierId] ELSE ut.[MemberId] END AS [MemberSupplierId], " +
                "[Action], " +
                "CASE " +
                "WHEN ut.[ActionType]='Cheque' THEN (ut.[ActionType] + ' - ' + ut.[Bank]) " +
                "WHEN ut.[Action] in ('Receipt', 'Expense') THEN (ut.[ActionType] + ' - ' + ut.[IncomeExpense]) " +
                "ELSE ut.[ActionType] END AS [ActionType], " +
                "CASE WHEN ut.[MemberId] IS NULL THEN ut.[BillNo] ELSE ut.[InvoiceNo] END AS [InvoiceBillNo], " +
                "i.[Code], i.[Name], si.[Quantity], si.[Price] AS [ItemPrice], " +
                "CASE " +
                "WHEN ut.[Action]='Purchase' AND ut.[ActionType]='Credit' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='Purchase' AND ut.[ActionType]='Cash' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='Sales' AND ut.[ActionType]='Credit' THEN CAST((si.[Quantity] * si.[Price]) AS DECIMAL(18,2)) " +
                "WHEN ut.[Action]='Sales' AND ut.[ActionType]='Cash' THEN CAST((si.[Quantity] * si.[Price]) AS DECIMAL(18,2)) " +
                "WHEN ut.[Action]='Receipt' AND ut.[ActionType]='Credit' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='Receipt' AND ut.[ActionType]='Cash' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='Receipt' AND ut.[ActionType]='Cheque' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='Payment' AND ut.[ActionType]='Credit' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='Payment' AND ut.[ActionType]='Cash' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='Payment' AND ut.[ActionType]='Cheque' THEN ut.[ReceivedAmount] " +
                "WHEN ut.[Action]='Expense' AND ut.[ActionType]='Credit' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='Expense' AND ut.[ActionType]='Cash' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='Transfer' AND ut.[ActionType]='Cash' THEN ut.[DueAmount] " +
                "WHEN ut.[Action]='Transfer' AND ut.[ActionType]='Cheque' THEN ut.[DueAmount] " +
                "ELSE ut.[DueAmount] END  AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON ut.[InvoiceNo] = si.[InvoiceNo] " +
                "LEFT JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "AND NOT " + 
                "( " +
                "ut.[Action] = '" + Constants.RECEIPT + "' " +
                "AND ut.[IncomeExpense] " +
                "IN " +
                "(' " +
                Constants.DELIVERY_CHARGE + "', '" + Constants.MEMBER_FEE + "', '" +
                Constants.OTHER_INCOME + "', '" + Constants.SALES_PROFIT +
                "') " +
                ") ";

            if (transactionFilter.Date != null)
            {
                query += "AND ut.[EndOfDate] = '" + transactionFilter.Date + "' " ;
            }

            if (transactionFilter.Purchase != null)
            {
                query += " AND ut.[Action] = '" + Constants.PURCHASE + "' AND ut.[ActionType] = '" + transactionFilter.Purchase + "' ";
            }
            else if (transactionFilter.Sales != null)
            {
                query += " AND ut.[Action] = '" + Constants.SALES + "' AND ut.[ActionType] = '" + transactionFilter.Sales + "' ";
            }
            else if (transactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + transactionFilter.Receipt + "' ";
            }
            else if (transactionFilter.Payment != null)
            {
                query += " AND ut.[Action] = '" + Constants.PAYMENT + "' AND ut.[ActionType] = '" + transactionFilter.Payment + "' ";
            }
            else if (transactionFilter.Expense != null)
            {
                query += " AND ut.[Action] = '" + Constants.EXPENSE + "' AND ut.[ActionType] = '" + transactionFilter.Expense + "' ";
            }
            else if (transactionFilter.BankTransfer != null)
            {
                query += " AND ut.[Action] = '" + Constants.TRANSFER + "' AND ut.[ActionType] = '" + transactionFilter.BankTransfer + "' ";
            }
            else if (transactionFilter.ItemCode != null)
            {
                query += " AND i.[Code] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND ut.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
            }
            else if (transactionFilter.User != null)
            {
                query += " AND 1 = 2 ";
            }
            else
            {
                query += " ";
            }

            query += "ORDER BY ut.[EndOfDate] ";
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
                                var transactionView = new TransactionView
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    EndOfDate = Convert.ToDateTime(reader["EndOfDate"].ToString()),
                                    MemberSupplierId = reader.IsDBNull(2) ? string.Empty : reader["MemberSupplierId"].ToString(),
                                    Action = reader.IsDBNull(3) ? string.Empty : reader["Action"].ToString(),
                                    ActionType = reader.IsDBNull(4) ? string.Empty : reader["ActionType"].ToString(),
                                    InvoiceBillNo = reader.IsDBNull(5) ? string.Empty : reader["InvoiceBillNo"].ToString(),
                                    ItemCode = reader.IsDBNull(6) ? string.Empty : reader["Code"].ToString(),
                                    ItemName = reader.IsDBNull(7) ? string.Empty : reader["Name"].ToString(),
                                    Quantity = reader.IsDBNull(8) ? 0.0m : Convert.ToDecimal(reader["Quantity"].ToString()),
                                    ItemPrice = reader.IsDBNull(9) ? 0.0m : Convert.ToDecimal(reader["ItemPrice"].ToString()),
                                    Amount = reader.IsDBNull(10) ? 0.0m : Convert.ToDecimal(reader["Amount"].ToString())
                                };

                                transactionViewList.Add(transactionView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return transactionViewList;
        }

        public decimal GetUserTransactionBalance(TransactionFilter transactionFilter)
        {
            decimal total = 0.0m;
            var query = @"SELECT " +
                "SUM(ut.[DueAmount]) - SUM(ut.[ReceivedAmount]) AS [Total] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "LEFT JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON ut.[InvoiceNo] = si.[InvoiceNo] " +
                "INNNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 ";

            if (transactionFilter.Date != null)
            {
                query += " AND ut.[EndOfDate] = '" + transactionFilter.Date + "' ";
            }

            if (transactionFilter.Purchase != null)
            {
                query += " AND ut.[Action] = '" + Constants.PURCHASE + "' AND ut.[ActionType] = '" + transactionFilter.Purchase + "' ";
            }
            else if (transactionFilter.Sales != null)
            {
                query += " AND ut.[Action] = '" + Constants.SALES + "' AND ut.[ActionType] = '" + transactionFilter.Sales + "' ";
            }
            else if (transactionFilter.Payment != null)
            {
                query += " AND ut.[Action] = '" + Constants.PAYMENT + "' AND ut.[ActionType] = '" + transactionFilter.Payment + "' ";
            }
            else if (transactionFilter.Receipt != null)
            {
                query += " AND ut.[Action] = '" + Constants.RECEIPT + "' AND ut.[ActionType] = '" + transactionFilter.Receipt + "' ";
            }
            else if (transactionFilter.Expense != null)
            {
                query += " AND ut.[Action] = '" + Constants.EXPENSE + "' AND ut.[ActionType] = '" + transactionFilter.Expense + "' ";
            }
            else if (transactionFilter.ItemCode != null)
            {
                query += " AND i.[ItemCode] = '" + transactionFilter.ItemCode + "' ";
            }
            else if (transactionFilter.InvoiceNo != null)
            {
                query += " AND ut.[InvoiceNo] = '" + transactionFilter.InvoiceNo + "' ";
            }
            else if (transactionFilter.User != null)
            {
                query += " AND 1 = 2 ";
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
                "DISTINCT [Code] " +
                "FROM " + Constants.TABLE_SOLD_ITEM + " si " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON si.[ItemId] = i.[Id] " +
                "WHERE 1 = 1 " +
                "ORDER BY [Code] ";
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
                                var itemCode = reader["Code"].ToString();

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

        public bool DeleteUserTransaction(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";

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
