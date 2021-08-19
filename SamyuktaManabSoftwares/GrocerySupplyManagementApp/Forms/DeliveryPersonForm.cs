﻿using GrocerySupplyManagementApp.DTOs;
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
        private readonly IFiscalYearService _fiscalYearService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IEmployeeService _employeeService;
        private string _selectedEmployeeId;
        private readonly string _endOfDay;

        #region Constructor
        public DeliveryPersonForm(IFiscalYearService fiscalYearService, IUserTransactionService userTransactionService,
            IEmployeeService employeeService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _userTransactionService = userTransactionService;
            _employeeService = employeeService;

            _endOfDay = _fiscalYearService.GetFiscalYear().StartingDate;
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
        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            DeliveryPersonListForm deliveryPersonListForm = new DeliveryPersonListForm(_employeeService, this);
            deliveryPersonListForm.ShowDialog();
        }

        private void BtnShowTransaction_Click(object sender, System.EventArgs e)
        {
            var dateFrom = MaskEndOfDayFrom.Text;
            var dateTo = MaskEndOfDayTo.Text;
            var employeeId = _selectedEmployeeId;
            var deliveryPersonFilter = new DeliveryPersonFilter();
            if (!string.IsNullOrWhiteSpace(dateFrom.Replace("-", string.Empty).Trim()))
            {
                deliveryPersonFilter.DateFrom = dateFrom.Trim();
            }

            if (!string.IsNullOrWhiteSpace(dateTo.Replace("-", string.Empty).Trim()))
            {
                deliveryPersonFilter.DateTo = dateTo.Trim();
            }

            deliveryPersonFilter.EmployeeId = employeeId;
            LoadDeliveryTransactions(deliveryPersonFilter);
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
            DataGridDeliveryPersonList.Columns["EndOfDay"].Width = 100;
            DataGridDeliveryPersonList.Columns["EndOfDay"].DisplayIndex = 0;

            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].HeaderText = "Employee Id";
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].Width = 100;
            DataGridDeliveryPersonList.Columns["DeliveryPersonId"].DisplayIndex = 1;

            DataGridDeliveryPersonList.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DataGridDeliveryPersonList.Columns["InvoiceNo"].Width = 100;
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

        private void LoadDeliveryTransactions(DeliveryPersonFilter deliveryPersonFilter)
        {
            var userTransations = _userTransactionService.GetUserTransactions(deliveryPersonFilter);

            TxtAmount.Text = userTransations.ToList().Sum(x => x.DeliveryCharge).ToString();

            var bindingList = new BindingList<UserTransaction>(userTransations.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridDeliveryPersonList.DataSource = source;
        }
        #endregion

        
    }
}