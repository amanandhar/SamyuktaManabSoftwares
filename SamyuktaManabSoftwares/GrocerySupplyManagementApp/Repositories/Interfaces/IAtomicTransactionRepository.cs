namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IAtomicTransactionRepository
    {
        #region Daily Transaction Methods
        bool DeleteBill(long id, string billNo);
        bool DeleteInvoice(string invoiceNo);
        bool DeleteStockAdjustment(long id);
        bool DeleteBankTransaction(long id);
        #endregion
    }
}
