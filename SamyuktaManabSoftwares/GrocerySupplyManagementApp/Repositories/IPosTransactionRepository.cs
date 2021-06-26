using GrocerySupplyManagementApp.Entities;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Repositories
{
    public interface IPosTransactionRepository
    {
        IEnumerable<PosTransaction> GetPosTransactions();
        PosTransaction GetPosTransaction(long posTransactionId);
        PosTransaction AddPosTransaction(PosTransaction posTransaction);
        PosTransaction UpdatePosTransaction(long posITransactionId, PosTransaction posTransaction);
        bool DeletePosTransaction(long posTransactionId, PosTransaction posTransaction);
        IEnumerable<PosTransactionGrid> GetPosTransactionGrid(string invoiceNo);
    }
}
