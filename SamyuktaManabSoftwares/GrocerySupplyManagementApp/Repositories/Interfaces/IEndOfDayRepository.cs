using GrocerySupplyManagementApp.Entities;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IEndOfDayRepository
    {
        EndOfDay GetEndOfDay(string date);
        EndOfDay GetNextEndOfDay(long id);
    }
}
