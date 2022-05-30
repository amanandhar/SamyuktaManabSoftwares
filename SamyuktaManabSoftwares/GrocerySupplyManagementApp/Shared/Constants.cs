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
        public const string BANK_TRANSFER = "Bank Transfer";
        public const string OWNER_EQUITY = "Owner Equity";
        public const string SHARE_CAPITAL = "Share Capital";
        public const string RETURN = "Return";

        // Action Type
        public const string CASH = "Cash";
        public const string CREDIT = "Credit";
        public const string CHEQUE = "Cheque";
        public const string ADD = "Add";
        public const string DEDUCT = "Deduct";

        public const string DEBIT = "Debit";
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
        public const string TABLE_INCOME_EXPENSE = "IncomeExpense";
        public const string TABLE_ITEM = "Item";
        public const string TABLE_ITEM_CATEGORY = "ItemCategory";
        public const string TABLE_MEMBER = "Member";
        public const string TABLE_POS_DETAIL = "POSDetail";
        public const string TABLE_PRICED_ITEM = "PricedItem";
        public const string TABLE_PURCHASED_ITEM = "PurchasedItem";
        public const string TABLE_QUANTITY_SETTING = "QuantitySetting";
        public const string TABLE_SETTING = "Setting";
        public const string TABLE_SHARE_MEMBER = "ShareMember";
        public const string TABLE_SOLD_ITEM = "SoldItem";
        public const string TABLE_STOCK_ADJUSTMENT = "StockAdjustment";
        public const string TABLE_SUPPLIER = "Supplier";
        public const string TABLE_USER = "User";
        public const string TABLE_USER_TRANSACTION = "UserTransaction";

        // Income
        public const string BANK_INTEREST = "Bank Interest";
        public const string DELIVERY_CHARGE = "Delivery Charge";
        public const string OTHER_INCOME = "Other Income";
        public const string SALES_PROFIT = "Sales Profit";
        public const string STOCK_ADJUSTMENT = "Stock Adjustment";

        public const string BONUS_PREFIX = "BS";
        public const string BILL_NO_PREFIX = "BN";
        public const string INVOICE_NO_PREFIX = "IN";

        // Expense 
        public const string ASSET = "Asset";
        public const string COMMISSION = "Commission";
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
        public const string COMPANY_IMAGE_FOLDER = "CompanyImageFolder";
        public const string EMPLOYEE_IMAGE_FOLDER = "EmployeeImageFolder";
        public const string ITEM_IMAGE_FOLDER = "ItemImageFolder";
        public const string MEMBER_IMAGE_FOLDER = "MemberImageFolder";
        public const string SHARE_MEMBER_IMAGE_FOLDER = "ShareMemberImageFolder";

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
        public const string BOX = "Box";

        //Item Category
        public const string CATEGORY_10 = "10";
        public const string CATEGORY_11 = "11";
        public const string CATEGORY_12 = "12";
        public const string CATEGORY_13 = "13";
        public const string CATEGORY_14 = "14";
        public const string CATEGORY_15 = "15";
        public const string CATEGORY_16 = "16";
        public const string CATEGORY_17 = "17";
        public const string CATEGORY_18 = "18";
        public const string CATEGORY_19 = "19";
        public const string CATEGORY_20 = "20";
        public const string CATEGORY_21 = "21";
        public const string CATEGORY_22 = "22";
        public const string CATEGORY_23 = "23";
        public const string CATEGORY_24 = "24";
        public const string CATEGORY_25 = "25";
        public const string CATEGORY_26 = "26";
        public const string CATEGORY_27 = "27";
        public const string CATEGORY_28 = "28";
        public const string CATEGORY_29 = "29";
        public const string CATEGORY_30 = "30";
        public const string CATEGORY_31 = "31";
        public const string CATEGORY_32 = "32";
        public const string CATEGORY_33 = "33";
        public const string CATEGORY_34 = "34";
        public const string CATEGORY_35 = "35";
        public const string CATEGORY_36 = "36";
        public const string CATEGORY_37 = "37";
        public const string CATEGORY_38 = "38";
        public const string CATEGORY_39 = "39";
        public const string CATEGORY_40 = "40";
        public const string CATEGORY_41 = "41";
        public const string CATEGORY_42 = "42";
        public const string CATEGORY_43 = "43";
        public const string CATEGORY_44 = "44";
        public const string CATEGORY_45 = "45";
        public const string CATEGORY_46 = "46";
        public const string CATEGORY_47 = "47";
        public const string CATEGORY_48 = "48";
        public const string CATEGORY_49 = "49";
        public const string CATEGORY_50 = "50";
        public const string CATEGORY_51 = "51";
        public const string CATEGORY_52 = "52";
        public const string CATEGORY_53 = "53";
        public const string CATEGORY_54 = "54";
        public const string CATEGORY_55 = "55";
        public const string CATEGORY_56 = "56";
        public const string CATEGORY_57 = "57";
        public const string CATEGORY_58 = "58";
        public const string CATEGORY_59 = "59";

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

        // Database
        public const string DB_BACKUP_LOCATION = "DatabaseBackupLocation";
        public const string DB_BACKUP_PREFIX = "DatabaseBackupPrefix";
        public const string DB_BACKUP_FREQUENCY = "DatabaseBackupFrequency";

        // MessageBox Message
        public const string MESSAGE_BOX_DELETE_MESSAGE = "Do you want to delete?";
        public const string MESSAGE_BOX_UPDATE_MESSAGE = "Do you want to update?";

        // Vat
        public const decimal VAT_DEFAULT_AMOUNT = 13.00m;

        // Adjustment Type
        public const string INCREMENT_SIGN = "+";
        public const string DECREMENT_SIGN = "-";
    }
}
