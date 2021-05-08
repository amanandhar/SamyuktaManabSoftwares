using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IPurchaseService
    {
        IEnumerable<Purchase> GetPurchases();

        Purchase GetPurchase(string purchaseId);

        Purchase AddPurchase(Purchase purchase);

        Purchase UpdatePurchase(string purchaseId, Purchase purchase);

        bool DeletePurchase(string purchaseId);
    }
}
