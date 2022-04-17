using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class QuantitySettingForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly IQuantitySettingService _quantitySettingService;

        private readonly string _username;
        private readonly long _itemId;

        #region Constructors
        public QuantitySettingForm(string username, long itemId, IQuantitySettingService quantitySettingService)
        {
            InitializeComponent();
            _itemId = itemId;
            _username = username;
            _quantitySettingService = quantitySettingService;
        }
        #endregion

        #region Form Load Event
        private void QuantitySettingForm_Load(object sender, EventArgs e)
        {
            LoadQuantitySettings();
        }
        #endregion

        #region Button Click Event
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult updateResult = MessageBox.Show(Constants.MESSAGE_BOX_UPDATE_MESSAGE, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (updateResult == DialogResult.Yes)
            {
                try
                {
                    var quantitySetting = _quantitySettingService.GetQuantitySetting(_itemId);
                    var boxValue = string.IsNullOrWhiteSpace(RichBox.Text.Trim())
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : Convert.ToDecimal(RichBox.Text.Trim());

                    var packetValue = string.IsNullOrWhiteSpace(RichPacket.Text.Trim())
                        ? Constants.DEFAULT_DECIMAL_VALUE
                        : Convert.ToDecimal(RichPacket.Text.Trim());
                    if (quantitySetting.Id > 0)
                    {
                        var newQuantitySetting = new QuantitySetting()
                        {
                            ItemId = _itemId,
                            Box = boxValue,
                            Packet = packetValue,
                            UpdatedBy = _username,
                            UpdatedDate = DateTime.Now
                        };

                        _quantitySettingService.UpdateQuantitySetting(quantitySetting.Id, newQuantitySetting);
                    }
                    else
                    {
                        var newQuantitySetting = new QuantitySetting()
                        {
                            ItemId = _itemId,
                            Box = boxValue,
                            Packet = packetValue,
                            AddedBy = _username,
                            AddedDate = DateTime.Now
                        };

                        _quantitySettingService.AddQuantitySetting(newQuantitySetting);
                    }

                    DialogResult result = MessageBox.Show("Quantity setting has been set successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        LoadQuantitySettings();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Quantity setting has not set successfully!", ex);
                    UtilityService.ShowExceptionMessageBox();
                }
            }
        }
        #endregion

        #region Key Press Event
        private void RichBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void RichPacket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Helper Methods
        private void LoadQuantitySettings()
        {
            var quantitySetting = _quantitySettingService.GetQuantitySetting(_itemId);

            RichBox.Text = quantitySetting?.Box == null 
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString() 
                : quantitySetting?.Box.ToString();
            RichPacket.Text = quantitySetting?.Packet == null
                ? Constants.DEFAULT_DECIMAL_VALUE.ToString()
                : quantitySetting?.Packet.ToString();
        }
        #endregion
    }
}
