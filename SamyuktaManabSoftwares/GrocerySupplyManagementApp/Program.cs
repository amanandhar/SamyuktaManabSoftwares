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

            using (var loginForm = new LoginForm(container.Resolve<IUserService>()))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    string username = loginForm.Username;
                    Application.Run(new DashboardForm(username, 
                        container.Resolve<ISettingService>(),
                        container.Resolve<ICompanyInfoService>(),
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
                        container.Resolve<IEndOfDayService>(),
                        container.Resolve<IEmployeeService>(),
                        container.Resolve<IReportService>(),
                        container.Resolve<IUserService>(),
                        container.Resolve<IItemCategoryService>(),
                        container.Resolve<IShareMemberService>(),
                        container.Resolve<IStockAdjustmentService>(),
                        container.Resolve<IPOSDetailService>()
                        ));
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ISettingService, SettingService>();
            container.RegisterType<ICompanyInfoService, CompanyInfoService>();
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
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IItemCategoryService, ItemCategoryService>();
            container.RegisterType<IShareMemberService, ShareMemberService>();
            container.RegisterType<IStockAdjustmentService, StockAdjustmentService>();
            container.RegisterType<IPOSDetailService, POSDetailService>();

            container.RegisterType<ISettingRepository, MSSqlSettingRepository>();
            container.RegisterType<ICompanyInfoRepository, MSSqlCompanyInfoRepository>();
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
            container.RegisterType<IEmployeeRepository, MSSqlEmployeeRepository>();
            container.RegisterType<IReportRepository, MSSqlReportRepository>();
            container.RegisterType<IUserRepository, MSSqlUserRepository>();
            container.RegisterType<IItemCategoryRepository, MSSqlItemCategoryRepository>();
            container.RegisterType<IShareMemberRepository, MSSqlShareMemberRepository>();
            container.RegisterType<IStockAdjustmentRepository, MSSqlStockAdjustmentRepository>();
            container.RegisterType<IPOSDetailRepository, MSSqlPOSDetailRepository>();

            return container;
        }
    }
}
