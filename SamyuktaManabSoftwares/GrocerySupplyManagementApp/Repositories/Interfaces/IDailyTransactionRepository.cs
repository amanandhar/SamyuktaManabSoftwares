namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IDailyTransactionRepository
    {
        bool DeleteBill(long id, string billNo);
        bool DeleteInvoice(string invoiceNo);
        bool DeleteStockAdjustment(long id);
        bool DeleteBankTransaction(long id);
    }
}
