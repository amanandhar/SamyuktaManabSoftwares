using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IIncomeDetailService
    {
        IEnumerable<IncomeDetailView> GetIncomeDetails();
    }
}
