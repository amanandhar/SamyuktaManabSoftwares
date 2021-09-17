using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class ShareMemberForm : Form
    {
        private readonly IShareMemberService _shareMemberService;

        private string _baseImageFolder;
        private const string MEMBER_IMAGE_FOLDER = "ShareMembers";
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
            PopulateShareMember,
            None
        }
        #endregion 

        #region Constructor
        public ShareMemberForm(IShareMemberService shareMemberService)
        {
            InitializeComponent();
            _shareMemberService = shareMemberService;
        }
        #endregion

        #region Form Load Event
        private void SalesReport_Load(object sender, EventArgs e)
        {
            _baseImageFolder = ConfigurationManager.AppSettings[Constants.BASE_IMAGE_FOLDER].ToString();
        }
        #endregion

        #region Button Click Event

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            //OpenMemberImageDialog.InitialDirectory = _baseImageFolder;
            //OpenMemberImageDialog.Filter = "All files |*.*";
            //OpenMemberImageDialog.ShowDialog();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            PicBoxShareMember.Image = null;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {

        }

        private void BtnSaveAmount_Click(object sender, EventArgs e)
        {

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {

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
                        if (!Directory.Exists(Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER)))
                        {
                            UtilityService.CreateFolder(_baseImageFolder, MEMBER_IMAGE_FOLDER);
                        }

                        var fileName = RichName.Text + DateTime.Now + ".jpg";
                        destinationFilePath = Path.Combine(_baseImageFolder, MEMBER_IMAGE_FOLDER, fileName);
                        File.Copy(_uploadedImagePath, destinationFilePath, true);
                    }
                }

                var date = DateTime.Now;
                var shareMember = new ShareMember
                {
                    Name = RichName.Text,
                    Address = RichAddress.Text,
                    ContactNo = string.IsNullOrEmpty(RichContactNumber.Text) ? 0 : Convert.ToInt64(RichContactNumber.Text),
                    ImagePath = destinationFilePath,
                    AddedDate = date,
                    UpdatedDate = date
                };

                _shareMemberService.AddShareMember(shareMember);

                DialogResult result = MessageBox.Show(shareMember.Name + " has been added successfully.", "Message", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    ClearAllFields();
                    //LoadShareMemberTransactions(shareMemberTransactionViewList);
                    EnableFields(Action.None);
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

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 
        private void EnableFields(Action action)
        {
            if (action == Action.Add)
            {
                RichName.Enabled = true;
                RichAddress.Enabled = true;
                RichContactNumber.Enabled = true;
                ComboBank.Enabled = true;
                RichNarration.Enabled = true;
                RichAmount.Enabled = true;

                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
                BtnSave.Enabled = true;
            }
            else if (action == Action.Save)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Edit)
            {
                RichName.Enabled = true;
                RichAddress.Enabled = true;
                RichContactNumber.Enabled = true;
                ComboBank.Enabled = true;
                RichNarration.Enabled = true;
                RichAmount.Enabled = true;

                BtnAddImage.Enabled = true;
                BtnDeleteImage.Enabled = true;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == Action.Update)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Delete)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.Load)
            {
                BtnAdd.Enabled = true;
            }
            else if (action == Action.PopulateShareMember)
            {
                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else
            {
                RichName.Enabled = false;
                RichAddress.Enabled = false;
                RichContactNumber.Enabled = false;
                TxtShareAmount.Enabled = false;
                RichNarration.Enabled = false;
                ComboBank.Enabled = false;
                RichAmount.Enabled = false;
                PicBoxShareMember.Enabled = false;

                BtnAdd.Enabled = false;
                BtnSave.Enabled = false;
                BtnEdit.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void ClearAllFields()
        {
            RichName.Clear();
            RichAddress.Clear();
            RichContactNumber.Clear();
            TxtShareAmount.Clear();
            RichNarration.Clear();
            ComboBank.Text = string.Empty;
            RichAmount.Clear();
            PicBoxShareMember.Image = null;
        }
        #endregion

    }
}
