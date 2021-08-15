using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class EmployeeForm : Form, IEmployeeListForm
    {
        private readonly IEmployeeService _employeeService;
        public DashboardForm _dashboard;
        private string _baseImageFolder;
        private const string EMPLOYEE_IMAGE_FOLDER = "Employees";
        private string _uploadedImagePath = string.Empty;

        #region Enum
        private enum Action
        {
            Add,
            Save,
            Edit,
            Update,
            Delete,
            Load,
            PopulateEmployee,
            None
        }
        #endregion 

        #region Constructor
        public EmployeeForm(IEmployeeService employeeService)
        {
            InitializeComponent();

            _employeeService = employeeService;
        }

        #endregion

        #region Form Load Event
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Click Event
        private void BtnShow_Click(object sender, EventArgs e)
        {
            EmployeeListForm employeeListForm = new EmployeeListForm(_employeeService, this);
            employeeListForm.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearAllFields();
            EnableFields();
            EnableFields(Action.Add);
            RichEmployeeId.Text = _employeeService.GetNewEmployeeId();
            RichName.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string destinationFilePath = null;
                if (!string.IsNullOrWhiteSpace(_uploadedImagePath))
                {
                    if (!Directory.Exists(_baseImageFolder))
                    {
                        DialogResult errorResult = MessageBox.Show("Base image folder is set correctly. Please check.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            return;
                        }

                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, EMPLOYEE_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, EMPLOYEE_IMAGE_FOLDER);
                        }

                        var fileName = RichEmployeeId.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, EMPLOYEE_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var date = DateTime.Now;
                var employee = new Employee
                {
                    EmployeeId = RichEmployeeId.Text,
                    Name = RichName.Text,
                    TempAddress = RichTempAddress.Text,
                    PermAddress = RichPermAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNo.Text) ? 0 : Convert.ToInt64(RichContactNo.Text),
                    Email = RichEmail.Text,
                    CitizenshipNo = RichCitizenshipNo.Text,
                    Education = ComboEducation.Text,
                    DateOfBirth = MaskDateOfBirth.Text,
                    Age = string.IsNullOrEmpty(RichAge.Text) ? 0 : Convert.ToInt32(RichAge.Text),
                    FatherName = RichFatherName.Text,
                    BloodGroup = ComboBloodGroup.Text,
                    MotherName = RichMotherName.Text,
                    Gender = ComboGender.Text,
                    MaritalStatus = ComboMaritalStatus.Text,
                    SpouseName = RichSpouseName.Text,
                    Post = ComboPost.Text,
                    PostStatus = ComboPostStatus.Text,
                    AppointedDate = MaskAppointedDate.Text,
                    ResignedDate = MaskResignedDate.Text,
                    ImagePath = destinationFilePath,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _employeeService.AddEmployee(employee);

                DialogResult result = MessageBox.Show(employee.EmployeeId + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields();
                    EnableFields(Action.Save);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var employeeId = RichEmployeeId.Text;
            try
            {
                string destinationFilePath = null;
                if (!string.IsNullOrWhiteSpace(_uploadedImagePath))
                {
                    if (!Directory.Exists(_baseImageFolder))
                    {
                        DialogResult errorResult = MessageBox.Show("Base image folder is set correctly. Please check.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (errorResult == DialogResult.OK)
                        {
                            return;
                        }

                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, EMPLOYEE_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, EMPLOYEE_IMAGE_FOLDER);
                        }

                        var fileName = RichEmployeeId.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, EMPLOYEE_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var date = DateTime.Now;
                var employee = new Employee
                {
                    EmployeeId = RichEmployeeId.Text,
                    Name = RichName.Text,
                    TempAddress = RichTempAddress.Text,
                    PermAddress = RichPermAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNo.Text) ? 0 : Convert.ToInt64(RichContactNo.Text),
                    Email = RichEmail.Text,
                    CitizenshipNo = RichCitizenshipNo.Text,
                    Education = ComboEducation.Text,
                    DateOfBirth = MaskDateOfBirth.Text,
                    Age = string.IsNullOrEmpty(RichAge.Text) ? 0 : Convert.ToInt32(RichAge.Text),
                    BloodGroup = ComboBloodGroup.Text,
                    FatherName = RichFatherName.Text,
                    MotherName = RichMotherName.Text,
                    Gender = ComboGender.Text,
                    MaritalStatus = ComboMaritalStatus.Text,
                    SpouseName = RichSpouseName.Text,
                    Post = ComboPost.Text,
                    PostStatus = ComboPostStatus.Text,
                    AppointedDate = MaskAppointedDate.Text,
                    ResignedDate = MaskResignedDate.Text,
                    ImagePath = destinationFilePath,
                    UpdatedDate = date
                };

                _employeeService.UpdateEmployee(employeeId, employee);
                DialogResult result = MessageBox.Show(employeeId + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields();
                    EnableFields(Action.Update);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult deleteResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteResult == DialogResult.Yes)
                {
                    var employeeId = RichEmployeeId.Text;
                    var fileName = employeeId + ".jpg";
                    var filePath = Path.Combine(_baseImageFolder, EMPLOYEE_IMAGE_FOLDER, fileName);
                    if (UtilityService.DeleteImage(filePath))
                    {
                        if (_employeeService.DeleteEmployee(employeeId))
                        {
                            DialogResult result = MessageBox.Show(employeeId + " has been deleted successfully.", "Message", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                ClearAllFields();
                                EnableFields();
                                EnableFields(Action.Delete);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenEmployeeImageDialog.InitialDirectory = _baseImageFolder;
            OpenEmployeeImageDialog.Filter = "All files |*.*";
            OpenEmployeeImageDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxEmployeeImage.Image = null;
        }

        private void BtnSearchSalaryDetails_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_baseImageFolder);
        }

        #endregion

        #region OpenFileDialog Event
        private void OpenEmployeeImageDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Activate();
                string[] files = OpenEmployeeImageDialog.FileNames;
                _uploadedImagePath = files[0];
                PicBoxEmployeeImage.Image = Image.FromFile(_uploadedImagePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Helper Methods
        public void PopulateEmployee(long id)
        {
            var employee = _employeeService.GetEmployee(id);

            RichEmployeeId.Text = employee.EmployeeId;
            RichName.Text = employee.Name;
            RichTempAddress.Text = employee.TempAddress;
            RichPermAddress.Text = employee.PermAddress;
            RichContactNo.Text = employee.ContactNo.ToString();
            RichEmail.Text = employee.Email;
            RichCitizenshipNo.Text = employee.CitizenshipNo;
            ComboEducation.Text = employee.Education;
            MaskDateOfBirth.Text = employee.DateOfBirth;
            RichAge.Text = employee.Age.ToString();
            ComboBloodGroup.Text = employee.BloodGroup;
            RichFatherName.Text = employee.FatherName;
            RichMotherName.Text = employee.MotherName;
            ComboGender.Text = employee.Gender;
            ComboMaritalStatus.Text = employee.MaritalStatus;
            RichSpouseName.Text = employee.SpouseName;
            ComboPost.Text = employee.Post;
            ComboPostStatus.Text = employee.PostStatus;
            MaskAppointedDate.Text = employee.AppointedDate;
            MaskResignedDate.Text = employee.ResignedDate;

            if (File.Exists(employee.ImagePath))
            {
                PicBoxEmployeeImage.ImageLocation = employee.ImagePath;
            }

            EnableFields();
            EnableFields(Action.PopulateEmployee);
        }

        private void EnableFields(Action action = Action.None)
        {
            if(action == Action.Load)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Add)
            {
                BtnSave.Enabled = true;
                BtnClear.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
                BtnSearchSalaryDetails.Enabled = true;

                RichName.Enabled = true;
                RichTempAddress.Enabled = true;
                RichPermAddress.Enabled = true;
                RichContactNo.Enabled = true;
                RichEmail.Enabled = true;
                RichCitizenshipNo.Enabled = true;
                ComboEducation.Enabled = true;
                MaskDateOfBirth.Enabled = true;
                RichAge.Enabled = true;
                ComboBloodGroup.Enabled = true;
                RichFatherName.Enabled = true;
                RichMotherName.Enabled = true;
                ComboGender.Enabled = true;
                ComboMaritalStatus.Enabled = true;
                RichSpouseName.Enabled = true;
                ComboPost.Enabled = true;
                ComboPostStatus.Enabled = true;
                MaskAppointedDate.Enabled = true;
                MaskResignedDate.Enabled = true;
            }
            else if(action == Action.Save)
            {
                BtnAdd.Enabled = true;
            }
            else if(action == Action.Edit)
            {
                BtnAdd.Enabled = false;
                BtnUpdate.Enabled = true;
                BtnClear.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
                BtnSearchSalaryDetails.Enabled = true;

                RichName.Enabled = true;
                RichTempAddress.Enabled = true;
                RichPermAddress.Enabled = true;
                RichContactNo.Enabled = true;
                RichEmail.Enabled = true;
                RichCitizenshipNo.Enabled = true;
                ComboEducation.Enabled = true;
                MaskDateOfBirth.Enabled = true;
                RichAge.Enabled = true;
                ComboBloodGroup.Enabled = true;
                RichFatherName.Enabled = true;
                RichMotherName.Enabled = true;
                ComboGender.Enabled = true;
                ComboMaritalStatus.Enabled = true;
                RichSpouseName.Enabled = true;
                ComboPost.Enabled = true;
                ComboPostStatus.Enabled = true;
                MaskAppointedDate.Enabled = true;
                MaskResignedDate.Enabled = true;
            }
            else if (action == Action.Update)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Delete)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.PopulateEmployee)
            {
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                RichEmployeeId.Enabled = false;
                RichName.Enabled = false;
                RichTempAddress.Enabled = false;
                RichPermAddress.Enabled = false;
                RichContactNo.Enabled = false;
                RichEmail.Enabled = false;
                RichCitizenshipNo.Enabled = false;
                ComboEducation.Enabled = false;
                MaskDateOfBirth.Enabled = false;
                RichAge.Enabled = false;
                ComboBloodGroup.Enabled = false;
                RichFatherName.Enabled = false;
                RichMotherName.Enabled = false;
                ComboGender.Enabled = false;
                ComboMaritalStatus.Enabled = false;
                RichSpouseName.Enabled = false;
                ComboPost.Enabled = false;
                ComboPostStatus.Enabled = false;
                MaskAppointedDate.Enabled = false;
                MaskResignedDate.Enabled = false;

                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnClear.Enabled = false;
                BtnDelete.Enabled = false;
                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;
                BtnSearchSalaryDetails.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            RichEmployeeId.Clear();
            RichName.Clear();
            RichTempAddress.Clear();
            RichPermAddress.Clear();
            RichContactNo.Clear();
            RichEmail.Clear();
            RichCitizenshipNo.Clear();
            ComboEducation.Text = string.Empty;
            MaskDateOfBirth.Clear();
            RichAge.Clear();
            ComboBloodGroup.Text = string.Empty;
            RichFatherName.Clear();
            RichMotherName.Clear();
            ComboGender.Text = string.Empty;
            ComboMaritalStatus.Text = string.Empty;
            RichSpouseName.Clear();
            ComboPost.Text = string.Empty;
            ComboPostStatus.Text = string.Empty;
            MaskAppointedDate.Clear();
            MaskResignedDate.Clear();
            PicBoxEmployeeImage.Image = null;
        }
        #endregion
    }
}
