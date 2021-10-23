using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class DailyTransactionService : IDailyTransactionService
    {
        private readonly IDailyTransactionRepository _dailyTransactionRepository;

        public DailyTransactionService(IDailyTransactionRepository dailyTransactionRepository)
        {
            _dailyTransactionRepository = dailyTransactionRepository;
        }

        public bool DeleteBill(long id, string billNo)
        {
            return _dailyTransactionRepository.DeleteBill(id, billNo);
        }

        public bool DeleteInvoice(string invoiceNo)
        {
            return _dailyTransactionRepository.DeleteInvoice(invoiceNo);
        }

        public bool DeleteStockAdjustment(long id)
        {
            return _dailyTransactionRepository.DeleteStockAdjustment(id);
        }

        public bool DeleteBankTransaction(long id)
        {
            return _dailyTransactionRepository.DeleteBankTransaction(id);
        }
    }
}
