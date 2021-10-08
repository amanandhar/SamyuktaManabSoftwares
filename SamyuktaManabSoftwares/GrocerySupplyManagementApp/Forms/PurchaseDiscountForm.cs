using GrocerySupplyManagementApp.Forms.Interfaces;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PurchaseDiscountForm : Form
    {
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

        private void PurchaseDiscountForm_Load(object sender, System.EventArgs e)
        {
            TxtBoxBillNo.Text = _billNo;
            TxtBoxBillAmount.Text = _billAmount.ToString();
            TxtBoxDiscountAmount.Focus();
        }

        private void BtnClear_Click(object sender, System.EventArgs e)
        {
            TxtBoxDiscountAmount.Clear();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            var discountAmount = Convert.ToDecimal(TxtBoxDiscountAmount.Text.Trim());
            _purchaseDiscountForm.PopulatePurchaseDiscount(_supplierId, _billNo, discountAmount);
            Close();
        }
    }
}
