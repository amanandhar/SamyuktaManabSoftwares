using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IPOSDetailRepository
    {
        POSDetailView GetPOSDetailView(string invoiceNo);

        POSDetail AddPOSDetail(POSDetail posDetail);

        bool DeletePOSDetail(string invoiceNo);
    }
}
