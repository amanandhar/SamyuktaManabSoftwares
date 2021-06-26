using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IPreparedItemRepository
    {
        IEnumerable<PreparedItem> GetPreparedItems();
        PreparedItem GetPreparedItem(long id);
        IEnumerable<PreparedItemGrid> GetPreparedItemGrid();
        PreparedItem AddPreparedItem(PreparedItem preparedItem);
        PreparedItem UpdatePreparedItem(long id, PreparedItem preparedItem);
        bool DeletePreparedItem(long id);
    }
}
