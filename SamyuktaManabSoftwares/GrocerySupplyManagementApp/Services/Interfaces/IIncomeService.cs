using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IIncomeService
    {
        IEnumerable<Income> GetIncomes();
        Income GetIncome(long id);
        Income AddIncome(Income income);
        Income UpdateIncome(long id, Income income);
        bool DeleteIncome(long id);
    }
}
