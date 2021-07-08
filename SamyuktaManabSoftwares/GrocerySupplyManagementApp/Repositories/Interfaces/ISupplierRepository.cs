using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplier(string supplierId);
        Supplier AddSupplier(Supplier supplier);
        Supplier UpdateSupplier(string supplierId, Supplier supplier);
        bool DeleteSupplier(string supplierId);
    }
}
