using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IPOSDetailRepository
    {
        IEnumerable<POSDetail> GetPOSDetails(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter);

        POSDetailView GetPOSDetailView(string invoiceNo);

        POSDetail AddPOSDetail(POSDetail posDetail);

        bool DeletePOSDetail(string invoiceNo);
    }
}
