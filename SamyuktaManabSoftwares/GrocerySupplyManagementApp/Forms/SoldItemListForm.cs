using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class SoldItemListForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly ISoldItemService _soldItemService;

        private readonly string _username;
        private readonly string _invoiceNo;
        private int _soldItemListCount = 0;

        private Label[] _soldItemNameLabels;
        private Label[] _soldItemCodeLabels;
        private Label[] _soldItemQuantityLabels;
        private Label[] _soldItemProfitLabels;
        private CheckBox[] _soldItemSelectedCheckbox;
        private TextBox[] _soldItemAdjustedProfitTextboxes;

        #region Constructors
        public SoldItemListForm()
        {
            InitializeComponent();
        }

        public SoldItemListForm(string username, string invoiceNo, ISoldItemService soldItemService)
        {
            InitializeComponent();
            this.Text = invoiceNo;
            
            _invoiceNo = invoiceNo;
            _username = username;
            _soldItemService = soldItemService;
        }
        #endregion

        #region Form Load Event
        private void SoldItemListForm_Load(object sender, EventArgs e)
        {
            LoadSoldItemList();
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
                    for (int i = 0; i < _soldItemListCount; i++)
                    {
                        if (decimal.TryParse(_soldItemAdjustedProfitTextboxes[i].Text, out _))
                        {
                            var soldItem = new SoldItem()
                            {
                                Id = Convert.ToInt64(_soldItemAdjustedProfitTextboxes[i].Tag),
                                Profit = Convert.ToDecimal(_soldItemAdjustedProfitTextboxes[i].Text),
                                Notes = "Profit updated from " + _soldItemProfitLabels[i].Text + " to " + _soldItemAdjustedProfitTextboxes[i].Text,
                                UpdatedBy = _username,
                                UpdatedDate = DateTime.Now
                            };

                            var updatedSoldItem = _soldItemService.UpdateSoldItemProfit(soldItem.Id, soldItem);
                            if (updatedSoldItem.Id == 0)
                            {
                                throw new Exception("Error occurred while updating profit for sold item id : " + soldItem.Id);
                            }
                        }
                    }

                    DialogResult result = MessageBox.Show("Profit has been updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.PanelBody.Controls.Clear();
                        LoadSoldItemList();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Profit was not adjusted successfully!", ex);
                    UtilityService.ShowExceptionMessageBox();
                }
            }
        }
        #endregion

        #region Helper Methods
        private void LoadSoldItemList()
        {
            var soldItemViewList = _soldItemService.GetSoldItemViewList(_invoiceNo).OrderBy(item => item.ItemName);
            _soldItemListCount = soldItemViewList.Count();

            _soldItemNameLabels = new Label[_soldItemListCount];
            _soldItemCodeLabels = new Label[_soldItemListCount];
            _soldItemQuantityLabels = new Label[_soldItemListCount];
            _soldItemProfitLabels = new Label[_soldItemListCount];
            _soldItemSelectedCheckbox = new CheckBox[_soldItemListCount];
            _soldItemAdjustedProfitTextboxes = new TextBox[_soldItemListCount];

            // Add the header
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemName",
                Text = "Item Name",
                Location = new Point(5, 5),
                Size = new Size(195, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemCode",
                Text = "Code",
                Location = new Point(200, 5),
                Size = new Size(60, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemQuantity",
                Text = "Quantity",
                Location = new Point(260, 5),
                Size = new Size(60, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemProfit",
                Text = "Profit",
                Location = new Point(320, 5),
                Size = new Size(60, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderAdjustedItemProfit",
                Text = "Adj. Profit",
                Location = new Point(380, 5),
                Size = new Size(80, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });


            // Add the body
            var counter = 0;
            soldItemViewList.ToList().ForEach((soldItem) =>
            {
                _soldItemNameLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = soldItem.ItemName,
                    Location = new Point(5, 5 + (30 * counter)),
                    Size = new Size(195, 25)
                };

                _soldItemCodeLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = soldItem.ItemCode,
                    Location = new Point(200, 5 + (30 * counter)),
                    Size = new Size(60, 25)
                };

                _soldItemQuantityLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = soldItem.Quantity.ToString(),
                    Location = new Point(260, 5 + (30 * counter)),
                    Size = new Size(60, 25)
                };

                _soldItemProfitLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = soldItem.Profit.ToString(),
                    Location = new Point(320, 5 + (30 * counter)),
                    Size = new Size(60, 25)
                };

                _soldItemAdjustedProfitTextboxes[counter] = new TextBox()
                {
                    Name = counter.ToString(),
                    Location = new Point(380, 5 + (30 * counter)),
                    Size = new Size(60, 25),
                    Tag = soldItem.Id.ToString(),
                    ReadOnly = true
                };

                _soldItemAdjustedProfitTextboxes[counter].KeyUp += new KeyEventHandler(TxtHeaderAdjustedProfit_KeyUp);

                _soldItemSelectedCheckbox[counter] = new CheckBox()
                {
                    Name = counter.ToString(),
                    Location = new Point(460, 5 + (30 * counter)),
                    Size = new Size(20, 25)
                };

                _soldItemSelectedCheckbox[counter].CheckedChanged += new EventHandler(SoldItemSelectedCheckbox_CheckedChanged);

                counter++;
            });

            // Add the data
            for (int i = 0; i < _soldItemListCount; i++)
            {
                PanelBody.Controls.Add(_soldItemNameLabels[i]);
                PanelBody.Controls.Add(_soldItemCodeLabels[i]);
                PanelBody.Controls.Add(_soldItemQuantityLabels[i]);
                PanelBody.Controls.Add(_soldItemProfitLabels[i]);
                PanelBody.Controls.Add(_soldItemAdjustedProfitTextboxes[i]);
                PanelBody.Controls.Add(_soldItemSelectedCheckbox[i]);
            }
        }

        private void SoldItemSelectedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (sender as CheckBox);
            if (checkBox.Checked)
            {
                _soldItemAdjustedProfitTextboxes[Convert.ToInt32(checkBox.Name)].ReadOnly = false;
                _soldItemAdjustedProfitTextboxes[Convert.ToInt32(checkBox.Name)].Focus();
            }
            else
            {
                _soldItemAdjustedProfitTextboxes[Convert.ToInt32(checkBox.Name)].ReadOnly = true;
            }
        }

        private void TxtHeaderAdjustedProfit_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            var index = Convert.ToInt64(textbox.Name.ToString());
            var adjustedProfit = textbox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(adjustedProfit) && decimal.TryParse(adjustedProfit, out _))
            {
                _soldItemAdjustedProfitTextboxes[index].Text = adjustedProfit;
            }
            else
            {
                _soldItemAdjustedProfitTextboxes[index].Text = string.Empty;
            }
        }
        #endregion
    }
}
