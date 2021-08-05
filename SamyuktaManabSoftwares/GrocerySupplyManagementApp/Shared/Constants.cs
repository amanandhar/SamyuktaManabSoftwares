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
        public const string TABLE_BANK = "Bank";
        public const string TABLE_BANK_TRANSACTION = "BankTransaction";
        public const string TABLE_COMPANY_INFO = "CompanyInfo";
        public const string TABLE_END_OF_DAY = "EndOfDay";
        public const string TABLE_FISCAL_YEAR = "FiscalYear";
        public const string TABLE_ITEM = "Item";
        public const string TABLE_MEMBER = "Member";
        public const string TABLE_PRICED_ITEM = "PricedItem";
        public const string TABLE_PURCHASED_ITEM = "PurchasedItem";
        public const string TABLE_SOLD_ITEM = "SoldItem";
        public const string TABLE_SUPPLIER = "Supplier";
        public const string TABLE_TAX = "Tax";
        public const string TABLE_USER_TRANSACTION = "UserTransaction";

        // Income
        public const string DELIVERY_CHARGE = "Delivery Charge";
        public const string MEMBER_FEE = "Member Fee";
        public const string OTHER_INCOME = "Other Income";
        public const string SALES_PROFIT = "Sales Profit";

        public const string SHARE_CAPITAL = "Share Capital";
        public const string OWNER_EQUITY = "Owner Equity";

        // Expense 
        public const string ASSET = "Asset (Computer, Furniture etc.)";
        public const string ELECTRICITY = "Electricity";
        public const string FUEL_TRANSPORTATION = "Fuel & Transportation";
        public const string GUEST_HOSPITALITY = "Guest & Hospitality";
        public const string LOAN_FEE_INTEREST = "Loan Fee & Interest";
        public const string MISCELLANEOUS = "Miscellaneous";
        public const string OFFICE_RENT = "Office Rent";
        public const string REPAIR_MAINTENANCE = "Repair & Maintenance";
        public const string SALES_DISCOUNT = "Sales Discount";
        public const string STAFF_ALLOWANCE = "Staff Allowance";
        public const string STAFF_SALARY = "Staff Salary";
        public const string TELEPHONE_INTERNET = "Telephone & Internet";

        public const string TOTAL = "Total";
        public const string DEPOSIT = "Deposit";
        public const string WITHDRAWL = "Withdrawl";

        //Images
        public const string BASE_IMAGE_FOLDER = "BaseImageFolder";
    }
}
