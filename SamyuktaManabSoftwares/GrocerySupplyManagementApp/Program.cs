using GrocerySupplyManagementApp.Forms;
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
                container.Resolve<IMemberService>(),
                container.Resolve<ISupplierService>(),
                container.Resolve<IItemService>(),
                container.Resolve<IItemTransactionService>(),
                container.Resolve<IFiscalYearService>(),
                container.Resolve<ITaxService>(),
                container.Resolve<IUserTransactionService>(),
                container.Resolve<ISoldItemService>(),
                container.Resolve<IDailyTransactionService>(),
                container.Resolve<ICodedItemService>(),
                container.Resolve<IBankService>(),
                container.Resolve<IBankTransactionService>(),
                container.Resolve<IIncomeDetailService>()
                ));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IItemTransactionService, ItemTransactionService>();
            container.RegisterType<IFiscalYearService, FiscalYearService>();
            container.RegisterType<ITaxService, TaxService>();
            container.RegisterType<IUserTransactionService, UserTransactionService>();
            container.RegisterType<ISoldItemService, SoldItemService>();
            container.RegisterType<IDailyTransactionService, DailyTransactionService>();
            container.RegisterType<ICodedItemService, CodedItemService>();
            container.RegisterType<IBankService, BankService>();
            container.RegisterType<IBankTransactionService, BankTransactionService>();
            container.RegisterType<IIncomeDetailService, IncomeDetailService>();

            container.RegisterType<IMemberRepository, MSSqlMemberRepository>();
            container.RegisterType<ISupplierRepository, MSSqlSupplierRepository>();
            container.RegisterType<IItemRepository, MSSqlItemRepository>();
            container.RegisterType<IPurchasedItemRepository, MSSqlPurchasedItemRepository>();
            container.RegisterType<IFiscalYearRepository, MSSqlFiscalYearRepository>();
            container.RegisterType<ITaxRepository, MSSqlTaxRepository>();
            container.RegisterType<IUserTransactionRepository, MSSqlUserTransactionRepository>();
            container.RegisterType<ISoldItemRepository, MSSqlSoldItemRepository>();
            container.RegisterType<IDailyTransactionRepository, MSSqlDailyTransactionRepository>();
            container.RegisterType<ICodedItemRepository, MSSqlCodedItemRepository>();
            container.RegisterType<IBankRepository, MSSqlBankRepository>();
            container.RegisterType<IBankTransactionRepository, MSSqlBankTransactionRepository>();
            container.RegisterType<IIncomeDetailRepository, MSSqlIncomeDetailRepository>();

            return container;
        }
    }
}
