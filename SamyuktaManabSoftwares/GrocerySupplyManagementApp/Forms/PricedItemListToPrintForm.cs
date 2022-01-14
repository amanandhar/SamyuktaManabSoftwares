using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PricedItemListToPrintForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IPricedItemService _pricedItemService;
        private readonly IStockService _stockService;

        private Label[] _counterLabels;
        private Label[] _pricedItemNameLabels;
        private Label[] _pricedItemCodeLabels;
        private TextBox[] _pricedItemCountTextboxes;
        private int _pricedItemListCount = 0;
        private bool _generateBarcode = false;

        #region Constructor
        public PricedItemListToPrintForm(IPricedItemService pricedItemService, IStockService stockService, bool generateBarcode = false)
        {
            InitializeComponent();

            _pricedItemService = pricedItemService;
            _stockService = stockService;
            _generateBarcode = generateBarcode;
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

            // Add the header
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderCounter",
                Text = "S.No",
                Location = new Point(5, 5),
                Size = new Size(75, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemName",
                Text = "Item Name",
                Location = new Point(80, 5),
                Size = new Size(200, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemCode",
                Text = "Item Code",
                Location = new Point(300, 5),
                Size = new Size(100, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblPrintCount",
                Text = "Print Count",
                Location = new Point(400, 5),
                Size = new Size(75, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });

            TextBox TxtHeaderPrintCount = new TextBox
            {
                Name = "TxtPrintCount",
                Location = new Point(400, 25),
                Size = new Size(75, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            };

            TxtHeaderPrintCount.KeyUp += new KeyEventHandler(TxtHeaderPrintCount_KeyUp);
            PanelHeader.Controls.Add(TxtHeaderPrintCount);

            // Add the body
            var counter = 0;
            pricedItemList.ToList().ForEach((pricedItem) =>
            {
                _counterLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = (counter + 1).ToString(),
                    Location = new Point(5, 5 + (30 * counter)),
                    Size = new Size(75, 25),
                };

                _pricedItemNameLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.Name,
                    Location = new Point(80, 5 + (30 * counter)),
                    Size = new Size(200, 25)
                };

                _pricedItemCodeLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.Code,
                    Location = new Point(300, 5 + (30 * counter)),
                    Size = new Size(100, 25)
                };

                _pricedItemCountTextboxes[counter] = new TextBox()
                {
                    Name = pricedItem.Code,
                    Location = new Point(400, 5 + (30 * counter)),
                    Size = new Size(75, 25)
                };

                counter++;
            });

            // Add the data
            for (int i = 0; i < _pricedItemListCount; i++)
            {
                PanelBody.Controls.Add(_counterLabels[i]);
                PanelBody.Controls.Add(_pricedItemNameLabels[i]);
                PanelBody.Controls.Add(_pricedItemCodeLabels[i]);
                PanelBody.Controls.Add(_pricedItemCountTextboxes[i]);
            }  
        }
        #endregion

        #region Button Click Event
        private void BtnExport_Click(object sender, EventArgs e)
        {
            PicBoxLoading.Visible = true;
            PicBoxLoading.Dock = DockStyle.Fill;
            BackgroundWorker.RunWorkerAsync();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BackgroundWorker Event
        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ExportToWord();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PicBoxLoading.Visible = false;
            MessageBox.Show("File has been saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        #endregion

        #region Helper Methods
        private void ExportToWord()
        {
            Thread thread = new Thread((ThreadStart)(() =>
            {
                try
                {
                    List<MSWordField> dataToExport = new List<MSWordField>();
                    for (int i = 0; i < _pricedItemListCount; i++)
                    {
                        if (int.TryParse(_pricedItemCountTextboxes[i].Text, out _))
                        {
                            var itemCode = _pricedItemCountTextboxes[i].Name;
                            var counter = Convert.ToInt32(_pricedItemCountTextboxes[i].Text);
                            var data = new MSWordField
                            {
                                Code = itemCode,
                                Price = GetSalesPrice(_pricedItemService.GetPricedItem(itemCode), new StockFilter() { ItemCode = itemCode })
                            };

                            for (int x = 0; x < counter; x++)
                            {
                                dataToExport.Add(data);
                            }
                        }
                    }

                    var dialogResult = SaveFileDialog.ShowDialog();
                    var filename = SaveFileDialog.FileName;
                    if (dialogResult == DialogResult.OK)
                    {
                        MSWord.Export(filename, dataToExport, _generateBarcode);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    UtilityService.ShowExceptionMessageBox();
                }
            }));

            // Run your code from a thread that joins the STA Thread
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void TxtHeaderPrintCount_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            var headerPrintCount = txtbox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(headerPrintCount) && int.TryParse(headerPrintCount, out _))
            {
                for (int i = 0; i < _pricedItemListCount; i++)
                {
                    _pricedItemCountTextboxes[i].Text = headerPrintCount;
                }
            }
            else
            {
                for (int i = 0; i < _pricedItemListCount; i++)
                {
                    _pricedItemCountTextboxes[i].Text = string.Empty;
                }
            }
        }

        private decimal GetSalesPrice(PricedItem pricedItem, StockFilter stockFilter)
        {
            // Start: Calculation Per Unit Value, Custom Per Unit Value, Profit Amount, Sales Price Logic
            var stocks = _stockService.GetStocks(stockFilter).OrderBy(x => x.ItemCode).ThenBy(x => x.AddedDate);
            var perUnitValue = _stockService.GetPerUnitValue(stocks.ToList(), stockFilter);
            var customPerUnitValue = Math.Round(perUnitValue, 2);
            var profitPercent = pricedItem.ProfitPercent;
            var profitAmount = Math.Round(customPerUnitValue * (profitPercent / 100), 2);
            var salesPrice = customPerUnitValue + profitAmount;
            // End

            return salesPrice;
        }
        #endregion
    }
}
