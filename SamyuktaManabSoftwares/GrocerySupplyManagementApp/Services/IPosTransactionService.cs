using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Services
{
    public interface IPosTransactionService
    {
        IEnumerable<PosTransaction> GetPosTransactions();
        PosTransaction GetPosTransaction(string posTransactionId);
        PosTransaction AddPosTransaction(PosTransaction posTransaction);
        PosTransaction UpdatePosTransaction(string posTransactionId, PosTransaction posTransaction);
        bool DeleteSupplierTransaction(long posTransactionId);
    }
}
