using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class AtomicTransactionService : IAtomicTransactionService
    {
        private readonly IAtomicTransactionRepository _atomicTransactionRepository;

        public AtomicTransactionService(IAtomicTransactionRepository atomicTransactionRepository)
        {
            _atomicTransactionRepository = atomicTransactionRepository;
        }

        #region Daily Transaction Methods
        public bool DeleteBill(long id, string billNo)
        {
            return _atomicTransactionRepository.DeleteBill(id, billNo);
        }

        public bool DeleteInvoice(string invoiceNo)
        {
            return _atomicTransactionRepository.DeleteInvoice(invoiceNo);
        }

        public bool DeleteStockAdjustment(long id)
        {
            return _atomicTransactionRepository.DeleteStockAdjustment(id);
        }

        public bool DeleteBankTransaction(long id)
        {
            return _atomicTransactionRepository.DeleteBankTransaction(id);
        }
        #endregion

        #region POS Methods
        public bool SaveSalesDetail(List<SoldItem> soldItems, UserTransaction userTransaction, POSDetail posDetail, string username)
        {
            return _atomicTransactionRepository.SaveSalesDetail(soldItems, userTransaction, posDetail, username);
        }
        #endregion
    }
}
