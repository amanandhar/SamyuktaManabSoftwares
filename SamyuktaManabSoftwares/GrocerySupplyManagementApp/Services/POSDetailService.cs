using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class POSDetailService : IPOSDetailService
    {
        private readonly IPOSDetailRepository _posDetailRepository;

        public POSDetailService(IPOSDetailRepository posDetailRepository)
        {
            _posDetailRepository = posDetailRepository;
        }

        public IEnumerable<POSDetail> GetPOSDetails(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter)
        {
            return _posDetailRepository.GetPOSDetails(deliveryPersonTransactionFilter);
        }

        public POSDetailView GetPOSDetailView(string invoiceNo)
        {
            return _posDetailRepository.GetPOSDetailView(invoiceNo);
        }

        public POSDetail AddPOSDetail(POSDetail posDetail)
        {
            return _posDetailRepository.AddPOSDetail(posDetail);
        }

        public bool DeletePOSDetail(string invoiceNo)
        {
            return _posDetailRepository.DeletePOSDetail(invoiceNo);
        }
    }
}
