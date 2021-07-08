using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IBankDetailService
    {
        IEnumerable<Bank> GetBankDetails();
        Bank GetBankDetail(long bankId);
        Bank AddBankDetail(Bank bankDetail);
        Bank UpdateBankDetail(long bankId, Bank bankDetail);
        bool DeleteBankDetail(long bankId);
    }
}
