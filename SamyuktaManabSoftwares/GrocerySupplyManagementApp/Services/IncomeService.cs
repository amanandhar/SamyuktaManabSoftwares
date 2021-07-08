using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public IEnumerable<Income> GetIncomes()
        {
            return _incomeRepository.GetIncomes();
        }

        public Income GetIncome(long id)
        {
            return _incomeRepository.GetIncome(id);
        }

        public Income AddIncome(Income income)
        {
            return _incomeRepository.AddIncome(income);
        }

        public bool DeleteIncome(long id)
        {
            return _incomeRepository.DeleteIncome(id);
        }

        public Income UpdateIncome(long id, Income income)
        {
            return _incomeRepository.UpdateIncome(id, income);
        }
    }
}
