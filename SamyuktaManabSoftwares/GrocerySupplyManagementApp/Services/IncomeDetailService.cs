﻿using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.Collections.Generic;

namespace GrocerySupplyManagementApp.Services
{
    public class IncomeDetailService : IIncomeDetailService
    {
        private readonly IIncomeDetailRepository _incomeDetailRepository;

        public IncomeDetailService(IIncomeDetailRepository incomeDetailRepository)
        {
            _incomeDetailRepository = incomeDetailRepository;
        }

        public IEnumerable<IncomeDetailView> GetIncomeDetails()
        {
            return _incomeDetailRepository.GetIncomeDetails();
        }
    }
}