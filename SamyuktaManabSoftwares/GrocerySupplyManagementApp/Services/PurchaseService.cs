using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PurchaseService: IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return _purchaseRepository.GetPurchases();
        }

        public Purchase GetPurchase(string employeeId)
        {
            return _purchaseRepository.GetPurchase(employeeId);
        }

        public Purchase AddPurchase(Purchase purchase)
        {
            return _purchaseRepository.AddPurchase(purchase);
        }

        public Purchase UpdatePurchase(string employeeId, Purchase purchase)
        {
            return _purchaseRepository.UpdatePurchase(employeeId, purchase);
        }

        public bool DeletePurchase(string employeeId)
        {
            return _purchaseRepository.DeletePurchase(employeeId);
        }
    }
}
