using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> GetIncomes();
        Income GetIncome(long id);
        Income AddIncome(Income income);
        Income UpdateIncome(long id, Income income);
        bool DeleteIncome(long id);
    }
}
