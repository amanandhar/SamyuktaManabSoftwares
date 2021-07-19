using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ICodedItemService
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
