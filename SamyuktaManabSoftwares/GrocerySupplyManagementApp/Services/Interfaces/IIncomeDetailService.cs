using GrocerySupplyManagementApp.DTOs;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IIncomeDetailService
    {
        IEnumerable<IncomeDetailView> GetIncomeDetails();
    }
}
