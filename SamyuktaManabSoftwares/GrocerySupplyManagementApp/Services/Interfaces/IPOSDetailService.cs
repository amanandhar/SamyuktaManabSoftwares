using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.ViewModels;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services.Interfaces
{
    public interface IPOSDetailService
    {
        #region Add Operation
        IEnumerable<POSDetail> GetPOSDetails();
        POSDetail GetPOSDetail(long id);
        POSDetailView GetPOSDetailView(string invoiceNo);
        #endregion

        #region Add Operation
        POSDetail AddPOSDetail(POSDetail posDetail);
        #endregion

        #region Update Operation
        POSDetail UpdatePOSDetail(long id, POSDetail posDetail);
        #endregion

        #region Add Operation
        bool DeletePOSDetail(long id);
        #endregion
    }
}
