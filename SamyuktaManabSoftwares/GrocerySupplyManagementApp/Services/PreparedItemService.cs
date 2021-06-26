using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PreparedItemService : IPreparedItemService
    {
        private readonly IPreparedItemRepository _preparedItemRepository;

        public PreparedItemService(IPreparedItemRepository preparedItemRepository)
        {
            _preparedItemRepository = preparedItemRepository;
        }

        public IEnumerable<PreparedItem> GetPreparedItems()
        {
            return _preparedItemRepository.GetPreparedItems();
        }

        public PreparedItem GetPreparedItem(long id)
        {
            return _preparedItemRepository.GetPreparedItem(id);
        }

        public IEnumerable<PreparedItemGrid> GetPreparedItemGrid()
        {
            return _preparedItemRepository.GetPreparedItemGrid();
        }

        public PreparedItem AddPreparedItem(PreparedItem preparedItem)
        {
            return _preparedItemRepository.AddPreparedItem(preparedItem);
        }

        public PreparedItem UpdatePreparedItem(long id, PreparedItem preparedItem)
        {
            return _preparedItemRepository.UpdatePreparedItem(id, preparedItem);
        }

        public bool DeletePreparedItem(long id)
        {
            return _preparedItemRepository.DeletePreparedItem(id);
        }
    }
}
