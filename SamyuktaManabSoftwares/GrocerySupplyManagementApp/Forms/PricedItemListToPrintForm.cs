using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PricedItemListToPrintForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IPricedItemService _pricedItemService;

        private Label[] _counterLabels;
        private Label[] _pricedItemNameLabels;
        private Label[] _pricedItemCodeLabels;
        private TextBox[] _pricedItemCountTextboxes;
        private int _pricedItemListCount = 0;

        #region Constructor
        public PricedItemListToPrintForm(IPricedItemService pricedItemService)
        {
            InitializeComponent();

            _pricedItemService = pricedItemService;
        }
        #endregion

        #region Form Load Event
        private void PricedItemListToPrintForm_Load(object sender, EventArgs e)
        {
            var pricedItemList = _pricedItemService.GetPricedItemViewList();
            _pricedItemListCount = pricedItemList.Count();

            _counterLabels = new Label[_pricedItemListCount];
            _pricedItemNameLabels = new Label[_pricedItemListCount];
            _pricedItemCodeLabels = new Label[_pricedItemListCount];
            _pricedItemCountTextboxes = new TextBox[_pricedItemListCount];

            var counter = 0;
            pricedItemList.ToList().ForEach((pricedItem) =>
            {
                _counterLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = (counter + 1).ToString(),
                    Location = new Point(5, 25 + (25 * counter)),
                    Size = new Size(75, 25),
                };

                _pricedItemNameLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.Name,
                    Location = new Point(80, 25 + (25 * counter)),
                    Size = new Size(200, 25)
                };

                _pricedItemCodeLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.Code,
                    Location = new Point(300, 25 + (25 * counter)),
                    Size = new Size(100, 25)
                };

                _pricedItemCountTextboxes[counter] = new TextBox()
                {
                    Name = pricedItem.Code,
                    Location = new Point(400, 25 + (25 * counter)),
                    Size = new Size(75, 25)
                };

                counter++;
            });

            // Add the header
            PanelMain.Controls.Add(new Label()
            {
                Name = "LblHeaderCounter",
                Text = "S.No",
                Location = new Point(5, 5),
                Size = new Size(75, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelMain.Controls.Add(new Label()
            {
                Name = "LblHeaderItemName",
                Text = "Item Name",
                Location = new Point(80, 5),
                Size = new Size(200, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelMain.Controls.Add(new Label()
            {
                Name = "LblHeaderItemCode",
                Text = "Item Code",
                Location = new Point(300, 5),
                Size = new Size(100, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelMain.Controls.Add(new Label()
            {
                Name = "LblPrintCount",
                Text = "Print Count",
                Location = new Point(400, 5),
                Size = new Size(75, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });

            // Add the data
            for (int i = 0; i < _pricedItemListCount; i++)
            {
                PanelMain.Controls.Add(_counterLabels[i]);
                PanelMain.Controls.Add(_pricedItemNameLabels[i]);
                PanelMain.Controls.Add(_pricedItemCodeLabels[i]);
                PanelMain.Controls.Add(_pricedItemCountTextboxes[i]);
            }
        }
        #endregion

        #region Button Click Event
        private void BtnExport_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper Methods
        private void ExportToWord()
        {
            try
            {
                Dictionary<string, string> itemsToPrint = new Dictionary<string, string>();
                for (int i = 0; i < _pricedItemListCount; i++)
                {
                    if (int.TryParse(_pricedItemCountTextboxes[i].Text, out _))
                    {
                        itemsToPrint.Add(_pricedItemCountTextboxes[i].Name, _pricedItemCountTextboxes[i].Text);
                    }
                }

                var dialogResult = SaveFileDialog.ShowDialog();
                var filename = SaveFileDialog.FileName;
                if (dialogResult == DialogResult.OK)
                {
                    if (MSWord.Export(filename))
                    {
                        MessageBox.Show(filename + " has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error while saving " + filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }
        }
        #endregion
    }
}
