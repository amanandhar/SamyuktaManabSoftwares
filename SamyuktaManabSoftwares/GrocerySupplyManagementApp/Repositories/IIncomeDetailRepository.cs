using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IIncomeDetailRepository
    {
        IEnumerable<IncomeDetailView> GetIncomeDetails();
    }
}
