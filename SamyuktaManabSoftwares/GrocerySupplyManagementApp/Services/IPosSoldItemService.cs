using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IPosSoldItemService
    {
        IEnumerable<PosSoldItem> GetPosSoldItems();
        PosSoldItem GetPosSoldItem(long posSoldItemId);
        PosSoldItem AddPosSoldItem(PosSoldItem posSoldItem);
        PosSoldItem UpdatePosSoldItem(long posSoldItemId, PosSoldItem posSoldItem);
        bool DeleteSupplierTransaction(long posSoldItemId);
        bool DeletePosSoldItem(string invoiceNo);
        IEnumerable<PosSoldItemGrid> GetPosSoldItemGrid(string invoiceNo);
    }
}
