using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetPurchases();
        Purchase GetPurchase(string purchaseId);
        Purchase AddPurchase(Purchase purchase);
        Purchase UpdatePurchase(string purchaseId, Purchase purchase);
        bool DeletePurchase(string purchaseId);
    }
}
