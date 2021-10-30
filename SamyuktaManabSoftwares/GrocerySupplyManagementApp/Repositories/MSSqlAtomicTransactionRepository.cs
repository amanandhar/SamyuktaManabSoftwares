using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlAtomicTransactionRepository : IAtomicTransactionRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlAtomicTransactionRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        #region Daily Transaction Methods
        public bool DeleteBill(long id, string billNo)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from bank transaction table
                        string deleteBankTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [UserTransactionId] = @UserTransactionId ";
                        using (SqlCommand command = new SqlCommand(deleteBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@UserTransactionId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from user transaction table
                        var deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [Id] = @Id ";
                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from purchased item table
                        string deletePurchasedItem = @"DELETE " +
                            "FROM " + Constants.TABLE_PURCHASED_ITEM + " " +
                            "WHERE 1 = 1 " +
                            "AND [BillNo] = @BillNo ";
                        using (SqlCommand command = new SqlCommand(deletePurchasedItem, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@BillNo", ((object)billNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        public bool DeleteInvoice(string invoiceNo)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from pos detail table
                        string deletePosDetail = @"DELETE " +
                            "FROM " + Constants.TABLE_POS_DETAIL + " " +
                            "WHERE 1 = 1 " +
                            "AND ISNULL([InvoiceNo], '') = @InvoiceNo";
                        using (SqlCommand command = new SqlCommand(deletePosDetail, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from user transaction table
                        string deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [PartyNumber] = @PartyNumber ";
                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@PartyNumber", ((object)invoiceNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from sold item table
                        string deleteSoldItem = @"DELETE " +
                            "FROM " + Constants.TABLE_SOLD_ITEM + " " +
                            "WHERE 1 = 1 " +
                            "AND InvoiceNo = @InvoiceNo ";
                        using (SqlCommand command = new SqlCommand(deleteSoldItem, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        public bool DeleteStockAdjustment(long id)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from stock adjustment table
                        string deleteStockAdjustment = @"DELETE " +
                            "FROM " + Constants.TABLE_STOCK_ADJUSTMENT + " " +
                            "WHERE 1 = 1 " +
                            "AND [UserTransactionId] = @UserTransactionId";
                        using (SqlCommand command = new SqlCommand(deleteStockAdjustment, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@UserTransactionId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from user transaction table
                        string deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [Id] = @Id ";
                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        public bool DeleteBankTransaction(long id)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Delete row from stock adjustment table
                        string deleteBankTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [UserTransactionId] = @UserTransactionId ";
                        using (SqlCommand command = new SqlCommand(deleteBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@UserTransactionId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        // Delete row from user transaction table
                        string deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [Id] = @Id ";
                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        public bool SaveSalesDetail(List<SoldItem> soldItems, UserTransaction userTransaction, POSDetail posDetail, string username)
        {
            var result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a local transaction
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        // Add rows into the sold item table
                        string insertSoldItem = @"INSERT INTO " + Constants.TABLE_SOLD_ITEM + " " +
                            "( " +
                                "[EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Profit], [Unit], [Volume], [Quantity], [Price], [AddedBy], [AddedDate]  " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @MemberId, @InvoiceNo, @ItemId, @Profit, @Unit, @Volume, @Quantity, @Price, @AddedBy, @AddedDate " +
                            ") ";

                        foreach(var soldItem in soldItems)
                        {
                            using (SqlCommand command = new SqlCommand(insertSoldItem, connection, sqlTransaction))
                            {
                                command.Parameters.AddWithValue("@EndOfDay", soldItem.EndOfDay);
                                command.Parameters.AddWithValue("@MemberId", soldItem.MemberId);
                                command.Parameters.AddWithValue("@InvoiceNo", soldItem.InvoiceNo);
                                command.Parameters.AddWithValue("@ItemId", soldItem.ItemId);
                                command.Parameters.AddWithValue("@Profit", soldItem.Profit);
                                command.Parameters.AddWithValue("@Unit", soldItem.Unit);
                                command.Parameters.AddWithValue("@Volume", soldItem.Volume);
                                command.Parameters.AddWithValue("@Quantity", soldItem.Quantity);
                                command.Parameters.AddWithValue("@Price", soldItem.Price);
                                command.Parameters.AddWithValue("@AddedBy", soldItem.AddedBy);
                                command.Parameters.AddWithValue("@AddedDate", soldItem.AddedDate);

                                command.ExecuteNonQuery();
                            }
                        }

                        // Add row into the user transaction table
                        string insertUserTransaction = "INSERT INTO " + Constants.TABLE_USER_TRANSACTION + " " +
                            "(" +
                                "[EndOfDay], [Action], [ActionType], " +
                                "[PartyId], [PartyNumber], [BankName], [Narration], " +
                                "[DueReceivedAmount], [DuePaymentAmount], [ReceivedAmount], [PaymentAmount], " +
                                "[AddedBy], [AddedDate] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @Action, @ActionType, " +
                                "@PartyId, @PartyNumber, @BankName, @Narration, " +
                                "@DueReceivedAmount, @DuePaymentAmount, @ReceivedAmount, @PaymentAmount, " +
                                "@AddedBy, @AddedDate " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", userTransaction.EndOfDay);
                            command.Parameters.AddWithValue("@Action", userTransaction.Action);
                            command.Parameters.AddWithValue("@ActionType", userTransaction.ActionType);
                            command.Parameters.AddWithValue("@PartyId", ((object)userTransaction.PartyId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@PartyNumber", ((object)userTransaction.PartyNumber) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@BankName", ((object)userTransaction.BankName) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Narration", ((object)userTransaction.Narration) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DueReceivedAmount", ((object)userTransaction.DueReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@DuePaymentAmount", ((object)userTransaction.DuePaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@ReceivedAmount", ((object)userTransaction.ReceivedAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@PaymentAmount", ((object)userTransaction.PaymentAmount) ?? Constants.DEFAULT_DECIMAL_VALUE);
                            command.Parameters.AddWithValue("@AddedBy", userTransaction.AddedBy);
                            command.Parameters.AddWithValue("@AddedDate", userTransaction.AddedDate);

                            command.ExecuteNonQuery();
                        }

                        // Get the last id from the user transaction table
                        long lastUserTransactionId = 0;
                        string selectLastTransaction = @"SELECT " +
                            "TOP 1 " +
                            "[Id] " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND ([PartyNumber] IS NOT NULL " +
                            "AND DATALENGTH([PartyNumber]) > 0) " +
                            "AND [Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') " +
                            "ORDER BY[Id] DESC ";

                        using (SqlCommand command = new SqlCommand(selectLastTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@AddedBy", ((object)username) ?? DBNull.Value);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lastUserTransactionId = Convert.ToInt64(reader["Id"].ToString());
                                }
                            }
                        }

                        // Add row into the pos detail table
                        posDetail.UserTransactionId = lastUserTransactionId;
                        string insertPOSDetail = @"INSERT INTO " +
                            " " + Constants.TABLE_POS_DETAIL + " " +
                            "( " +
                                "[EndOfDay], [UserTransactionId], [InvoiceNo], [SubTotal], " +
                                "[DiscountPercent], [Discount], [VatPercent], [Vat], " +
                                "[DeliveryChargePercent], [DeliveryCharge], [DeliveryPersonId] " +
                            ") " +
                            "VALUES " +
                            "( " +
                                "@EndOfDay, @UserTransactionId, @InvoiceNo, @SubTotal, " +
                                "@DiscountPercent, @Discount, @VatPercent, @Vat, " +
                                "@DeliveryChargePercent, @DeliveryCharge, @DeliveryPersonId " +
                            ") ";

                        using (SqlCommand command = new SqlCommand(insertPOSDetail, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@EndOfDay", ((object)posDetail.EndOfDay) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@UserTransactionId", ((object)posDetail.UserTransactionId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@InvoiceNo", ((object)posDetail.InvoiceNo) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@SubTotal", ((object)posDetail.SubTotal) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DiscountPercent", ((object)posDetail.DiscountPercent) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Discount", ((object)posDetail.Discount) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@VatPercent", ((object)posDetail.VatPercent) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Vat", ((object)posDetail.Vat) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DeliveryChargePercent", ((object)posDetail.DeliveryChargePercent) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DeliveryCharge", ((object)posDetail.DeliveryCharge) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DeliveryPersonId", ((object)posDetail.DeliveryPersonId) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
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

        #endregion
    }
}
