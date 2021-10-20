using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface ISettingService
    {
        IEnumerable<Setting> GetSettings();

        Setting AddSetting(Setting setting, bool truncate = false);

        Setting UpdateSetting(long id, Setting setting);

        bool DeletePreviousTransactions(string endOfDay);
    }
}
