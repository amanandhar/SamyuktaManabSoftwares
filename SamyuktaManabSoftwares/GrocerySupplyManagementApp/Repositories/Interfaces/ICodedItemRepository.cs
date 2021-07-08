﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ICodedItemRepository
    {
        IEnumerable<CodedItem> GetPreparedItems();
        CodedItem GetPreparedItem(long id);
        IEnumerable<ItemCodedView> GetPreparedItemGrid();
        CodedItem AddPreparedItem(CodedItem preparedItem);
        CodedItem UpdatePreparedItem(long id, CodedItem preparedItem);
        bool DeletePreparedItem(long id);
    }
}
