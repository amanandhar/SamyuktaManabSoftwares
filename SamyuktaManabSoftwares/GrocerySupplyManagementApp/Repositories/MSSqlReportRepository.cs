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
                "m.[MemberId], m.[Name], m.[Address], m.[ContactNo], " +
                "ut.[InvoiceNo], ut.[ActionType], ut.[EndOfDay], " +
                "ut.[SubTotal], ut.[Discount], ut.[Vat], ut.[DueAmount], ut.[ReceivedAmount], " +
                "(ut.[DueAmount] - ut.[ReceivedAmount]) AS [Balance], " +
                "i.[Name] AS [ItemName], i.[Brand], i.[Unit], " +
                "si.[Quantity], si.[Price] " +
                "FROM " + Constants.TABLE_MEMBER + " m " +
                "INNER JOIN " + Constants.TABLE_USER_TRANSACTION + " ut " +
                "ON m.[MemberId] = ut.[MemberId] " +
                "INNER JOIN " + Constants.TABLE_SOLD_ITEM + " si " +
                "ON si.[InvoiceNo] = ut.[InvoiceNo] " +
                "INNER JOIN " + Constants.TABLE_ITEM + " i " +
                "ON i.[Id] = si.[ItemId] " +
                "WHERE 1 = 1 " +
                "AND ut.[InvoiceNo] = @InvoiceNo";

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
                                    var invoiceReportView = new InvoiceReportView();

                                    invoiceReportView.MemberId = reader["MemberId"].ToString();
                                    invoiceReportView.Name = reader["Name"].ToString();
                                    invoiceReportView.Address = reader["Address"].ToString();
                                    invoiceReportView.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                    invoiceReportView.InvoiceNo = reader["InvoiceNo"].ToString();
                                    invoiceReportView.ActionType = reader["ActionType"].ToString();
                                    invoiceReportView.EndOfDay = reader["EndOfDay"].ToString();
                                    invoiceReportView.SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString());
                                    invoiceReportView.Discount = Convert.ToDecimal(reader["Discount"].ToString());
                                    invoiceReportView.Vat = Convert.ToDecimal(reader["Vat"].ToString());
                                    invoiceReportView.DueAmount = Convert.ToDecimal(reader["DueAmount"].ToString());
                                    invoiceReportView.ReceivedAmount = Convert.ToDecimal(reader["ReceivedAmount"].ToString());
                                    invoiceReportView.Balance = Convert.ToDecimal(reader["Balance"].ToString());
                                    invoiceReportView.ItemName = reader["ItemName"].ToString();
                                    invoiceReportView.Brand = reader["Brand"].ToString();
                                    invoiceReportView.Unit = reader["Unit"].ToString();
                                    invoiceReportView.Quantity = Convert.ToInt64(reader["Quantity"].ToString());
                                    invoiceReportView.Price = Convert.ToDecimal(reader["Price"].ToString());

                                    invoiceReportViews.Add(invoiceReportView);
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
