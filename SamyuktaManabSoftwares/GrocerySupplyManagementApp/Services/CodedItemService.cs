using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class CodedItemService : ICodedItemService
    {
        private readonly ICodedItemRepository _preparedItemRepository;

        public CodedItemService(ICodedItemRepository preparedItemRepository)
        {
            _preparedItemRepository = preparedItemRepository;
        }

        public IEnumerable<CodedItem> GetPreparedItems()
        {
            return _preparedItemRepository.GetPreparedItems();
        }

        public CodedItem GetPreparedItem(long id)
        {
            return _preparedItemRepository.GetPreparedItem(id);
        }

        public IEnumerable<ItemCodedView> GetPreparedItemGrid()
        {
            return _preparedItemRepository.GetPreparedItemGrid();
        }

        public CodedItem AddPreparedItem(CodedItem preparedItem)
        {
            return _preparedItemRepository.AddPreparedItem(preparedItem);
        }

        public CodedItem UpdatePreparedItem(long id, CodedItem preparedItem)
        {
            return _preparedItemRepository.UpdatePreparedItem(id, preparedItem);
        }

        public bool DeletePreparedItem(long id)
        {
            return _preparedItemRepository.DeletePreparedItem(id);
        }
    }
}
