using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Forms.Interfaces;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class EmployeeForm : Form, IEmployeeListForm
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISettingService _settingService;
        private readonly IEmployeeService _employeeService;
        public DashboardForm _dashboard;

        private readonly string _username;
        private readonly Setting _setting;
        private readonly string _endOfDay;
        private string _baseImageFolder;
        private string _employeeImageFolder;
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
        public EmployeeForm(string username,
            ISettingService settingService, IEmployeeService employeeService)
        {
            InitializeComponent();

            _settingService = settingService;
            _employeeService = employeeService;

            _username = username;
            _setting = _settingService.GetSettings().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            _endOfDay = _setting.StartingDate;
        }

        #endregion

        #region Form Load Event
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            _employeeImageFolder = ConfigurationManager.AppSettings[Constants.EMPLOYEE_IMAGE_FOLDER].ToString();

            LoadEducations();
            LoadBloodGroups();
            LoadGenders();
            LoadMaritalStatus();
            LoadPost();
            LoadPostStatus();
            EnableFields(Action.Load);
        }
        #endregion

        #region Button Click Event
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            EmployeeListForm employeeListForm = new EmployeeListForm(_employeeService, this);
            employeeListForm.ShowDialog();
        }

        private void BtnSearchSalaryDetails_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_baseImageFolder);
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenEmployeeImageDialog.InitialDirectory = _baseImageFolder;
            OpenEmployeeImageDialog.Filter = "All files |*.*";
            OpenEmployeeImageDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxEmployeeImage.Image = PicBoxEmployeeImage.InitialImage;
            _uploadedImagePath = string.Empty;
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
                if (ValidateMemberInfo())
                {
                    string relativeImagePath = null;
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
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _employeeImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _employeeImageFolder);
                            }

                            relativeImagePath = RichEmployeeId.Text.Trim() + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _employeeImageFolder, relativeImagePath);
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                    }

                    var employee = new Employee
                    {
                        EndOfDay = _endOfDay,
                        EmployeeId = RichEmployeeId.Text.Trim(),
                        Name = RichName.Text.Trim(),
                        TempAddress = RichTempAddress.Text.Trim(),
                        PermAddress = RichPermAddress.Text.Trim(),
                        ContactNo = string.IsNullOrEmpty(RichContactNo.Text.Trim()) ? 0 : Convert.ToInt64(RichContactNo.Text.Trim()),
                        Email = RichEmail.Text.Trim(),
                        CitizenshipNo = RichCitizenshipNo.Text.Trim(),
                        Education = ComboEducation.Text.Trim(),
                        DateOfBirth = UtilityService.GetDate(MaskDtDOB.Text.Trim()),
                        Age = string.IsNullOrEmpty(RichAge.Text.Trim()) ? 0 : Convert.ToInt32(RichAge.Text.Trim()),
                        FatherName = RichFatherName.Text.Trim(),
                        BloodGroup = ComboBloodGroup.Text.Trim(),
                        MotherName = RichMotherName.Text.Trim(),
                        Gender = ComboGender.Text.Trim(),
                        MaritalStatus = ComboMaritalStatus.Text.Trim(),
                        SpouseName = RichSpouseName.Text.Trim(),
                        Post = ComboPost.Text.Trim(),
                        PostStatus = ComboPostStatus.Text.Trim(),
                        AppointedDate = UtilityService.GetDate(MaskDtAppointedDt.Text.Trim()),
                        ResignedDate = UtilityService.GetDate(MaskDtResignedDt.Text.Trim()),
                        ImagePath = relativeImagePath,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _employeeService.AddEmployee(employee);

                    DialogResult result = MessageBox.Show(employee.EmployeeId + " has been added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
                        EnableFields(Action.Save);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var employeeId = RichEmployeeId.Text.Trim();
            try
            {
                if (ValidateMemberInfo())
                {
                    string relativeImagePath = null;
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
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _employeeImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _employeeImageFolder);
                            }

                            relativeImagePath = RichEmployeeId.Text.Trim() + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _employeeImageFolder, relativeImagePath);
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                    }

                    var employee = new Employee
                    {
                        EmployeeId = RichEmployeeId.Text.Trim(),
                        Name = RichName.Text.Trim(),
                        TempAddress = RichTempAddress.Text.Trim(),
                        PermAddress = RichPermAddress.Text.Trim(),
                        ContactNo = string.IsNullOrEmpty(RichContactNo.Text.Trim()) ? 0 : Convert.ToInt64(RichContactNo.Text.Trim()),
                        Email = RichEmail.Text.Trim(),
                        CitizenshipNo = RichCitizenshipNo.Text.Trim(),
                        Education = ComboEducation.Text.Trim(),
                        DateOfBirth = UtilityService.GetDate(MaskDtDOB.Text.Trim()),
                        Age = string.IsNullOrEmpty(RichAge.Text.Trim()) ? 0 : Convert.ToInt32(RichAge.Text.Trim()),
                        BloodGroup = ComboBloodGroup.Text.Trim(),
                        FatherName = RichFatherName.Text.Trim(),
                        MotherName = RichMotherName.Text.Trim(),
                        Gender = ComboGender.Text.Trim(),
                        MaritalStatus = ComboMaritalStatus.Text.Trim(),
                        SpouseName = RichSpouseName.Text.Trim(),
                        Post = ComboPost.Text.Trim(),
                        PostStatus = ComboPostStatus.Text.Trim(),
                        AppointedDate = UtilityService.GetDate(MaskDtAppointedDt.Text.Trim()),
                        ResignedDate = UtilityService.GetDate(MaskDtResignedDt.Text.Trim()),
                        ImagePath = relativeImagePath,
                        UpdatedBy = _username,
                        UpdatedDate = DateTime.Now
                    };

                    _employeeService.UpdateEmployee(employeeId, employee);
                    DialogResult result = MessageBox.Show(employeeId + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
                        EnableFields(Action.Update);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
                DialogResult deleteResult = MessageBox.Show(Constants.MESSAGE_BOX_DELETE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteResult == DialogResult.Yes)
                {
                    var employeeId = RichEmployeeId.Text.Trim();
                    var relativeImagePath = employeeId + ".jpg";
                    var absoluteImagePath = Path.Combine(_baseImageFolder, _employeeImageFolder, relativeImagePath);
                    if (!string.IsNullOrWhiteSpace(absoluteImagePath) && File.Exists(absoluteImagePath))
                    {
                        UtilityService.DeleteImage(absoluteImagePath);
                    }

                    if (_employeeService.DeleteEmployee(employeeId))
                    {
                        DialogResult result = MessageBox.Show(employeeId + " has been deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            ClearAllFields();
                            EnableFields();
                            EnableFields(Action.Delete);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion

        #region Combo Box Event
        private void ComboEducation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboBloodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboMaritalStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboPostStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Rich Box Event
        private void RichAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
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
            MaskDtDOB.Text = employee.DateOfBirth;
            RichAge.Text = employee.Age.ToString();
            ComboBloodGroup.Text = employee.BloodGroup;
            RichFatherName.Text = employee.FatherName;
            RichMotherName.Text = employee.MotherName;
            ComboGender.Text = employee.Gender;
            ComboMaritalStatus.Text = employee.MaritalStatus;
            RichSpouseName.Text = employee.SpouseName;
            ComboPost.Text = employee.Post;
            ComboPostStatus.Text = employee.PostStatus;
            MaskDtAppointedDt.Text = employee.AppointedDate;
            MaskDtResignedDt.Text = employee.ResignedDate;

            var absoluteImagePath = Path.Combine(_baseImageFolder, _employeeImageFolder, employee.ImagePath);
            if (File.Exists(absoluteImagePath))
            {
                PicBoxEmployeeImage.ImageLocation = absoluteImagePath;
            }
            else
            {
                PicBoxEmployeeImage.Image = PicBoxEmployeeImage.InitialImage;
            }

            EnableFields();
            EnableFields(Action.PopulateEmployee);
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Load)
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
                MaskDtDOB.Enabled = true;
                RichAge.Enabled = true;
                ComboBloodGroup.Enabled = true;
                RichFatherName.Enabled = true;
                RichMotherName.Enabled = true;
                ComboGender.Enabled = true;
                ComboMaritalStatus.Enabled = true;
                RichSpouseName.Enabled = true;
                ComboPost.Enabled = true;
                ComboPostStatus.Enabled = true;
                MaskDtAppointedDt.Enabled = true;
                MaskDtResignedDt.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Edit)
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
                MaskDtDOB.Enabled = true;
                RichAge.Enabled = true;
                ComboBloodGroup.Enabled = true;
                RichFatherName.Enabled = true;
                RichMotherName.Enabled = true;
                ComboGender.Enabled = true;
                ComboMaritalStatus.Enabled = true;
                RichSpouseName.Enabled = true;
                ComboPost.Enabled = true;
                ComboPostStatus.Enabled = true;
                MaskDtAppointedDt.Enabled = true;
                MaskDtResignedDt.Enabled = true;
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
                MaskDtDOB.Enabled = false;
                RichAge.Enabled = false;
                ComboBloodGroup.Enabled = false;
                RichFatherName.Enabled = false;
                RichMotherName.Enabled = false;
                ComboGender.Enabled = false;
                ComboMaritalStatus.Enabled = false;
                RichSpouseName.Enabled = false;
                ComboPost.Enabled = false;
                ComboPostStatus.Enabled = false;
                MaskDtAppointedDt.Enabled = false;
                MaskDtResignedDt.Enabled = false;

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
            MaskDtDOB.Clear();
            RichAge.Clear();
            ComboBloodGroup.Text = string.Empty;
            RichFatherName.Clear();
            RichMotherName.Clear();
            ComboGender.Text = string.Empty;
            ComboMaritalStatus.Text = string.Empty;
            RichSpouseName.Clear();
            ComboPost.Text = string.Empty;
            ComboPostStatus.Text = string.Empty;
            MaskDtAppointedDt.Clear();
            MaskDtResignedDt.Clear();
            PicBoxEmployeeImage.Image = PicBoxEmployeeImage.InitialImage;
        }

        private void LoadEducations()
        {
            ComboEducation.Items.Clear();
            ComboEducation.ValueMember = "Id";
            ComboEducation.DisplayMember = "Value";

            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_FIVE, Value = Constants.EDUCATION_FIVE });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_SIX, Value = Constants.EDUCATION_SIX });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_SEVEN, Value = Constants.EDUCATION_SEVEN });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_EIGHT, Value = Constants.EDUCATION_EIGHT });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_NINE, Value = Constants.EDUCATION_NINE });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_SEE, Value = Constants.EDUCATION_SEE });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_A_LEVEL, Value = Constants.EDUCATION_A_LEVEL });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_PLUS_2, Value = Constants.EDUCATION_PLUS_2 });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_INTERMEDIATE, Value = Constants.EDUCATION_INTERMEDIATE });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_BACHELORS, Value = Constants.EDUCATION_BACHELORS });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_MASTERS, Value = Constants.EDUCATION_MASTERS });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_PHD, Value = Constants.EDUCATION_PHD });
            ComboEducation.Items.Add(new ComboBoxItem { Id = Constants.EDUCATION_NONE, Value = Constants.EDUCATION_NONE });
        }

        private void LoadBloodGroups()
        {
            ComboBloodGroup.Items.Clear();
            ComboBloodGroup.ValueMember = "Id";
            ComboBloodGroup.DisplayMember = "Value";

            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_A_POSITIVE, Value = Constants.BLOOD_GROUP_A_POSITIVE });
            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_A_NEGATIVE, Value = Constants.BLOOD_GROUP_A_NEGATIVE });
            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_B_POSITIVE, Value = Constants.BLOOD_GROUP_B_POSITIVE });
            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_B_NEGATIVE, Value = Constants.BLOOD_GROUP_B_NEGATIVE });
            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_O_POSITIVE, Value = Constants.BLOOD_GROUP_O_POSITIVE });
            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_O_NEGATIVE, Value = Constants.BLOOD_GROUP_O_NEGATIVE });
            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_AB_POSITIVE, Value = Constants.BLOOD_GROUP_AB_POSITIVE });
            ComboBloodGroup.Items.Add(new ComboBoxItem { Id = Constants.BLOOD_GROUP_AB_NEGATIVE, Value = Constants.BLOOD_GROUP_AB_NEGATIVE });
        }

        private void LoadGenders()
        {
            ComboGender.Items.Clear();
            ComboGender.ValueMember = "Id";
            ComboGender.DisplayMember = "Value";

            ComboGender.Items.Add(new ComboBoxItem { Id = Constants.MALE, Value = Constants.MALE });
            ComboGender.Items.Add(new ComboBoxItem { Id = Constants.FEMALE, Value = Constants.FEMALE });
        }

        private void LoadMaritalStatus()
        {
            ComboMaritalStatus.Items.Clear();
            ComboMaritalStatus.ValueMember = "Id";
            ComboMaritalStatus.DisplayMember = "Value";

            ComboMaritalStatus.Items.Add(new ComboBoxItem { Id = Constants.SINGLE, Value = Constants.SINGLE });
            ComboMaritalStatus.Items.Add(new ComboBoxItem { Id = Constants.MARRIED, Value = Constants.MARRIED });
            ComboMaritalStatus.Items.Add(new ComboBoxItem { Id = Constants.DIVORCED, Value = Constants.DIVORCED });
        }

        private void LoadPost()
        {
            ComboPost.Items.Clear();
            ComboPost.ValueMember = "Id";
            ComboPost.DisplayMember = "Value";

            ComboPost.Items.Add(new ComboBoxItem { Id = Constants.DELIVERY_PERSON, Value = Constants.DELIVERY_PERSON });
        }

        private void LoadPostStatus()
        {
            ComboPostStatus.Items.Clear();
            ComboPostStatus.ValueMember = "Id";
            ComboPostStatus.DisplayMember = "Value";

            ComboPostStatus.Items.Add(new ComboBoxItem { Id = Constants.POST_STATUS_DAILY, Value = Constants.POST_STATUS_DAILY });
            ComboPostStatus.Items.Add(new ComboBoxItem { Id = Constants.POST_STATUS_TEMPORARY, Value = Constants.POST_STATUS_TEMPORARY });
            ComboPostStatus.Items.Add(new ComboBoxItem { Id = Constants.POST_STATUS_PERMANENT, Value = Constants.POST_STATUS_PERMANENT });
        }
        #endregion

        #region Validation
        private bool ValidateMemberInfo()
        {
            var isValidated = false;

            var employeeId = RichEmployeeId.Text.Trim();
            var employeeName = RichName.Text.Trim();

            if (string.IsNullOrWhiteSpace(employeeId)
                || string.IsNullOrWhiteSpace(employeeName))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Employee Id " +
                    "\n * Employee Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isValidated = true;
            }

            return isValidated;
        }
        #endregion
    }
}
