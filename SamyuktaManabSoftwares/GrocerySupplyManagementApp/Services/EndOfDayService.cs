using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;

namespace GrocerySupplyManagementApp.Services
{
    public class EndOfDayService : IEndOfDayService
    {
        private readonly IEndOfDayRepository _endOfDayRepository;

        public EndOfDayService(IEndOfDayRepository endOfDayRepository)
        {
            _endOfDayRepository = endOfDayRepository;
        }

        public EndOfDay GetEndOfDay(string date)
        {
            return _endOfDayRepository.GetEndOfDay(date);
        }

        public EndOfDay GetNextEndOfDay(long id)
        {
            return _endOfDayRepository.GetNextEndOfDay(id);
        }

        public bool IsEndOfDayExist(string endOfDay)
        {
            return _endOfDayRepository.IsEndOfDayExist(endOfDay);
        }
    }
}
