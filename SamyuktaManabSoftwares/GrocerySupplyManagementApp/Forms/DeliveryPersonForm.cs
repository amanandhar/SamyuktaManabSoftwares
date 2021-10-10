using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DeliveryPersonForm : Form, IEmployeeListForm
    {
        private readonly ISettingService _settingService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IEmployeeService _employeeService;
        
        private string _selectedEmployeeId;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public DeliveryPersonForm(ISettingService settingService, IUserTransactionService userTransactionService,
            IEmployeeService employeeService)
        {
            InitializeComponent();

            _settingService = settingService;
            _userTransactionService = userTransactionService;
            _employeeService = employeeService;

            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void DeliveryPersonForm_Load(object sender, System.EventArgs e)
        {
            MaskEndOfDayFrom.Text = _endOfDay;
            MaskEndOfDayTo.Text = _endOfDay;
        }

        #endregion

        #region Button Click Event
        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            DeliveryPersonListForm deliveryPersonListForm = new DeliveryPersonListForm(_employeeService, this);
            deliveryPersonListForm.ShowDialog();
        }

        private void BtnShowTransaction_Click(object sender, System.EventArgs e)
        {
            var employeeId = _selectedEmployeeId;
            var deliveryPersonFilter = new DeliveryPersonFilter
            {
                DateFrom = UtilityService.GetDate(MaskEndOfDayFrom.Text),
                DateTo = UtilityService.GetDate(MaskEndOfDayTo.Text),
                EmployeeId = employeeId
            };
            LoadDeliveryTransactions(deliveryPersonFilter);
        }
        #endregion

        #region Data Grid Event
        private void DataGridDeliveryPersonList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridDeliveryPersonList.Columns["Id"].Visible = false;
            DataGridDeliveryPersonList.Columns["BillNo"].Visible = false;
            DataGridDeliveryPersonList.Columns["MemberId"].Visible = false;
            DataGridDeliveryPersonList.Columns["ShareMemberId"].Visible = false;
            DataGridDeliveryPersonList.Columns["SupplierId"].Visible = false;
            DataGridDeliveryPersonList.Columns["Action"].Visible = false;
            DataGridDeliveryPersonList.Columns["ActionType"].Visible = false;
            DataGridDeliveryPersonList.Columns["Bank"].Visible = false;
            DataGridDeliveryPersonList.Columns["Income"].Visible = false;
            DataGridDeliveryPersonList.Columns["Expense"].Visible = false;
            DataGridDeliveryPersonList.Columns["Narration"].Visible = false;
            DataGridDeliveryPersonList.Columns["SubTotal"].Visible = false;
            DataGridDeliveryPersonList.Columns["DiscountPercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["Discount"].Visible = false;
            DataGridDeliveryPersonList.Columns["Vat"].Visible = false;
            DataGridDeliveryPersonList.Columns["VatPercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["DeliveryChargePercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["DeliveryCharge"].Visible = false;
            DataGridDeliveryPersonList.Columns["DueAmount"].Visible = false;
            DataGridDeliveryPersonList.Columns["AddedDate"].Visible = false;
            DataGridDeliveryPersonList.Columns["UpdatedDate"].Visible = false;

            DataGridDeliveryPersonList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridDeliveryPersonList.Columns["EndOfDay"].Width = 100;
            DataGridDeliveryPersonList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].HeaderText = "Employee Id";
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].Width = 150;
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].DisplayIndex = 1;

            DataGridDeliveryPersonList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridDeliveryPersonList.Columns["InvoiceNo"].Width = 100;
            DataGridDeliveryPersonList.Columns["InvoiceNo"].DisplayIndex = 2;

            DataGridDeliveryPersonList.Columns["ReceivedAmount"].HeaderText = "Delivery Charge";
            DataGridDeliveryPersonList.Columns["ReceivedAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridDeliveryPersonList.Columns["ReceivedAmount"].DisplayIndex = 3;
            DataGridDeliveryPersonList.Columns["ReceivedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            _selectedEmployeeId = employee.EmployeeId;
        }

        private void LoadDeliveryTransactions(DeliveryPersonFilter deliveryPersonFilter)
        {
            var userTransations = _userTransactionService.GetUserTransactions(deliveryPersonFilter);

            TxtAmount.Text = userTransations.ToList().Sum(x => x.ReceivedAmount).ToString();

            var bindingList = new BindingList<UserTransaction>(userTransations.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridDeliveryPersonList.DataSource = source;
        }

        #endregion
    }
}
