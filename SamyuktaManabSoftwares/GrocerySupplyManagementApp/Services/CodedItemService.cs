using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class CodedItemService : ICodedItemService
    {
        private readonly ICodedItemRepository _codedItemRepository;

        public CodedItemService(ICodedItemRepository codedItemRepository)
        {
            _codedItemRepository = codedItemRepository;
        }

        public IEnumerable<CodedItem> GetCodedItems()
        {
            return _codedItemRepository.GetCodedItems();
        }

        public CodedItem GetCodedItem(long id)
        {
            return _codedItemRepository.GetCodedItem(id);
        }

        public IEnumerable<CodedItemView> GetCodedItemViewList()
        {
            return _codedItemRepository.GetCodedItemViewList();
        }

        public IEnumerable<CodedItemView> GetCodedUnCodedItemViewList()
        {
            return _codedItemRepository.GetCodedUnCodedItemViewList();
        }

        public CodedItem AddCodedItem(CodedItem codedItem)
        {
            return _codedItemRepository.AddCodedItem(codedItem);
        }

        public CodedItem UpdateCodedItem(long id, CodedItem codedItem)
        {
            return _codedItemRepository.UpdateCodedItem(id, codedItem);
        }

        public bool DeleteCodedItem(long id)
        {
            return _codedItemRepository.DeleteCodedItem(id);
        } 
    }
}
