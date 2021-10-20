using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPOSDetailService
    {
        POSDetailView GetPOSDetailView(string invoiceNo);

        POSDetail AddPOSDetail(POSDetail posDetail);

        bool DeletePOSDetail(string invoiceNo);
    }
}
