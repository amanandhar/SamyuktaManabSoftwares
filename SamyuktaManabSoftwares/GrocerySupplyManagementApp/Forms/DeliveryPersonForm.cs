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
        private readonly IEmployeeService _employeeService;
        private readonly IPOSDetailService _posDetailService;

        private string _selectedEmployeeId;
        private readonly Setting _setting;
        private readonly string _endOfDay;

        #region Constructor
        public DeliveryPersonForm(ISettingService settingService,
            IEmployeeService employeeService, IPOSDetailService posDetailService)
        {
            InitializeComponent();

            _settingService = settingService;
            _employeeService = employeeService;
            _posDetailService = posDetailService;

            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }
        #endregion

        #region Form Load Event
        private void DeliveryPersonForm_Load(object sender, System.EventArgs e)
        {
            MaskDtEODFrom.Text = _endOfDay;
            MaskDtEODTo.Text = _endOfDay;
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
            var deliveryPersonTransactionFilter = new DeliveryPersonTransactionFilter
            {
                DateFrom = UtilityService.GetDate(MaskDtEODFrom.Text.Trim()),
                DateTo = UtilityService.GetDate(MaskDtEODTo.Text.Trim()),
                EmployeeId = employeeId
            };

            LoadDeliveryTransactions(deliveryPersonTransactionFilter);
        }
        #endregion

        #region Data Grid Event
        private void DataGridDeliveryPersonList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridDeliveryPersonList.Columns["Id"].Visible = false;
            DataGridDeliveryPersonList.Columns["UserTransactionId"].Visible = false;
            DataGridDeliveryPersonList.Columns["SubTotal"].Visible = false;
            DataGridDeliveryPersonList.Columns["DiscountPercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["Discount"].Visible = false;
            DataGridDeliveryPersonList.Columns["VatPercent"].Visible = false;
            DataGridDeliveryPersonList.Columns["Vat"].Visible = false;
            DataGridDeliveryPersonList.Columns["DeliveryChargePercent"].Visible = false;

            DataGridDeliveryPersonList.Columns["EndOfDay"].HeaderText = "Date";
            DataGridDeliveryPersonList.Columns["EndOfDay"].Width = 120;
            DataGridDeliveryPersonList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].HeaderText = "Employee Id";
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].Width = 180;
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].DisplayIndex = 1;

            DataGridDeliveryPersonList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridDeliveryPersonList.Columns["InvoiceNo"].Width = 150;
            DataGridDeliveryPersonList.Columns["InvoiceNo"].DisplayIndex = 2;

            DataGridDeliveryPersonList.Columns["DeliveryCharge"].HeaderText = "Delivery Charge";
            DataGridDeliveryPersonList.Columns["DeliveryCharge"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridDeliveryPersonList.Columns["DeliveryCharge"].DisplayIndex = 3;
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
            _selectedEmployeeId = employee.EmployeeId;
        }

        private void LoadDeliveryTransactions(DeliveryPersonTransactionFilter deliveryPersonTransactionFilter)
        {
            var posDetails = _posDetailService.GetPOSDetails(deliveryPersonTransactionFilter);

            TxtAmount.Text = posDetails.ToList().Sum(x => x.DeliveryCharge).ToString();

            var bindingList = new BindingList<POSDetail>(posDetails.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridDeliveryPersonList.DataSource = source;
        }

        #endregion
    }
}
