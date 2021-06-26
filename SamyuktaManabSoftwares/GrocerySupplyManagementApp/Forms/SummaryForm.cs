using GrocerySupplyManagementApp.Services;
using System;


using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SummaryForm : Form
    {
        private readonly ITransactionService _transactionService;
        private readonly IFiscalYearDetailService _fiscalYearDetailService;

        public SummaryForm(ITransactionService transactionService, IFiscalYearDetailService fiscalYearDetailService)
        {
            InitializeComponent();

            _transactionService = transactionService;
            _fiscalYearDetailService = fiscalYearDetailService;
        }

        private void BtnDailyTransactions_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_transactionService, _fiscalYearDetailService);
            transactionForm.Show();
        }
    }
}
