using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IEndOfDayService
    {
        EndOfDay GetEndOfDay(string date);
        EndOfDay GetNextEndOfDay(long id);
        bool IsEndOfDayExist(string endOfDay);
    }
}
