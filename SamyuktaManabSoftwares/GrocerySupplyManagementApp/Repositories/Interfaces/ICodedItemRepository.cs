using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ICodedItemRepository
    {
        IEnumerable<CodedItem> GetCodedItems();
        CodedItem GetCodedItem(long id);
        IEnumerable<CodedItemView> GetCodedItemViewList();
        IEnumerable<CodedItemView> GetCodedUnCodedItemViewList();

        CodedItem AddCodedItem(CodedItem codedItem);

        CodedItem UpdateCodedItem(long id, CodedItem codedItem);

        bool DeleteCodedItem(long id);
    }
}
