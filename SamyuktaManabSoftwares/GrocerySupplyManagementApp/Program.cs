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
                container.Resolve<IFiscalYearDetailService>(),
                container.Resolve<ITaxDetailService>(),
                container.Resolve<IUserTransactionService>(),
                container.Resolve<ISoldItemService>(),
                container.Resolve<IDailyTransactionService>(),
                container.Resolve<ICodedItemService>(),
                container.Resolve<IBankDetailService>(),
                container.Resolve<IBankTransactionService>(),
                container.Resolve<IIncomeDetailService>(),
                container.Resolve<IIncomeService>()
                ));
            //Application.Run(new SalesReportForm());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IItemTransactionService, ItemTransactionService>();
            container.RegisterType<IFiscalYearDetailService, FiscalYearDetailService>();
            container.RegisterType<ITaxDetailService, TaxDetailService>();
            container.RegisterType<IUserTransactionService, UserTransactionService>();
            container.RegisterType<ISoldItemService, SoldItemService>();
            container.RegisterType<IDailyTransactionService, DailyTransactionService>();
            container.RegisterType<ICodedItemService, CodedItemService>();
            container.RegisterType<IBankDetailService, BankDetailService>();
            container.RegisterType<IBankTransactionService, BankTransactionService>();
            container.RegisterType<IIncomeDetailService, IncomeDetailService>();
            container.RegisterType<IIncomeService, IncomeService>();

            container.RegisterType<IMemberRepository, MSSqlMemberRepository>();
            container.RegisterType<ISupplierRepository, MSSqlSupplierRepository>();
            container.RegisterType<IItemRepository, MSSqlItemRepository>();
            container.RegisterType<IPurchasedItemRepository, MSSqlPurchasedItemRepository>();
            container.RegisterType<IFiscalYearDetailRepository, MSSqlFiscalYearDetailRepository>();
            container.RegisterType<ITaxDetailRepository, MSSqlTaxDetailRepository>();
            container.RegisterType<IUserTransactionRepository, MSSqlUserTransactionRepository>();
            container.RegisterType<ISoldItemRepository, MSSqlSoldItemRepository>();
            container.RegisterType<IDailyTransactionRepository, MSSqlDailyTransactionRepository>();
            container.RegisterType<ICodedItemRepository, MSSqlCodedItemRepository>();
            container.RegisterType<IBankDetailRepository, MSSqlBankDetailRepository>();
            container.RegisterType<IBankTransactionRepository, MSSqlBankTransactionRepository>();
            container.RegisterType<IIncomeDetailRepository, MSSqlIncomeDetailRepository>();
            container.RegisterType<IIncomeRepository, MSSqlIncomeRepository>();

            return container;
        }
    }
}
