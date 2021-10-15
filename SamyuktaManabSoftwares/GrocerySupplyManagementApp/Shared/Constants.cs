namespace GrocerySupplyManagementApp.Shared
{
    public class Constants
    {
        // Default Value
        public const decimal DEFAULT_DECIMAL_VALUE = 0.00m;

        // Action
        public const string PURCHASE = "Purchase";
        public const string SALES = "Sales";
        public const string RECEIPT = "Receipt";
        public const string PAYMENT = "Payment";
        public const string INCOME = "Income";
        public const string EXPENSE = "Expense";
        public const string ADD = "Add";
        public const string DEDUCT = "Deduct";
        public const string BANK_TRANSFER = "Bank Transfer";
        public const string RETURN = "Return";

        // Action Type
        public const string CASH = "Cash";
        public const string CREDIT = "Credit";
        public const string DEBIT = "Debit";
        public const string CHEQUE = "Cheque";
        public const string ACTION_TYPE_NONE = "None";

        public const string CLEAR = "Clear";
        public const string DUE = "Due";
        public const string OWNED = "Owened";

        // Database
        public const string DB_CONNECTION_STRING = "DBConnectionString";
        public const string TABLE_BANK = "Bank";
        public const string TABLE_BANK_TRANSACTION = "BankTransaction";
        public const string TABLE_COMPANY_INFO = "CompanyInfo";
        public const string TABLE_EMPLOYEE = "Employee";
        public const string TABLE_END_OF_DAY = "EndOfDay";
        public const string TABLE_ITEM = "Item";
        public const string TABLE_ITEM_CATEGORY = "ItemCategory";
        public const string TABLE_MEMBER = "Member";
        public const string TABLE_POS_DETAIL = "POSDetail";
        public const string TABLE_PRICED_ITEM = "PricedItem";
        public const string TABLE_PURCHASED_ITEM = "PurchasedItem";
        public const string TABLE_SETTING = "Setting";
        public const string TABLE_SHARE_MEMBER = "ShareMember";
        public const string TABLE_SOLD_ITEM = "SoldItem";
        public const string TABLE_STOCK_ADJUSTMENT = "StockAdjustment";
        public const string TABLE_SUPPLIER = "Supplier";
        public const string TABLE_USER = "User";
        public const string TABLE_USER_TRANSACTION = "UserTransaction";

        // Income
        public const string DELIVERY_CHARGE = "Delivery Charge";
        public const string MEMBER_FEE = "Member Fee";
        public const string OTHER_INCOME = "Other Income";
        public const string SALES_PROFIT = "Sales Profit";
        public const string STOCK_ADJUSTMENT = "Stock Adjustment";

        public const string BONUS_PREFIX = "BS";
        public const string BILL_NO_PREFIX = "BN";
        public const string INVOICE_NO_PREFIX = "IN";

        public const string SHARE_CAPITAL = "Share Capital";
        public const string OWNER_EQUITY = "Owner Equity";

        // Expense 
        public const string ASSET = "Asset";
        public const string ELECTRICITY = "Electricity";
        public const string FUEL_TRANSPORTATION = "Fuel & Transportation";
        public const string GUEST_HOSPITALITY = "Guest & Hospitality";
        public const string LOAN_FEE_INTEREST = "Loan Fee & Interest";
        public const string LOAN_INTEREST = "Loan Interest";
        public const string MISCELLANEOUS = "Miscellaneous";
        public const string OFFICE_RENT = "Office Rent";
        public const string REPAIR_MAINTENANCE = "Repair & Maintenance";
        public const string SALES_DISCOUNT = "Sales Discount";
        public const string SALES_RETURN = "Sales Return";
        public const string STAFF_ALLOWANCE = "Staff Allowance";
        public const string STAFF_SALARY = "Staff Salary";
        public const string TELEPHONE_INTERNET = "Telephone & Internet";

        public const string TOTAL = "Total";
        public const string DEPOSIT = "Deposit";
        public const string WITHDRAWL = "Withdrawl";

        // Liabilities
        public const string LIABILITIES = "Liabilities";
        public const string LOAN_AMOUNT = "Loan Amount";
        public const string PAYABLE_AMOUNT = "Payable Amount";
        public const string NET_PROFIT = "Net Profit";
        public const string BALANCE = "Balance";

        // Assets
        public const string ASSETS = "Assets";
        public const string CASH_IN_HAND = "Cash In Hand";
        public const string BANK_ACCOUNT = "Bank Account";
        public const string STOCK_VALUE = "Stock Value";
        public const string RECEIVABLE_AMOUNT = "Receivable Amount";
        public const string NET_LOSS = "Net Loss";

        //Images
        public const string BASE_IMAGE_FOLDER = "BaseImageFolder";

        //Employee
        public const string DELIVERY_PERSON = "Delivery Person";

        //Page Margin
        public const string PAGE_MARGIN_TOP = "PageMarginTop";
        public const string PAGE_MARGIN_BOTTOM = "PageMarginBottom";
        public const string PAGE_MARGIN_LEFT = "PageMarginLeft";
        public const string PAGE_MARGIN_RIGHT = "PageMarginRight";

        //Users
        public const string ADMIN = "Admin";
        public const string STAFF = "Staff";
        public const string GUEST = "Guest";

        //Item Unit
        public const string KILOGRAM = "Kg";
        public const string GRAM = "Grm";
        public const string LITER = "Ltr";
        public const string MILLI_LITER = "ML";
        public const string PIECES = "Pcs";
        public const string PACKET = "Pkt";
        public const string BAG = "Bag";
        public const string BOTTLE = "Btl";
        public const string CAN = "Can";
        public const string DOZEN = "Dzn";

        //Item Unit
        public const string CATEGORY_A = "A";
        public const string CATEGORY_B = "B";
        public const string CATEGORY_C = "C";
        public const string CATEGORY_D = "D";
        public const string CATEGORY_E = "E";
        public const string CATEGORY_F = "F";
        public const string CATEGORY_G = "G";
        public const string CATEGORY_H = "H";
        public const string CATEGORY_I = "I";
        public const string CATEGORY_J = "J";
        public const string CATEGORY_K = "K";
        public const string CATEGORY_L = "L";
        public const string CATEGORY_M = "M";
        public const string CATEGORY_N = "N";
        public const string CATEGORY_O = "O";
        public const string CATEGORY_P = "P";
        public const string CATEGORY_Q = "Q";
        public const string CATEGORY_R = "R";
        public const string CATEGORY_S = "S";
        public const string CATEGORY_T = "T";
        public const string CATEGORY_U = "U";
        public const string CATEGORY_V = "V";
        public const string CATEGORY_W = "W";
        public const string CATEGORY_X = "X";
        public const string CATEGORY_Y = "Y";
        public const string CATEGORY_Z = "Z";

        // Eduction 
        public const string EDUCATION_FIVE = "Five";
        public const string EDUCATION_SIX = "Six";
        public const string EDUCATION_SEVEN = "Seven";
        public const string EDUCATION_EIGHT = "Eight";
        public const string EDUCATION_NINE = "Nine";
        public const string EDUCATION_SEE = "SEE";
        public const string EDUCATION_A_LEVEL = "A Level";
        public const string EDUCATION_PLUS_2 = "Plus 2";
        public const string EDUCATION_INTERMEDIATE = "Intermediate";
        public const string EDUCATION_BACHELORS = "Bachelors";
        public const string EDUCATION_MASTERS = "Masters";
        public const string EDUCATION_PHD = "PHD";
        public const string EDUCATION_NONE = "None";

        // Blood Group
        public const string BLOOD_GROUP_A_POSITIVE = "A+";
        public const string BLOOD_GROUP_A_NEGATIVE = "A-";
        public const string BLOOD_GROUP_B_POSITIVE = "B+";
        public const string BLOOD_GROUP_B_NEGATIVE = "B-";
        public const string BLOOD_GROUP_O_POSITIVE = "O+";
        public const string BLOOD_GROUP_O_NEGATIVE = "O-";
        public const string BLOOD_GROUP_AB_POSITIVE = "AB+";
        public const string BLOOD_GROUP_AB_NEGATIVE = "AB-";

        // Gender
        public const string MALE = "Male";
        public const string FEMALE = "Female";

        // Marital Status
        public const string SINGLE = "Single";
        public const string MARRIED = "Married";
        public const string DIVORCED = "Divorced";

        // Post Status
        public const string POST_STATUS_DAILY = "Daily";
        public const string POST_STATUS_TEMPORARY = "Temporary";
        public const string POST_STATUS_PERMANENT = "Permanent";

    }
}
