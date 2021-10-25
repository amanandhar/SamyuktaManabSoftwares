using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    class MSSqlCapitalRepository : ICapitalRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlCapitalRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public decimal GetMemberTotalBalance(UserTransactionFilter userTransactionFilter)
        {
            decimal balance = Constants.DEFAULT_DECIMAL_VALUE;
            string query = @"SELECT " +
                "SUM(Temp.[Amount]) " +
                "FROM " +
                "( " +
                "SELECT " +
                "CASE " +
                "WHEN [Action] = '" + Constants.SALES + "' AND [ActionType] = '" + Constants.CASH + "' THEN 0.00 " +
                "ELSE ([DueReceivedAmount] - [ReceivedAmount]) " +
                "END AS [Amount] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Income], '') != '" + Constants.DELIVERY_CHARGE + "' " +
                "AND ISNULL([Expense], '') != '" + Constants.SALES_DISCOUNT + "' ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.MemberId))
            {
                query += "AND [MemberId] = @MemberId ";
            }
            else
            {
                query += "AND [MemberId] IS NOT NULL ";
            }

            query += ") Temp";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)userTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)userTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberId", ((object)userTransactionFilter?.MemberId) ?? DBNull.Value);

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
                logger.Error(ex);
                throw ex;
            }

            return balance;
        }

        public decimal GetSupplierTotalBalance(SupplierTransactionFilter supplierTransactionFilter)
        {
            decimal balance = Constants.DEFAULT_DECIMAL_VALUE;
            string query = @"SELECT " +
                "SUM([DuePaymentAmount]) - SUM([PaymentAmount]) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.SupplierId))
            {
                query += "AND [SupplierId] = @SupplierId ";
            }
            else
            {
                query += "AND [SupplierId] IS NOT NULL ";
            }

            if (!string.IsNullOrWhiteSpace(supplierTransactionFilter?.Action))
            {
                query += "AND [Action] = @Action ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)supplierTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)supplierTransactionFilter?.DateTo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierId", ((object)supplierTransactionFilter?.SupplierId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)supplierTransactionFilter?.Action) ?? DBNull.Value);

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
                logger.Error(ex);
                throw ex;
            }

            return balance;
        }

        public decimal GetCashInHand(UserTransactionFilter userTransactionFilter)
        {
            decimal cashInHand = Constants.DEFAULT_DECIMAL_VALUE;
            string query = @"SELECT " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([ReceivedAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.SALES + "', '" + Constants.RECEIPT + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                "AND [Id] NOT IN " +
                "( " +
                "SELECT [Id] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Income], '') = '" + Constants.DELIVERY_CHARGE + "' ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") " +
                "- " +
                "( " +
                "SELECT " +
                "ISNULL(SUM([PaymentAmount]), 0) " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND [Action] IN ('" + Constants.BANK_TRANSFER + "', '" + Constants.EXPENSE + "', '" + Constants.PAYMENT + "') " +
                "AND [ActionType] = '" + Constants.CASH + "' " +
                "AND [Id] NOT IN " +
                "( " +
                "SELECT [Id] " +
                "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                "WHERE 1 = 1 " +
                "AND ISNULL([Expense], '') = '" + Constants.SALES_DISCOUNT + "' ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") ";

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateFrom))
            {
                query += "AND [EndOfDay] >= @DateFrom ";
            }

            if (!string.IsNullOrWhiteSpace(userTransactionFilter?.DateTo))
            {
                query += "AND [EndOfDay] <= @DateTo ";
            }

            query += ") ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateFrom", ((object)userTransactionFilter?.DateFrom) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateTo", ((object)userTransactionFilter?.DateTo) ?? DBNull.Value);

                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            cashInHand = Convert.ToDecimal(result.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return cashInHand;
        }

        public decimal GetOpeningCashBalance(string endOfDay)
        {
            var previousCashSales = GetPreviousTotalBalance(endOfDay, Constants.SALES, Constants.CASH);
            var previousCashReceipt = GetPreviousTotalBalance(endOfDay, Constants.RECEIPT, Constants.CASH);
            var previousCashPayment = GetPreviousTotalBalance(endOfDay, Constants.PAYMENT, Constants.CASH);
            var previousCashExpense = GetPreviousTotalBalance(endOfDay, Constants.EXPENSE, Constants.CASH);
            var previousCashTransfer = GetPreviousTotalBalance(endOfDay, Constants.BANK_TRANSFER, Constants.CASH);

            var openingCashBalance = previousCashSales + previousCashReceipt - (previousCashPayment + previousCashExpense + previousCashTransfer);

            return openingCashBalance;
        }

        public decimal GetOpeningCreditBalance(string endOfDay)
        {
            var previousCreditSales = GetPreviousTotalBalance(endOfDay, Constants.SALES, Constants.CREDIT);
            var previousCashReceipt = GetPreviousTotalBalance(endOfDay, Constants.RECEIPT, Constants.CASH);
            var previousChequeReceipt = GetPreviousTotalBalance(endOfDay, Constants.RECEIPT, Constants.CHEQUE);

            var openingCreditBalance = previousCreditSales - (previousCashReceipt + previousChequeReceipt);

            return openingCreditBalance;
        }

        public decimal GetCashBalance(string endOfDay)
        {
            var cashSales = GetTotalBalance(endOfDay, Constants.SALES, Constants.CASH);
            var cashReceipt = GetTotalBalance(endOfDay, Constants.RECEIPT, Constants.CASH);
            var cashPayment = GetTotalBalance(endOfDay, Constants.PAYMENT, Constants.CASH);
            var cashExpense = GetTotalBalance(endOfDay, Constants.EXPENSE, Constants.CASH);
            var cashTransfer = GetTotalBalance(endOfDay, Constants.BANK_TRANSFER, Constants.CASH);
            var openingCashBalance = GetOpeningCashBalance(endOfDay);

            var cashBalance = openingCashBalance + cashSales + cashReceipt - (cashPayment + cashExpense + cashTransfer);

            return cashBalance;
        }

        public decimal GetCreditBalance(string endOfDay)
        {
            var openingCreditBalance = GetOpeningCreditBalance(endOfDay);
            var creditSales = GetTotalBalance(endOfDay, Constants.SALES, Constants.CREDIT);
            var cashReceipt = GetTotalBalance(endOfDay, Constants.RECEIPT, Constants.CASH);
            var chequeReceipt = GetTotalBalance(endOfDay, Constants.RECEIPT, Constants.CHEQUE);

            var creditBalance = openingCreditBalance + creditSales - (cashReceipt + chequeReceipt);

            return creditBalance;
        }

        public decimal GetTotalCashPayment(string endOfDay)
        {
            var cashPayment = GetTotalBalance(endOfDay, Constants.PAYMENT, Constants.CASH);
            var cashExpense = GetTotalBalance(endOfDay, Constants.EXPENSE, Constants.CASH);
            var cashTransfer = GetTotalBalance(endOfDay, Constants.BANK_TRANSFER, Constants.CASH);

            var totalCashPayment = cashPayment + cashExpense + cashTransfer;

            return totalCashPayment;
        }

        public decimal GetTotalChequePayment(string endOfDay)
        {
            var chequePayment = GetTotalBalance(endOfDay, Constants.PAYMENT, Constants.CHEQUE);
            var chequeExpense = GetTotalBalance(endOfDay, Constants.EXPENSE, Constants.CHEQUE);

            var totalChequePayment = chequePayment + chequeExpense;

            return totalChequePayment;
        }

        public decimal GetTotalBalance(string endOfDay, string action, string actionType)
        {
            decimal balance = Constants.DEFAULT_DECIMAL_VALUE;
            var query = string.Empty;

            if (action?.ToLower() == Constants.SALES.ToLower()
            || action?.ToLower() == Constants.RECEIPT.ToLower())
            {
                query = @"SELECT ";
                if (actionType?.ToLower() == Constants.CREDIT.ToLower())
                {
                    query += "SUM([DueReceivedAmount]) ";
                }
                else
                {
                    query += "SUM([ReceivedAmount]) ";
                }

                query += "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE ISNULL([Income], '') = '" + Constants.DELIVERY_CHARGE + "' " +
                    ") " +
                    "AND [Id] NOT IN " +
                    "( " +
                    "SELECT [Id] " +
                    "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                    "WHERE ISNULL([Expense], '') = '" + Constants.SALES_DISCOUNT + "' " +
                    ") ";
            }
            else if (action?.ToLower() == Constants.PAYMENT.ToLower()
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.BANK_TRANSFER.ToLower())
            {
                query = @"SELECT ";

                if (actionType?.ToLower() == Constants.CREDIT.ToLower())
                {
                    query += "SUM([DuePaymentAmount]) ";
                }
                else
                {
                    query += "SUM([PaymentAmount]) ";
                }

                query += "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                        "WHERE 1 = 1 " +
                        "AND [Id] NOT IN " +
                        "( " +
                        "SELECT [Id] " +
                        "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                        "WHERE ISNULL([Income], '') = '" + Constants.DELIVERY_CHARGE + "' " +
                        ") " +
                        "AND [Id] NOT IN " +
                        "( " +
                        "SELECT [Id] " +
                        "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                        "WHERE ISNULL([Expense], '') = '" + Constants.SALES_DISCOUNT + "' " +
                        ") ";
            }
            else
            {
                query += " ";
            }

            if (!string.IsNullOrWhiteSpace(endOfDay))
            {
                query += "AND [EndOfDay] = @EndOfDay ";
            }

            if (!string.IsNullOrWhiteSpace(action))
            {
                query += "AND [Action] = @Action ";
            }

            if (!string.IsNullOrWhiteSpace(actionType))
            {
                query += "AND [ActionType] = @ActionType ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)endOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActionType", ((object)actionType) ?? DBNull.Value);
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
                logger.Error(ex);
                throw ex;
            }

            return balance;
        }

        private decimal GetPreviousTotalBalance(string endOfDay, string action, string actionType)
        {
            decimal balance = Constants.DEFAULT_DECIMAL_VALUE;
            var query = string.Empty;

            if (action?.ToLower() == Constants.SALES.ToLower()
            || action?.ToLower() == Constants.RECEIPT.ToLower())
            {
                query = @"SELECT ";
                if (actionType?.ToLower() == Constants.CREDIT.ToLower())
                {
                    query += "SUM([DueReceivedAmount]) ";
                }
                else
                {
                    query += "SUM([ReceivedAmount]) ";
                }

                query += "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                   "WHERE 1 = 1 " +
                   "AND [Id] NOT IN " +
                   "( " +
                   "SELECT [Id] " +
                   "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                   "WHERE ISNULL([Income], '') = '" + Constants.DELIVERY_CHARGE + "' " +
                   ") " +
                   "AND [Id] NOT IN " +
                   "( " +
                   "SELECT [Id] " +
                   "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                   "WHERE ISNULL([Expense], '') = '" + Constants.SALES_DISCOUNT + "' " +
                   ") ";
            }
            else if (action?.ToLower() == Constants.PAYMENT.ToLower()
                || action?.ToLower() == Constants.EXPENSE.ToLower()
                || action?.ToLower() == Constants.BANK_TRANSFER.ToLower())
            {
                query = @"SELECT ";

                if (actionType?.ToLower() == Constants.CREDIT.ToLower())
                {
                    query += "SUM([DuePaymentAmount]) ";
                }
                else
                {
                    query += "SUM([PaymentAmount]) ";
                }

                query += "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                   "WHERE 1 = 1 " +
                   "AND [Id] NOT IN " +
                   "( " +
                   "SELECT [Id] " +
                   "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                   "WHERE ISNULL([Income], '') = '" + Constants.DELIVERY_CHARGE + "' " +
                   ") " +
                   "AND [Id] NOT IN " +
                   "( " +
                   "SELECT [Id] " +
                   "FROM " + Constants.TABLE_USER_TRANSACTION + " " +
                   "WHERE ISNULL([Expense], '') = '" + Constants.SALES_DISCOUNT + "' " +
                   ") ";
            }
            else
            {
                query += " ";
            }

            if (!string.IsNullOrWhiteSpace(endOfDay))
            {
                query += "AND [EndOfDay] < @EndOfDay ";
            }

            if (!string.IsNullOrWhiteSpace(action))
            {
                query += "AND [Action] = @Action ";
            }

            if (!string.IsNullOrWhiteSpace(actionType))
            {
                query += "AND [ActionType] = @ActionType ";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", ((object)endOfDay) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Action", ((object)action) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActionType", ((object)actionType) ?? DBNull.Value);
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
                logger.Error(ex);
                throw ex;
            }

            return balance;
        }
    }
}
