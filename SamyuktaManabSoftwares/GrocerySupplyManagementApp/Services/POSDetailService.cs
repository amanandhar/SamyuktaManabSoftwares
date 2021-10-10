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

        public IEnumerable<POSDetail> GetPOSDetails()
        {
            return _posDetailRepository.GetPOSDetails();
        }

        public POSDetail GetPOSDetail(long id)
        {
            return _posDetailRepository.GetPOSDetail(id);
        }

        public POSDetailView GetPOSDetailView(string invoiceNo)
        {
            return _posDetailRepository.GetPOSDetailView(invoiceNo);
        }

        public POSDetail AddPOSDetail(POSDetail posDetail)
        {
            return _posDetailRepository.AddPOSDetail(posDetail);
        }

        public POSDetail UpdatePOSDetail(long id, POSDetail posDetail)
        {
            return _posDetailRepository.UpdatePOSDetail(id, posDetail);
        }

        public bool DeletePOSDetail(long id)
        {
            return _posDetailRepository.DeletePOSDetail(id);
        }

        public bool DeletePOSDetail(string invoiceNo)
        {
            return _posDetailRepository.DeletePOSDetail(invoiceNo);
        }
    }
}
