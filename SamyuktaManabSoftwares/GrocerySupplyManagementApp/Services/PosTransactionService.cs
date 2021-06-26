using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories;
using System;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class PosTransactionService : IPosTransactionService
    {
        private readonly IPosTransactionRepository _posTransactionRepository;

        public PosTransactionService(IPosTransactionRepository posTransactionRepository)
        {
            _posTransactionRepository = posTransactionRepository;
        }

        public IEnumerable<PosTransaction> GetPosTransactions()
        {
            return _posTransactionRepository.GetPosTransactions();
        }

        public PosTransaction GetPosTransaction(long posTransactionId)
        {
            return _posTransactionRepository.GetPosTransaction(posTransactionId);
        }

        public PosTransaction AddPosTransaction(PosTransaction posTransaction)
        {
            return _posTransactionRepository.AddPosTransaction(posTransaction);
        }
        public PosTransaction UpdatePosTransaction(long posTransactionId, PosTransaction posTransaction)
        {
            return _posTransactionRepository.UpdatePosTransaction(posTransactionId, posTransaction);
        }

        public bool DeleteSupplierTransaction(long posTransactionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PosTransactionGrid> GetPosTransactionGrid(string invoiceNo)
        {
            return _posTransactionRepository.GetPosTransactionGrid(invoiceNo);
        }
    }
}
