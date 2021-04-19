using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, System.EventArgs e)
        {

        }

        private void BtnPurchase_Click(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.Show();
        }

        private void BtnAddNew_Click(object sender, System.EventArgs e)
        {
            
        }

        private void btnPurchase_Click_1(object sender, System.EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.Show();
        }
    }
}
