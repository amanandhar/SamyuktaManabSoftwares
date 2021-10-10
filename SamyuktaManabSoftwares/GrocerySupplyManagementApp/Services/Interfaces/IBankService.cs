﻿using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IBankService
    {
        #region Get Operation
        IEnumerable<Bank> GetBanks();
        Bank GetBank(long id);
        #endregion

        #region Add Operation
        Bank AddBank(Bank bank);
        #endregion

        #region Update Operation
        Bank UpdateBank(long id, Bank bank);
        #endregion

        #region Delete Operation
        bool DeleteBank(long id);
        #endregion
    }
}
