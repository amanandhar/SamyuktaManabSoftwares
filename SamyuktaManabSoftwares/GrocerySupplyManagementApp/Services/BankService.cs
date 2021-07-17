using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IEnumerable<Bank> GetBanks()
        {
            return _bankRepository.GetBanks();
        }

        public Bank GetBank(long id)
        {
            return _bankRepository.GetBank(id);
        }

        public Bank AddBank(Bank bank)
        {
            return _bankRepository.AddBank(bank);
        }

        public Bank UpdateBank(long id, Bank bank)
        {
            return _bankRepository.UpdateBank(id, bank);
        }

        public bool DeleteBank(long id)
        {
            return _bankRepository.DeleteBank(id);
        }
    }
}
