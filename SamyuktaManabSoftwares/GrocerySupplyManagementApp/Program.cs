﻿using GrocerySupplyManagementApp.Forms;
using GrocerySupplyManagementApp.Repositories;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Services;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace GrocerySupplyManagementApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardForm(
                container.Resolve<IFiscalYearService>(),
                container.Resolve<ITaxService>(),
                container.Resolve<IBankService>(),
                container.Resolve<IBankTransactionService>(),
                container.Resolve<IItemService>(),
                container.Resolve<IPricedItemService>(),
                container.Resolve<IMemberService>(),
                container.Resolve<ISupplierService>(),
                container.Resolve<IPurchasedItemService>(),
                container.Resolve<ISoldItemService>(),
                container.Resolve<IUserTransactionService>(),
                container.Resolve<IStockService>(),
                container.Resolve<IEndOfDayService>()
                ));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IFiscalYearService, FiscalYearService>();
            container.RegisterType<ITaxService, TaxService>();
            container.RegisterType<IBankService, BankService>();
            container.RegisterType<IBankTransactionService, BankTransactionService>();
            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IPricedItemService, PricedItemService>();
            container.RegisterType<IPurchasedItemService, PurchasedItemService>();
            container.RegisterType<ISoldItemService, SoldItemService>();
            container.RegisterType<IUserTransactionService, UserTransactionService>();
            container.RegisterType<IStockService, StockService>();
            container.RegisterType<IEndOfDayService, EndOfDayService>();

            container.RegisterType<IFiscalYearRepository, MSSqlFiscalYearRepository>();
            container.RegisterType<ITaxRepository, MSSqlTaxRepository>();
            container.RegisterType<IBankRepository, MSSqlBankRepository>();
            container.RegisterType<IBankTransactionRepository, MSSqlBankTransactionRepository>();
            container.RegisterType<IItemRepository, MSSqlItemRepository>();
            container.RegisterType<IPricedItemRepository, MSSqlPricedItemRepository>();
            container.RegisterType<IMemberRepository, MSSqlMemberRepository>();
            container.RegisterType<ISupplierRepository, MSSqlSupplierRepository>();
            container.RegisterType<IPurchasedItemRepository, MSSqlPurchasedItemRepository>();
            container.RegisterType<ISoldItemRepository, MSSqlSoldItemRepository>();
            container.RegisterType<IUserTransactionRepository, MSSqlUserTransactionRepository>();
            container.RegisterType<IStockRepository, MSSqlStockRepository>();
            container.RegisterType<IEndOfDayRepository, MSSqlEndOfDayRepository>();

            return container;
        }
    }
}
