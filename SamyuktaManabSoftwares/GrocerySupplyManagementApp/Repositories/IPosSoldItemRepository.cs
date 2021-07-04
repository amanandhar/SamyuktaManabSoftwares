using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IPosSoldItemRepository
    {
        IEnumerable<PosSoldItem> GetPosSoldItems();
        PosSoldItem GetPosSoldItem(long posSoldItemId);
        PosSoldItem AddPosSoldItem(PosSoldItem posSoldItem);
        PosSoldItem UpdatePosSoldItem(long posITransactionId, PosSoldItem posSoldItem);
        bool DeletePosSoldItem(long posSoldItemId, PosSoldItem posSoldItem);
        bool DeletePosSoldItem(string invoiceNo);
        IEnumerable<PosSoldItemGrid> GetPosSoldItemGrid(string invoiceNo);
    }
}
