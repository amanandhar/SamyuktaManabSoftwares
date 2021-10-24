namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IAtomicTransactionService
    {
        #region Daily Transaction Form Methods
        bool DeleteBill(long id, string billNo);
        bool DeleteInvoice(string invoiceNo);
        bool DeleteStockAdjustment(long id);
        bool DeleteBankTransaction(long id);
        #endregion
    }
}
