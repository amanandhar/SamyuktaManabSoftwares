using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class EmployeeListForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IEmployeeService _employeeService;
        public IEmployeeListForm _employeeListForm;

        #region Constructor
        public EmployeeListForm(IEmployeeService employeeService, IEmployeeListForm employeeListForm)
        {
            InitializeComponent();

            _employeeService = employeeService;
            _employeeListForm = employeeListForm;
        }
        #endregion

        #region Form Load Event
        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }
        #endregion

        #region Data Grid Event
        private void DataGridEmployeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }
            else if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                long id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _employeeListForm.PopulateEmployee(id);
                Close();
            }
            else if (e.RowIndex > -1 && e.ColumnIndex > -1 && DataGridEmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var selectedRow = DataGridEmployeeList.CurrentRow;
                long id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _employeeListForm.PopulateEmployee(id);
                Close();
            }
        }

        private void DataGridEmployeeList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridEmployeeList.Columns["Id"].Visible = false;
            DataGridEmployeeList.Columns["EndOfDay"].Visible = false;
            DataGridEmployeeList.Columns["Counter"].Visible = false;
            DataGridEmployeeList.Columns["TempAddress"].Visible = false;
            DataGridEmployeeList.Columns["PermAddress"].Visible = false;
            DataGridEmployeeList.Columns["ContactNo"].Visible = false;
            DataGridEmployeeList.Columns["Email"].Visible = false;
            DataGridEmployeeList.Columns["CitizenshipNo"].Visible = false;
            DataGridEmployeeList.Columns["Education"].Visible = false;
            DataGridEmployeeList.Columns["DateOfBirth"].Visible = false;
            DataGridEmployeeList.Columns["Age"].Visible = false;
            DataGridEmployeeList.Columns["BloodGroup"].Visible = false;
            DataGridEmployeeList.Columns["FatherName"].Visible = false;
            DataGridEmployeeList.Columns["MotherName"].Visible = false;
            DataGridEmployeeList.Columns["Gender"].Visible = false;
            DataGridEmployeeList.Columns["MaritalStatus"].Visible = false;
            DataGridEmployeeList.Columns["SpouseName"].Visible = false;
            DataGridEmployeeList.Columns["Post"].Visible = false;
            DataGridEmployeeList.Columns["PostStatus"].Visible = false;
            DataGridEmployeeList.Columns["AppointedDate"].Visible = false;
            DataGridEmployeeList.Columns["ResignedDate"].Visible = false;
            DataGridEmployeeList.Columns["ImagePath"].Visible = false;
            DataGridEmployeeList.Columns["AddedBy"].Visible = false;
            DataGridEmployeeList.Columns["AddedDate"].Visible = false;
            DataGridEmployeeList.Columns["UpdatedBy"].Visible = false;
            DataGridEmployeeList.Columns["UpdatedDate"].Visible = false;

            DataGridEmployeeList.Columns["EmployeeId"].HeaderText = "Employee Id";
            DataGridEmployeeList.Columns["EmployeeId"].Width = 150;
            DataGridEmployeeList.Columns["EmployeeId"].DisplayIndex = 0;

            DataGridEmployeeList.Columns["Name"].HeaderText = "Name";
            DataGridEmployeeList.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridEmployeeList.Columns["Name"].DisplayIndex = 1;

            foreach (DataGridViewRow row in DataGridEmployeeList.Rows)
            {
                DataGridEmployeeList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridEmployeeList.RowHeadersWidth = 50;
                DataGridEmployeeList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadEmployees()
        {
            var employees = _employeeService.GetEmployees();

            var bindingList = new BindingList<Employee>(employees.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridEmployeeList.DataSource = source;
        }
        #endregion
    }
}
