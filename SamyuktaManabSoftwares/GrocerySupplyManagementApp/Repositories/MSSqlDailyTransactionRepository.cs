using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlDailyTransactionRepository : IDailyTransactionRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlDailyTransactionRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

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

                        // Delete row from bank transaction table
                        string deleteBankTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [TransactionId] = @TransactionId ";
                        using (SqlCommand command = new SqlCommand(deleteBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@TransactionId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
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
                UtilityService.ShowExceptionMessageBox();
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
                        // Delete row from user transaction table
                        string deleteUserTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [InvoiceNo] = @InvoiceNo ";
                        using (SqlCommand command = new SqlCommand(deleteUserTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@InvoiceNo", ((object)invoiceNo) ?? DBNull.Value);
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

                        sqlTransaction.Commit();
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
                UtilityService.ShowExceptionMessageBox();
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

                        sqlTransaction.Commit();
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
                UtilityService.ShowExceptionMessageBox();
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

                        // Delete row from stock adjustment table
                        string deleteBankTransaction = @"DELETE " +
                            "FROM " + Constants.TABLE_BANK_TRANSACTION + " " +
                            "WHERE 1 = 1 " +
                            "AND [TransactionId] = @TransactionId ";
                        using (SqlCommand command = new SqlCommand(deleteBankTransaction, connection, sqlTransaction))
                        {
                            command.Parameters.AddWithValue("@TransactionId", ((object)id) ?? DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
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
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }
    }
}
