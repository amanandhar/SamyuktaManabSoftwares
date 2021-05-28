using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface ISupplierTransactionRepository
    {
        IEnumerable<DTOs.SupplierTransactionView> GetSupplierTransactions(string supplierName);
        decimal GetBalance(string supplierName);
        SupplierTransaction GetSupplierTransaction(string supplierTransactionId);
        SupplierTransaction AddSupplierTransaction(SupplierTransaction supplierTransaction);
        SupplierTransaction UpdateSupplierTransaction(string supplierTransactionId, SupplierTransaction supplierTransaction);
        bool DeleteSupplierTransaction(long supplierTransactionId);
    }
}
