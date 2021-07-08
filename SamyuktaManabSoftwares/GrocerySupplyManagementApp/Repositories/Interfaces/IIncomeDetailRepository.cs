using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IIncomeDetailRepository
    {
        IEnumerable<IncomeDetailView> GetIncomeDetails();
    }
}
