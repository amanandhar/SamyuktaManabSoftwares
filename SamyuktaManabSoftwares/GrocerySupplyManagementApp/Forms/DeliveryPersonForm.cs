using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DeliveryPersonForm : Form, IEmployeeListForm
    {
        private readonly IUserTransactionService _userTransactionService;
        private readonly IEmployeeService _employeeService;

        #region Constructor
        public DeliveryPersonForm(IUserTransactionService userTransactionService, IEmployeeService employeeService)
        {
            InitializeComponent();

            _userTransactionService = userTransactionService;
            _employeeService = employeeService;
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            DeliveryPersonListForm deliveryPersonListForm = new DeliveryPersonListForm(_employeeService, this);
            deliveryPersonListForm.ShowDialog();
        }
        #endregion

        #region Data Grid Event
        private void DataGridDeliveryPersonList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridDeliveryPersonList.Columns["Id"].Visible = false;
            DataGridDeliveryPersonList.Columns["BillNo"].Visible = false;
            DataGridDeliveryPersonList.Columns["MemberId"].Visible = false;
            DataGridDeliveryPersonList.Columns["SupplierId"].Visible = false;
            DataGridDeliveryPersonList.Columns["Action"].Visible = false;
            DataGridDeliveryPersonList.Columns["ActionType"].Visible = false;
            DataGridDeliveryPersonList.Columns["Bank"].Visible = false;
            DataGridDeliveryPersonList.Columns["IncomeExpense"].Visible = false;
            DataGridDeliveryPersonList.Columns["SubTotal"].Visible = false;
            DataGridDeliveryPersonList.Columns["DiscountPercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["Discount"].Visible = false;
            DataGridDeliveryPersonList.Columns["Vat"].Visible = false;
            DataGridDeliveryPersonList.Columns["VatPercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["DeliveryChargePercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["DueAmount"].Visible = false;
            DataGridDeliveryPersonList.Columns["ReceivedAmount"].Visible = false;
            DataGridDeliveryPersonList.Columns["AddedDate"].Visible = false;
            DataGridDeliveryPersonList.Columns["UpdatedDate"].Visible = false;

            DataGridDeliveryPersonList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridDeliveryPersonList.Columns["EndOfDay"].Width = 90;
            DataGridDeliveryPersonList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridDeliveryPersonList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridDeliveryPersonList.Columns["InvoiceNo"].Width = 90;
            DataGridDeliveryPersonList.Columns["InvoiceNo"].DisplayIndex = 1;

            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].HeaderText = "Employee Id";
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].Width = 90;
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].DisplayIndex = 0;

            DataGridDeliveryPersonList.Columns["DeliveryCharge"].HeaderText = "Delivery Charge";
            DataGridDeliveryPersonList.Columns["DeliveryCharge"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridDeliveryPersonList.Columns["DeliveryCharge"].DisplayIndex = 4;
            DataGridDeliveryPersonList.Columns["DeliveryCharge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridDeliveryPersonList.Rows)
            {
                DataGridDeliveryPersonList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridDeliveryPersonList.RowHeadersWidth = 50;
                DataGridDeliveryPersonList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        public void PopulateEmployee(long id)
        {
            var employee = _employeeService.GetEmployee(id);
            TxtName.Text = employee.Name;
            DeliveryPersonFilter deliveryPersonFilter = new DeliveryPersonFilter()
            {
                DateFrom = MaskEndOfDayFrom.Text,
                DateTo = MaskEndOfDayTo.Text,
                EmployeeId = employee.EmployeeId
            };
            
            var userTransations = _userTransactionService.GetUserTransactions(deliveryPersonFilter);

            TxtAmount.Text = userTransations.ToList().Sum(x => x.DeliveryCharge).ToString();

            var bindingList = new BindingList<UserTransaction>(userTransations.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridDeliveryPersonList.DataSource = source;
        }
        #endregion
    }
}
