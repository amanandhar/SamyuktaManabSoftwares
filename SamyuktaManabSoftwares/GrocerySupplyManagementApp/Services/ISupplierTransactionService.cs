﻿using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface ISupplierTransactionService
    {
        IEnumerable<DTOs.SupplierTransaction> GetSupplierTransactions(string supplierName);
        SupplierTransaction GetSupplierTransaction(string supplierTransactionId);
        SupplierTransaction AddSupplierTransaction(SupplierTransaction supplierTransaction);
        SupplierTransaction UpdateSupplierTransaction(string supplierTransactionId, SupplierTransaction supplierTransaction);
        bool DeleteSupplierTransaction(string supplierTransactionId);
    }
}
