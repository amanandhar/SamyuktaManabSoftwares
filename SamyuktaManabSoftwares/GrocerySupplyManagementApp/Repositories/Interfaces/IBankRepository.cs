using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IBankRepository
    {
        IEnumerable<Bank> GetBanks();
        Bank GetBank(long id);

        Bank AddBank(Bank bank);

        Bank UpdateBank(long id, Bank bank);

        bool DeleteBank(long id);
    }
}
