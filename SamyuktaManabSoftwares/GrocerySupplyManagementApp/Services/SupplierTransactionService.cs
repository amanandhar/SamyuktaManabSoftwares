using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class SupplierTransactionService: ISupplierTransactionService
    {
        private readonly ISupplierTransactionRepository _supplierTransactionRepository;

        public SupplierTransactionService(ISupplierTransactionRepository supplierTransactionRepository)
        {
            _supplierTransactionRepository = supplierTransactionRepository;
        }

        public IEnumerable<DTOs.SupplierTransactionView> GetSupplierTransactions(string supplierName)
        {
            return _supplierTransactionRepository.GetSupplierTransactions(supplierName);
        }

        public decimal GetBalance(string supplierName)
        {
            return _supplierTransactionRepository.GetBalance(supplierName);
        }

        public SupplierTransaction GetSupplierTransaction(string supplierName)
        {
            return _supplierTransactionRepository.GetSupplierTransaction(supplierName);
        }

        public SupplierTransaction AddSupplierTransaction(SupplierTransaction supplierTransaction)
        {
            return _supplierTransactionRepository.AddSupplierTransaction(supplierTransaction);
        }

        public SupplierTransaction UpdateSupplierTransaction(string supplierTransactionId, SupplierTransaction supplierTransaction)
        {
            return _supplierTransactionRepository.UpdateSupplierTransaction(supplierTransactionId, supplierTransaction);
        }

        public bool DeleteSupplierTransaction(long supplierTransactionId)
        {
            return _supplierTransactionRepository.DeleteSupplierTransaction(supplierTransactionId);
        }
    }
}
