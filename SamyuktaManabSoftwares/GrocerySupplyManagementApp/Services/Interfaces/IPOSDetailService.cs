using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPOSDetailService
    {
        IEnumerable<POSDetail> GetPOSDetails(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter);

        POSDetailView GetPOSDetailView(string invoiceNo);

        POSDetail AddPOSDetail(POSDetail posDetail);

        bool DeletePOSDetail(string invoiceNo);
    }
}
