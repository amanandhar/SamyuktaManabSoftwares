using GrocerySupplyManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Services
{
    public class PosTransactionService : IPosTransactionService
    {
        public PosTransaction AddPosTransaction(PosTransaction posTransaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSupplierTransaction(long posTransactionId)
        {
            throw new NotImplementedException();
        }

        public PosTransaction GetPosTransaction(string posTransactionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PosTransaction> GetPosTransactions()
        {
            throw new NotImplementedException();
        }

        public PosTransaction UpdatePosTransaction(string posTransactionId, PosTransaction posTransaction)
        {
            throw new NotImplementedException();
        }
    }
}
