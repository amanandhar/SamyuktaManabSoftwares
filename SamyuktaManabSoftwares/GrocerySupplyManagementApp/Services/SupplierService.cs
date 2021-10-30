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

        public string GetNewSupplierId()
        {
            string supplierId;
            var id = (_supplierRepository.GetLastSupplierId() + 1).ToString();
            if (id.Length == 1)
            {
                supplierId = "000" + id;
            }
            else if (id.Length == 2)
            {
                supplierId = "00" + id;
            }
            else if (id.Length == 3)
            {
                supplierId = "0" + id;
            }
            else
            {
                supplierId = id;
            }

            return "S" + supplierId;
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            supplier.Counter = _supplierRepository.GetLastSupplierId() + 1;
            return _supplierRepository.AddSupplier(supplier);
        }
       
        public UserTransaction AddSupplierPayment(UserTransaction userTransaction, BankTransaction bankTransaction, string username)
        {
            return _supplierRepository.AddSupplierPayment(userTransaction, bankTransaction, username);
        }

        public Supplier UpdateSupplier(string supplierId, Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplierId, supplier);
        }

        public bool DeleteSupplier(string supplierId)
        {
            return _supplierRepository.DeleteSupplier(supplierId);
        }

        public bool DeleteSupplierPayment(long id)
        {
            return _supplierRepository.DeleteSupplierPayment(id);
        }
    }
}
