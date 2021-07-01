using GrocerySupplyManagementApp.Forms;
using GrocerySupplyManagementApp.Repositories;
using GrocerySupplyManagementApp.Services;
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
                container.Resolve<ISupplierTransactionService>(),
                container.Resolve<IFiscalYearDetailService>(),
                container.Resolve<ITaxDetailService>(),
                container.Resolve<IPosTransactionService>(),
                container.Resolve<IPosSoldItemService>(),
                container.Resolve<ITransactionService>(),
                container.Resolve<IPreparedItemService>(),
                container.Resolve<IBankDetailService>(),
                container.Resolve<IBankTransactionService>()
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
            container.RegisterType<ISupplierTransactionService, SupplierTransactionService>();
            container.RegisterType<IFiscalYearDetailService, FiscalYearDetailService>();
            container.RegisterType<ITaxDetailService, TaxDetailService>();
            container.RegisterType<IPosTransactionService, PosTransactionService>();
            container.RegisterType<IPosSoldItemService, PosSoldItemService>();
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<IPreparedItemService, PreparedItemService>();
            container.RegisterType<IBankDetailService, BankDetailService>();
            container.RegisterType<IBankTransactionService, BankTransactionService>();

            container.RegisterType<IMemberRepository, MSSqlMemberRepository>();
            container.RegisterType<ISupplierRepository, MSSqlSupplierRepository>();
            container.RegisterType<IItemRepository, MSSqlItemRepository>();
            container.RegisterType<IItemPurchaseRepository, MSSqlItemPurchaseRepository>();
            container.RegisterType<ISupplierTransactionRepository, MSSqlSupplierTransactionRepository>();
            container.RegisterType<IFiscalYearDetailRepository, MSSqlFiscalYearDetailRepository>();
            container.RegisterType<ITaxDetailRepository, MSSqlTaxDetailRepository>();
            container.RegisterType<IPosTransactionRepository, MSSqlPosTransactionRepository>();
            container.RegisterType<IPosSoldItemRepository, MSSqlPosSoldItemRepository>();
            container.RegisterType<ITransactionRepository, MSSqlTransactionRepository>();
            container.RegisterType<IPreparedItemRepository, MSSqlPreparedItemRepository>();
            container.RegisterType<IBankDetailRepository, MSSqlBankDetailRepository>();
            container.RegisterType<IBankTransactionRepository, MSSqlBankTransactionRepository>();

            return container;
        }
    }
}
