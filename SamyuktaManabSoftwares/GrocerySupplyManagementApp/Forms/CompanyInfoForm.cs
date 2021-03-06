using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class CompanyInfoForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ICompanyInfoService _companyInfoService;

        private readonly string _username;
        private string _baseImageFolder;
        private string _companyImageFolder;
        private string _uploadedImagePath = string.Empty;

        #region Enum
        private enum Action
        {
            Load,
            Edit,
            None
        }
        #endregion 

        #region Constructor
        public CompanyInfoForm(string username,
            ICompanyInfoService companyInfoService)
        {
            InitializeComponent();

            _companyInfoService = companyInfoService;

            _username = username;
        }
        #endregion

        #region Form Load Event
        private void CompanyInfoForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
            _companyImageFolder = ConfigurationManager.AppSettings[Constants.COMPANY_IMAGE_FOLDER].ToString();
            EnableFields();
            EnableFields(Action.Load);
            LoadCompanyInfo();
        }
        #endregion

        #region Button Click Event
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            EnableFields(Action.Edit);
            RichRegistrationNo.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCompanyInfo())
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
                        }
                        else
                        {
                            if (!Directory.Exists(Path.Combine(_baseImageFolder, _companyImageFolder)))
                            {
                                UtilityService.CreateFolder(_baseImageFolder, _companyImageFolder);
                            }

                            relativeImagePath = RichCompanyName.Text.Trim() + ".jpg";
                            destinationFilePath = Path.Combine(_baseImageFolder, _companyImageFolder, relativeImagePath);
                            File.Copy(_uploadedImagePath, destinationFilePath, true);
                        }
                    }

                    var companyInfo = new CompanyInfo
                    {
                        Name = RichCompanyName.Text.Trim(),
                        ShortName = RichShortName.Text.Trim(),
                        Type = RichCompanyType.Text.Trim(),
                        Address = RichAddress.Text.Trim(),
                        ContactNo = Convert.ToInt64(RichContactNo.Text.Trim()),
                        EmailId = RichEmailId.Text.Trim(),
                        Website = RichWebsite.Text.Trim(),
                        FacebookPage = RichFacebookPage.Text.Trim(),
                        RegistrationNo = RichRegistrationNo.Text.Trim(),
                        RegistrationDate = RichRegistrationDate.Text.Trim(),
                        PanVatNo = RichPanVatNo.Text.Trim(),
                        LogoPath = relativeImagePath,
                        AddedBy = _username,
                        AddedDate = DateTime.Now
                    };

                    _companyInfoService.DeleteCompanyInfo();
                    _companyInfoService.AddCompanyInfo(companyInfo);
                    DialogResult result = MessageBox.Show(RichCompanyName.Text.Trim() + " has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        ClearAllFields();
                        EnableFields();
                        EnableFields(Action.Load);
                        LoadCompanyInfo();
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

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenCompanyLogoDialog.InitialDirectory = _baseImageFolder;
            OpenCompanyLogoDialog.Filter = "All files |*.*";
            OpenCompanyLogoDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxCompanyLogo.Image = PicBoxCompanyLogo.InitialImage;
            _uploadedImagePath = string.Empty;
        }
        #endregion

        #region Rich Textbox Event
        private void RichContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region OpenFileDialog Event
        private void OpenCompanyLogoDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Activate();
                string[] files = OpenCompanyLogoDialog.FileNames;
                _uploadedImagePath = files[0];
                PicBoxCompanyLogo.Image = Image.FromFile(_uploadedImagePath);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion

        #region Helper Methods
        private void LoadCompanyInfo()
        {
            var companyInfo = _companyInfoService.GetCompanyInfo();
            RichRegistrationNo.Text = companyInfo.RegistrationNo;
            RichRegistrationDate.Text = companyInfo.RegistrationDate;
            RichPanVatNo.Text = companyInfo.PanVatNo;
            RichCompanyName.Text = companyInfo.Name;
            RichCompanyType.Text = companyInfo.Type;
            RichAddress.Text = companyInfo.Address;
            RichContactNo.Text = companyInfo.ContactNo.ToString();
            RichShortName.Text = companyInfo.ShortName;
            RichEmailId.Text = companyInfo.EmailId;
            RichWebsite.Text = companyInfo.Website;
            RichFacebookPage.Text = companyInfo.FacebookPage;

            var absoluteImagePath = Path.Combine(_baseImageFolder, _companyImageFolder, companyInfo.LogoPath);
            if (File.Exists(absoluteImagePath))
            {
                PicBoxCompanyLogo.ImageLocation = absoluteImagePath;
            }
            else
            {
                PicBoxCompanyLogo.Image = PicBoxCompanyLogo.InitialImage;
            }
        }

        private void ClearAllFields()
        {
            RichRegistrationNo.Clear();
            RichRegistrationDate.Clear();
            RichPanVatNo.Clear();
            RichCompanyName.Clear();
            RichCompanyType.Clear();
            RichAddress.Clear();
            RichContactNo.Clear();
            RichShortName.Clear();
            RichEmailId.Clear();
            RichWebsite.Clear();
            RichFacebookPage.Clear();
            PicBoxCompanyLogo.Image = PicBoxCompanyLogo.InitialImage;
        }

        private void EnableFields(Action action = Action.None)
        {
            if (action == Action.Load)
            {
                BtnEdit.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                BtnUpdate.Enabled = true;
                BtnClear.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;

                RichRegistrationNo.Enabled = true;
                RichRegistrationDate.Enabled = true;
                RichPanVatNo.Enabled = true;
                RichCompanyName.Enabled = true;
                RichCompanyType.Enabled = true;
                RichAddress.Enabled = true;
                RichContactNo.Enabled = true;
                RichShortName.Enabled = true;
                RichEmailId.Enabled = true;
                RichWebsite.Enabled = true;
                RichFacebookPage.Enabled = true;
            }
            else
            {
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnClear.Enabled = false;
                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;

                RichRegistrationNo.Enabled = false;
                RichRegistrationDate.Enabled = false;
                RichPanVatNo.Enabled = false;
                RichCompanyName.Enabled = false;
                RichCompanyType.Enabled = false;
                RichAddress.Enabled = false;
                RichContactNo.Enabled = false;
                RichShortName.Enabled = false;
                RichEmailId.Enabled = false;
                RichWebsite.Enabled = false;
                RichFacebookPage.Enabled = false;
            }
        }
        #endregion

        #region
        private bool ValidateCompanyInfo()
        {
            var isValidated = false;

            var registrationNo = RichRegistrationNo.Text.Trim();
            var registrationDate = RichRegistrationDate.Text.Trim();
            var panVatNo = RichPanVatNo.Text.Trim();
            var companyName = RichCompanyName.Text.Trim();

            if (string.IsNullOrWhiteSpace(registrationNo)
                || string.IsNullOrWhiteSpace(registrationDate)
                || string.IsNullOrWhiteSpace(panVatNo)
                || string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show("Please enter following fields: " +
                    "\n * Registration Number " +
                    "\n * Registration Date " +
                    "\n * Pan Vat Number " +
                    "\n * Company Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
