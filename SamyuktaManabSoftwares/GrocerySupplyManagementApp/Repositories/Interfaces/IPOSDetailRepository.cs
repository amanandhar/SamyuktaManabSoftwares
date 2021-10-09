using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories.Interfaces
{
    public interface IPOSDetailRepository
    {
        IEnumerable<POSDetail> GetPOSDetails();
        POSDetail GetPOSDetail(long id);
        POSDetailView GetPOSDetailView(string invoiceNo);

        POSDetail AddPOSDetail(POSDetail posDetail);

        POSDetail UpdatePOSDetail(long id, POSDetail posDetail);

        bool DeletePOSDetail(long id);
    }
}
