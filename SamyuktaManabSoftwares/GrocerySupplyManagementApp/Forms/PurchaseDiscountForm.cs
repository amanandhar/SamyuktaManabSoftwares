using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PurchaseDiscountForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly string _supplierId;
        private readonly string _billNo;
        private readonly decimal _billAmount;
        private readonly IPurchaseDiscountForm _purchaseDiscountForm;

        public PurchaseDiscountForm(string supplierId, string billNo, decimal billAmount, IPurchaseDiscountForm purchaseDiscountForm)
        {
            InitializeComponent();

            _supplierId = supplierId;
            _billNo = billNo;
            _billAmount = billAmount;
            _purchaseDiscountForm = purchaseDiscountForm;
        }

        private void PurchaseDiscountForm_Load(object sender, EventArgs e)
        {
            TxtBoxBillNo.Text = _billNo;
            TxtBoxBillAmount.Text = _billAmount.ToString();
            TxtBoxDiscountAmount.Focus();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtBoxDiscountAmount.Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var discountAmount = Convert.ToDecimal(TxtBoxDiscountAmount.Text.Trim());
            _purchaseDiscountForm.PopulatePurchaseDiscount(_supplierId, _billNo, discountAmount);
            Close();
        }
    }
}
