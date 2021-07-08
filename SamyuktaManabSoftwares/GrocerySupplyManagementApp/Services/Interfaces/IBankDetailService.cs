using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IBankDetailService
    {
        IEnumerable<BankDetail> GetBankDetails();
        BankDetail GetBankDetail(long bankId);
        BankDetail AddBankDetail(BankDetail bankDetail);
        BankDetail UpdateBankDetail(long bankId, BankDetail bankDetail);
        bool DeleteBankDetail(long bankId);
    }
}
