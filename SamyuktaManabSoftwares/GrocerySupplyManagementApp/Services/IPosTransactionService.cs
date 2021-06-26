using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public interface IPosTransactionService
    {
        IEnumerable<PosTransaction> GetPosTransactions();
        PosTransaction GetPosTransaction(long posTransactionId);
        PosTransaction AddPosTransaction(PosTransaction posTransaction);
        PosTransaction UpdatePosTransaction(long posTransactionId, PosTransaction posTransaction);
        bool DeleteSupplierTransaction(long posTransactionId);
        IEnumerable<PosTransactionGrid> GetPosTransactionGrid(string invoiceNo);
    }
}
