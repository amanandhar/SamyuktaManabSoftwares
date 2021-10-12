using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlReportRepository : IReportRepository
    {
        private readonly string connectionString;

        public MSSqlReportRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<InvoiceReportView> GetInvoiceReport(string invoiceNo)
        {
            var invoiceReportViews = new List<InvoiceReportView>();
            var query = @"SELECT " +
                "m.[MemberId], m.[Name], m.[Address], m.[ContactNo], m.[AccountNo], " +
                "ut.[InvoiceNo], ut.[ActionType], ut.[EndOfDay], " +
                "pd.[SubTotal], pd.[Discount], pd.[DeliveryCharge], ut.[DueReceivedAmount], ut.[ReceivedAmount], " +
                "i.[Name] AS [ItemName], i.[Brand], si.[Volume], si.[Unit], " +
                "si.[Quantity], si.[Price], CAST((si.[Quantity] * si.[Price]) AS DECIMAL(18, 2)) AS [Amount] " +
                "FROM " + Constants.TABLE_MEMBER + " m " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON m.[MemberId] = ut.[MemberId] " +
                "AND ISNULL(ut.[Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL(ut.[Expense], '') !=  '" + Constants.SALES_DISCOUNT + "' " +
                "INNER JOIN " + Constants.TABLE_POS_DETAIL + " pd " +
                "ON pd.[InvoiceNo] = ut.[InvoiceNo] " +
                "INNER JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON si.[InvoiceNo] = ut.[InvoiceNo] " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON i.[Id] = si.[ItemId] " +
                "WHERE 1 = 1 " +
                "AND ISNULL(ut.[InvoiceNo], '') = @InvoiceNo";

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
                                int i = 1;
                                while (reader.Read())
                                {
                                    var invoiceReportView = new InvoiceReportView
                                    {
                                        MemberId = reader["MemberId"].ToString(),
                                        Name = reader["Name"].ToString(),
                                        Address = reader["Address"].ToString(),
                                        ContactNo = Convert.ToInt64(reader["ContactNo"].ToString()),
                                        AccountNo = reader["AccountNo"].ToString(),
                                        InvoiceNo = reader["InvoiceNo"].ToString(),
                                        ActionType = reader["ActionType"].ToString(),
                                        EndOfDay = reader["EndOfDay"].ToString(),
                                        SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                                        Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                                        DeliveryCharge = Convert.ToDecimal(reader["DeliveryCharge"].ToString()),
                                        DueReceivedAmount = Convert.ToDecimal(reader["DueReceivedAmount"].ToString()),
                                        ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString()),
                                        ItemName = reader["ItemName"].ToString(),
                                        Brand = reader["Brand"].ToString(),
                                        Volume = Convert.ToInt64(reader["Volume"].ToString()),
                                        Unit = reader["Unit"].ToString(),
                                        Quantity = Convert.ToDecimal(reader["Quantity"].ToString()),
                                        Price = Convert.ToDecimal(reader["Price"].ToString()),
                                        Amount = Convert.ToDecimal(reader["Amount"].ToString()),
                                        ItemNo = i
                                    };

                                    invoiceReportViews.Add(invoiceReportView);
                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceReportViews;
        }
    }
}
