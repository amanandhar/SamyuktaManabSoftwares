﻿using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface ISettingRepository
    {
        IEnumerable<Setting> GetSettings();
        Setting GetSetting(long id);

        Setting AddSetting(Setting setting, bool truncate = false);

        Setting UpdateSetting(long id, Setting setting);

        bool DeleteSetting(long id);
    }
}
