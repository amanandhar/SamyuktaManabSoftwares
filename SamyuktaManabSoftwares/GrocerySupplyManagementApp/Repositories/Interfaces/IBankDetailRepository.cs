using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IBankDetailRepository
    {
        IEnumerable<BankDetail> GetBankDetails();
        BankDetail GetBankDetail(long bankId);
        BankDetail AddBankDetail(BankDetail bankDetail);
        BankDetail UpdateBankDetail(long bankId, BankDetail bankDetail);
        bool DeleteBankDetail(long bankId);
    }
}
