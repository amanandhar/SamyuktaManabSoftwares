using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IAtomicTransactionService
    {
        #region Daily Transaction Form Methods
        bool DeleteBill(long id, string billNo);
        bool DeleteInvoice(string invoiceNo);
        bool DeleteBankTransaction(long id);
        #endregion

        #region POS Methods
        bool SaveSalesDetail(List<SoldItem> soldItems, UserTransaction userTransaction, POSDetail posDetail, string username);
        #endregion
    }
}
