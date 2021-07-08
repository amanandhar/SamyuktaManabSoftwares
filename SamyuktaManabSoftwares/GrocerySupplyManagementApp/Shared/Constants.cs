namespace GrocerySupplyManagementApp.Shared
{
    public class Constants
    {
        // Action
        public const string PURCHASE = "Purchase";
        public const string SALES = "Sales";
        public const string RECEIPT = "Receipt";
        public const string PAYMENT = "Payment";
        public const string EXPENSE = "Expense";
        public const string TRANSFER = "Transfer";

        // Action Type
        public const string CASH = "Cash";
        public const string CREDIT = "Credit";
        public const string CHEQUE = "Cheque";

        public const string CLEAR = "Clear";
        public const string DUE = "Due";

        // Database
        public const string DB_CONNECTION_STRING = "DBConnectionString";
        public const string TABLE_BANK_DETAIL = "BankDetail";
        public const string TABLE_BANK_TRANSACTION = "BankTransaction";
        public const string TABLE_CODED_ITEM = "CodedItem";
        public const string TABLE_FISCAL_YEAR_DETAIL = "FiscalYearDetail";
        public const string TABLE_ITEM = "Item";
        public const string TABLE_MEMBER = "Member";
        public const string TABLE_PURCHASED_ITEM = "PurchasedItem";
        public const string TABLE_SOLD_ITEM = "SoldItem";
        public const string TABLE_SUPPLIER = "Supplier";
        public const string TABLE_TAX_DETAIL = "TaxDetail";
        public const string TABLE_USER_TRANSACTION = "UserTransaction";
    }
}
