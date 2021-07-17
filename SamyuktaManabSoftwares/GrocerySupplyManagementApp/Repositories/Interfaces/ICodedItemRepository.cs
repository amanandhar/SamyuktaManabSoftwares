using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ICodedItemRepository
    {
        IEnumerable<CodedItem> GetCodedItems();
        CodedItem GetCodedItem(long id);
        CodedItem AddCodedItem(CodedItem codedItem);
        CodedItem UpdateCodedItem(long id, CodedItem codedItem);
        bool DeleteCodedItem(long id);
        IEnumerable<CodedItemView> GetCodedItemViewList();
    }
}
