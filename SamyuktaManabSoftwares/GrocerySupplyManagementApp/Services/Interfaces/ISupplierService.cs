using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplier(string supplierId);
        string GetNewSupplierId();

        Supplier AddSupplier(Supplier supplier);
        UserTransaction AddSupplierPayment(UserTransaction userTransaction, BankTransaction bankTransaction, string username);

        Supplier UpdateSupplier(string supplierId, Supplier supplier);

        bool DeleteSupplier(string supplierId);
        bool DeleteSupplierPayment(long id);
    }
}
