using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class SupplierService: ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _supplierRepository.GetSuppliers();
        }

        public Supplier GetSupplier(string supplierId)
        {
            return _supplierRepository.GetSupplier(supplierId);
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        public Supplier UpdateSupplier(string supplierId, Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplierId, supplier);
        }

        public bool DeleteSupplier(string supplierId)
        {
            return _supplierRepository.DeleteSupplier(supplierId);
        }
    }
}
