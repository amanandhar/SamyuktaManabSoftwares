namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IDailyTransactionService
    {
        bool DeleteBill(long id, string billNo);
        bool DeleteInvoice(string invoiceNo);
        bool DeleteStockAdjustment(long id);
        bool DeleteBankTransaction(long id);
    }
}
