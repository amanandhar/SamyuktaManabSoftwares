using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Services
{
    public class SupplierTransactionService: ISupplierTransactionService
    {
        private readonly ISupplierTransactionRepository _supplierTransactionRepository;

        public SupplierTransactionService(ISupplierTransactionRepository supplierTransactionRepository)
        {
            _supplierTransactionRepository = supplierTransactionRepository;
        }

        public IEnumerable<DTOs.SupplierTransaction> GetSupplierTransactions(string supplierName)
        {
            return _supplierTransactionRepository.GetSupplierTransactions(supplierName);
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

        public bool DeleteSupplierTransaction(string supplierTransactionId)
        {
            return _supplierTransactionRepository.DeleteSupplierTransaction(supplierTransactionId);
        }
    }
}
