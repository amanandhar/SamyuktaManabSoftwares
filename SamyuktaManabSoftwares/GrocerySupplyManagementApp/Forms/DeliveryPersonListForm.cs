using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class DeliveryPersonListForm : Form
    {
        private readonly IEmployeeService _employeeService;
        public IEmployeeListForm _employeeListForm;

        #region Constructor
        public DeliveryPersonListForm(IEmployeeService employeeService, IEmployeeListForm employeeListForm)
        {
            InitializeComponent();

            _employeeService = employeeService;
            _employeeListForm = employeeListForm;
        }
        #endregion

        #region Form Load Event
        private void DeliveryPersonListForm_Load(object sender, EventArgs e)
        {
            LoadDeliveryPersons();
        }
        #endregion

        #region Data Grid Event
        private void DataGridDeliveryPersonList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView dgv))
            {
                return;
            }

            if (dgv.SelectedRows.Count == 1)
            {
                var selectedRow = dgv.SelectedRows[0];
                long id = Convert.ToInt64(selectedRow.Cells["Id"].Value.ToString());
                _employeeListForm.PopulateEmployee(id);
                Close();
            }
        }

        private void DataGridDeliveryPersonList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridDeliveryPersonList.Columns["Id"].Visible = false;
            DataGridDeliveryPersonList.Columns["Counter"].Visible = false;
            DataGridDeliveryPersonList.Columns["TempAddress"].Visible = false;
            DataGridDeliveryPersonList.Columns["PermAddress"].Visible = false;
            DataGridDeliveryPersonList.Columns["ContactNo"].Visible = false;
            DataGridDeliveryPersonList.Columns["Email"].Visible = false;
            DataGridDeliveryPersonList.Columns["CitizenshipNo"].Visible = false;
            DataGridDeliveryPersonList.Columns["Education"].Visible = false;
            DataGridDeliveryPersonList.Columns["DateOfBirth"].Visible = false;
            DataGridDeliveryPersonList.Columns["Age"].Visible = false;
            DataGridDeliveryPersonList.Columns["BloodGroup"].Visible = false;
            DataGridDeliveryPersonList.Columns["FatherName"].Visible = false;
            DataGridDeliveryPersonList.Columns["MotherName"].Visible = false;
            DataGridDeliveryPersonList.Columns["Gender"].Visible = false;
            DataGridDeliveryPersonList.Columns["SpouseName"].Visible = false;
            DataGridDeliveryPersonList.Columns["Post"].Visible = false;
            DataGridDeliveryPersonList.Columns["PostStatus"].Visible = false;
            DataGridDeliveryPersonList.Columns["AppointedDate"].Visible = false;
            DataGridDeliveryPersonList.Columns["ResignedDate"].Visible = false;
            DataGridDeliveryPersonList.Columns["ImagePath"].Visible = false;
            DataGridDeliveryPersonList.Columns["AddedDate"].Visible = false;
            DataGridDeliveryPersonList.Columns["UpdatedDate"].Visible = false;

            DataGridDeliveryPersonList.Columns["EmployeeId"].HeaderText = "Employee Id";
            DataGridDeliveryPersonList.Columns["EmployeeId"].Width = 90;
            DataGridDeliveryPersonList.Columns["EmployeeId"].DisplayIndex = 0;

            DataGridDeliveryPersonList.Columns["Name"].HeaderText = "Name";
            DataGridDeliveryPersonList.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridDeliveryPersonList.Columns["Name"].DisplayIndex = 1;
            DataGridDeliveryPersonList.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in DataGridDeliveryPersonList.Rows)
            {
                DataGridDeliveryPersonList.Rows[row.Index].HeaderCell.Value = string.Format("{0} ", row.Index + 1).ToString();
                DataGridDeliveryPersonList.RowHeadersWidth = 50;
                DataGridDeliveryPersonList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadDeliveryPersons()
        {
            var deliveryPersons = _employeeService.GetDeliveryPersons();

            var bindingList = new BindingList<Employee>(deliveryPersons.ToList());
            var source = new BindingSource(bindingList, null);
            DataGridDeliveryPersonList.DataSource = source;
        }
        #endregion
    }
}
