using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public IEnumerable<Setting> GetSettings()
        {
            return _settingRepository.GetSettings();
        }

        public Setting AddSetting(Setting setting, bool truncate = false)
        {
            return _settingRepository.AddSetting(setting, truncate);
        }

        public Setting UpdateSetting(long id, Setting setting)
        {
            return _settingRepository.UpdateSetting(id, setting);
        }

        public bool DeletePreviousTransactions(string endOfDay)
        {
            return _settingRepository.DeletePreviousTransactions(endOfDay);
        }
    }
}
