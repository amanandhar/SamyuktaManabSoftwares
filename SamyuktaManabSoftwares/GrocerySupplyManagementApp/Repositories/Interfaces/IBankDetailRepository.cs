using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IBankDetailRepository
    {
        IEnumerable<Bank> GetBankDetails();
        Bank GetBankDetail(long bankId);
        Bank AddBankDetail(Bank bankDetail);
        Bank UpdateBankDetail(long bankId, Bank bankDetail);
        bool DeleteBankDetail(long bankId);
    }
}
