using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

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
    }
}
