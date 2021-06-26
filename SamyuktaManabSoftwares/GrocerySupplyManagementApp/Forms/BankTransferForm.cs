using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class BankTransferForm : Form
    {
        private readonly IBankDetailService _bankDetailService;
        private List<BankDetail> _bankDetails = new List<BankDetail>();
        public BankTransferForm(IBankDetailService bankDetailService)
        {
            InitializeComponent();

            _bankDetailService = bankDetailService;
        }

        private void BankTransferForm_Load(object sender, EventArgs e)
        {
            LoadBankDetails();
        }

        private void LoadBankDetails()
        {
            _bankDetails = _bankDetailService.GetBankDetails().ToList();
            _bankDetails.OrderBy(x => x.Name).ToList().ForEach(x =>
            {
                ComboBank.Items.Add(x.Name);
            });
        }

        private void ComboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedBank = ComboBank.Text;
            if(!string.IsNullOrWhiteSpace(selectedBank))
            {
                var accountNo = _bankDetails.Where(x => x.Name == selectedBank).Select(x => x.AccountNo).FirstOrDefault();
                TxtAccountNo.Text = accountNo;
            }
        }
    }
}
