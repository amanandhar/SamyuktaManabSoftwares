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
                container.Resolve<ISupplierTransactionService>()
                ));
            //Application.Run(new SalesReportForm());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<ISupplierTransactionService, SupplierTransactionService>();

            container.RegisterType<IMemberRepository, MSSqlMemberRepository>();
            container.RegisterType<ISupplierRepository, MSSqlSupplierRepository>();
            container.RegisterType<IItemRepository, MSSqlItemRepository>();
            container.RegisterType<ISupplierTransactionRepository, MSSqlSupplierTransactionRepository>();

            return container;
        }
    }
}
