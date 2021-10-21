using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySupplyManagementApp.Services
{
    public class UserTransactionService : IUserTransactionService
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IUserTransactionRepository _userTransactionRepository;
        private readonly ISettingRepository _settingRepository;

        public UserTransactionService(IUserTransactionRepository userTransactionRepository, ISettingRepository settingRepository)
        {
            _userTransactionRepository = userTransactionRepository;
            _settingRepository = settingRepository;
        }

        public IEnumerable<UserTransaction> GetUserTransactions(UserTransactionFilter userTransactionFilter)
        {
            return _userTransactionRepository.GetUserTransactions(userTransactionFilter);
        }

        public IEnumerable<UserTransaction> GetDeliveryPersonTransactions(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter)
        {
            return _userTransactionRepository.GetDeliveryPersonTransactions(deliveryPersonTransactionFilter);
        }

        public IEnumerable<MemberTransactionView> GetMemberTransactions(MemberTransactionFilter memberTransactionFilter)
        {
            return _userTransactionRepository.GetMemberTransactions(memberTransactionFilter);
        }

        public IEnumerable<SupplierTransactionView> GetSupplierTransactions(SupplierTransactionFilter supplierFilter)
        {
            return _userTransactionRepository.GetSupplierTransactions(supplierFilter);
        }

        public UserTransaction GetLastUserTransaction(string addedBy, string option)
        {
            return _userTransactionRepository.GetLastUserTransaction(addedBy, option);
        }

        public string GetInvoiceNo()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _userTransactionRepository.GetLastInvoiceNo();
                if (string.IsNullOrWhiteSpace(lastInvoiceNo))
                {
                    var setting = _settingRepository.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
                    invoiceNo = setting.StartingInvoiceNo;
                }
                else
                {
                    var formats = lastInvoiceNo.Split('-');
                    var prefix = formats[0];
                    var year = formats[1];
                    var value = formats[2];
                    var trimmedValue = (Convert.ToInt64(value.TrimStart(new char[] { '0' })) + 1).ToString();

                    while (trimmedValue.Length < value.Length)
                    {
                        trimmedValue = "0" + trimmedValue;
                    }

                    invoiceNo = prefix + "-" + year + "-" + trimmedValue;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

            return invoiceNo;
        }

        public IEnumerable<string> GetInvoices()
        {
            return _userTransactionRepository.GetInvoices();
        }

        public IEnumerable<DailyTransactionView> GetDailyTransactions(DailyTransactionFilter dailyTransactionFilter)
        {
            return _userTransactionRepository.GetDailyTransactions(dailyTransactionFilter);
        }

        public IEnumerable<ShareMemberTransactionView> GetShareMemberTransactions(ShareMemberTransactionFilter shareMemberTransactionFilter)
        {
            return _userTransactionRepository.GetShareMemberTransactions(shareMemberTransactionFilter);
        }

        public IEnumerable<SalesReturnTransactionView> GetSalesReturnTransactions(SalesReturnTransactionFilter salesReturnTransactionFilter)
        {
            return _userTransactionRepository.GetSalesReturnTransactions(salesReturnTransactionFilter);
        }

        public UserTransaction AddUserTransaction(UserTransaction userTransaction)
        {
            return _userTransactionRepository.AddUserTransaction(userTransaction);
        }

        public bool DeleteUserTransaction(long id)
        {
            return _userTransactionRepository.DeleteUserTransaction(id);
        }

        public bool DeleteUserTransaction(string invoiceNo)
        {
            return _userTransactionRepository.DeleteUserTransaction(invoiceNo);
        }
    }
}
