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
        private readonly ICompanyInfoService _companyInfoService;

        private string _baseImageFolder;
        private const string COMPANY_IMAGE_FOLDER = "Company";
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
        public CompanyInfoForm(ICompanyInfoService companyInfoService)
        {
            InitializeComponent();

            _companyInfoService = companyInfoService;
        }
        #endregion

        #region Form Load Event
        private void CompanyInfoForm_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
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
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, COMPANY_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, COMPANY_IMAGE_FOLDER);
                        }

                        var fileName = RichCompanyName.Text + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, COMPANY_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var date = DateTime.Now;
                var companyInfo = new CompanyInfo
                {
                    Name = RichCompanyName.Text,
                    Type = RichCompanyType.Text,
                    Address = RichAddress.Text,
                    ContactNo = Convert.ToInt64(RichContactNo.Text),
                    EmailId = RichEmailId.Text,
                    Website = RichWebsite.Text,
                    FacebookPage = RichFacebookPage.Text,
                    RegistrationNo = RichRegistrationNo.Text,
                    RegistrationDate = RichRegistrationDate.Text,
                    PanVatNo = RichPanVatNo.Text,
                    LogoPath = destinationFilePath,
                    AddedDate = DateTime.Now,
                };

                _companyInfoService.DeleteCompanyInfo();
                _companyInfoService.AddCompanyInfo(companyInfo);
                DialogResult result = MessageBox.Show(RichCompanyName.Text + " has been updated successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    EnableFields();
                    EnableFields(Action.Load);
                    LoadCompanyInfo();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
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
            PicBoxCompanyLogo.Image = null;
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
                throw ex;
            }
        }
        #endregion

        #region Helper Events
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
            RichEmailId.Text = companyInfo.EmailId;
            RichWebsite.Text = companyInfo.Website;
            RichFacebookPage.Text = companyInfo.FacebookPage;
            if (File.Exists(companyInfo.LogoPath))
            {
                PicBoxCompanyLogo.ImageLocation = companyInfo.LogoPath;
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
            RichEmailId.Clear();
            RichWebsite.Clear();
            RichFacebookPage.Clear();
            PicBoxCompanyLogo.Image = null;
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
                BtnClearAll.Enabled = true;
                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;

                RichRegistrationNo.Enabled = true;
                RichRegistrationDate.Enabled = true;
                RichPanVatNo.Enabled = true;
                RichCompanyName.Enabled = true;
                RichCompanyType.Enabled = true;
                RichAddress.Enabled = true;
                RichContactNo.Enabled = true;
                RichEmailId.Enabled = true;
                RichWebsite.Enabled = true;
                RichFacebookPage.Enabled = true;
            }
            else
            {
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnClearAll.Enabled = false;
                BtnAddImage.Enabled = false;
                BtnDeleteImage.Enabled = false;

                RichRegistrationNo.Enabled = false;
                RichRegistrationDate.Enabled = false;
                RichPanVatNo.Enabled = false;
                RichCompanyName.Enabled = false;
                RichCompanyType.Enabled = false;
                RichAddress.Enabled = false;
                RichContactNo.Enabled = false;
                RichEmailId.Enabled = false;
                RichWebsite.Enabled = false;
                RichFacebookPage.Enabled = false;
                PicBoxCompanyLogo.Image = null;
            }
        }

        #endregion
    }
}
