using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class BankDetailService : IBankDetailService
    {
        private readonly IBankDetailRepository _bankDetailRepository;

        public BankDetailService(IBankDetailRepository bankDetailRepository)
        {
            _bankDetailRepository = bankDetailRepository;
        }

        public IEnumerable<Bank> GetBankDetails()
        {
            return _bankDetailRepository.GetBankDetails();
        }

        public Bank GetBankDetail(long bankId)
        {
            return _bankDetailRepository.GetBankDetail(bankId);
        }

        public Bank AddBankDetail(Bank bankDetail)
        {
            return _bankDetailRepository.AddBankDetail(bankDetail);
        }

        public Bank UpdateBankDetail(long bankId, Bank bankDetail)
        {
            return _bankDetailRepository.UpdateBankDetail(bankId, bankDetail);
        }

        public bool DeleteBankDetail(long bankId)
        {
            return _bankDetailRepository.DeleteBankDetail(bankId);
        }
    }
}
