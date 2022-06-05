using GrocerySupplyManagementApp.DTOs;
using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using GrocerySupplyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class PricedItemListToPrintForm : Form
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private readonly IPricedItemService _pricedItemService;
        private readonly IStockService _stockService;

        private List<PricedItemView> _pricedItemViewList = new List<PricedItemView>();
        private Label[] _counterLabels;
        private Label[] _pricedItemNameLabels;
        private Label[] _pricedItemCodeLabels;
        private Label[] _pricedItemSubCodeLabels;
        private Label[] _pricedItemCustomizedQuantityLabels;
        private TextBox[] _pricedItemCountTextboxes;
        private TextBox _TxtHeaderPrintCount;
        private TextBox _TxtFooterTotalPrintCount;
        
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
            _pricedItemViewList = _pricedItemService.GetPricedItemViewList().ToList();
            SetPricedItemList(_pricedItemViewList.Count);
            LoadHeader();
            LoadBody(_pricedItemViewList);
            LoadFooter();
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
        private void SetPricedItemList(int pricedItemListCount)
        {
            _pricedItemListCount = pricedItemListCount;

            _counterLabels = new Label[_pricedItemListCount];
            _pricedItemNameLabels = new Label[_pricedItemListCount];
            _pricedItemCodeLabels = new Label[_pricedItemListCount];
            _pricedItemSubCodeLabels = new Label[_pricedItemListCount];
            _pricedItemCustomizedQuantityLabels = new Label[_pricedItemListCount];
            _pricedItemCountTextboxes = new TextBox[_pricedItemListCount];
        }

        private void LoadHeader()
        {
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderCounter",
                Text = "S.No",
                Location = new Point(5, 5),
                Size = new Size(50, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemName",
                Text = "Item Name",
                Location = new Point(60, 5),
                Size = new Size(220, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemCode",
                Text = "Item Code",
                Location = new Point(285, 5),
                Size = new Size(70, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            });
            
            TextBox TxtHeaderItemCode = new TextBox
            {
                Name = "TxtItemCode",
                Location = new Point(285, 25),
                Size = new Size(70, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            };

            TxtHeaderItemCode.KeyUp += new KeyEventHandler(TxtHeaderItemCode_KeyUp);
            PanelHeader.Controls.Add(TxtHeaderItemCode);

            PanelHeader.Controls.Add(new Label()
            {
                Name = "LblHeaderItemSubCode",
                Text = "Sub Code",
                Location = new Point(360, 5),
                Size = new Size(40, 20),
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

            _TxtHeaderPrintCount = new TextBox
            {
                Name = "TxtPrintCount",
                Location = new Point(400, 25),
                Size = new Size(75, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Right,
            };

            _TxtHeaderPrintCount.KeyUp += new KeyEventHandler(TxtHeaderPrintCount_KeyUp);
            PanelHeader.Controls.Add(_TxtHeaderPrintCount);
        }

        private void LoadBody(List<PricedItemView> pricedItemViewList)
        {
            PanelBody.Controls.Clear();
            var counter = 0;
            pricedItemViewList.ForEach((pricedItem) =>
            {
                _counterLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = (counter + 1).ToString(),
                    Location = new Point(5, 5 + (30 * counter)),
                    Size = new Size(50, 25),
                };

                _pricedItemNameLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.Name,
                    Location = new Point(60, 5 + (30 * counter)),
                    Size = new Size(220, 25)
                };

                _pricedItemCodeLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.Code,
                    Location = new Point(285, 5 + (30 * counter)),
                    Size = new Size(70, 25)
                };

                _pricedItemSubCodeLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.SubCode,
                    Location = new Point(360, 5 + (30 * counter)),
                    Size = new Size(40, 25)
                };

                _pricedItemCustomizedQuantityLabels[counter] = new Label
                {
                    Name = counter.ToString(),
                    Text = pricedItem.CustomizedQuantity.ToString(),
                    Visible = false
                };

                _pricedItemCountTextboxes[counter] = new TextBox()
                {
                    Name = pricedItem.Code,
                    Location = new Point(400, 5 + (30 * counter)),
                    Size = new Size(75, 25),
                    TextAlign = HorizontalAlignment.Right,
                };

                _pricedItemCountTextboxes[counter].KeyUp += new KeyEventHandler(TxtItemCount_KeyUp);
                _pricedItemCountTextboxes[counter].TextChanged += new EventHandler(TxtItemCount_TextChanged);

                counter++;
            });

            // Add the data
            for (int i = 0; i < _pricedItemListCount; i++)
            {
                PanelBody.Controls.Add(_counterLabels[i]);
                PanelBody.Controls.Add(_pricedItemNameLabels[i]);
                PanelBody.Controls.Add(_pricedItemCodeLabels[i]);
                PanelBody.Controls.Add(_pricedItemSubCodeLabels[i]);
                PanelBody.Controls.Add(_pricedItemCustomizedQuantityLabels[i]);
                PanelBody.Controls.Add(_pricedItemCountTextboxes[i]);
            }
        }

        private void LoadFooter()
        {
            PanelFooter.Controls.Clear();
            _TxtFooterTotalPrintCount = new TextBox
            {
                Name = "TxtFooterTotalPrintCount",
                Location = new Point(400, 3),
                Size = new Size(75, 20),
                Font = new Font(Label.DefaultFont, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true
            };

            PanelFooter.Controls.Add(_TxtFooterTotalPrintCount);
        }

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
                            var itemSubCode = _pricedItemSubCodeLabels[i].Text;
                            var itemCustomizedQuantity = Convert.ToDecimal(_pricedItemCustomizedQuantityLabels[i].Text);
                            var counter = Convert.ToInt32(_pricedItemCountTextboxes[i].Text);
                            var pricedItem = string.IsNullOrWhiteSpace(itemCode)
                                ? _pricedItemService.GetPricedItem(itemCode)
                                : _pricedItemService.GetPricedItem(itemCode, itemSubCode);
                            var stockItem = _stockService.GetStockItem(pricedItem, new StockFilter() { ItemCode = itemCode });
                            var data = new MSWordField
                            {
                                Code = itemCode,
                                SubCode = itemSubCode,
                                Price = itemCustomizedQuantity == Constants.DEFAULT_DECIMAL_VALUE
                                ? stockItem.SalesPrice
                                : Math.Round(stockItem.SalesPrice * itemCustomizedQuantity, 2)
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

        private void TxtHeaderItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            var headerItemCode = txtbox.Text.Trim();

            var pricedItemViewList = _pricedItemViewList.Where(x => x.Code.ToLower().StartsWith(headerItemCode.ToLower())).ToList();
            SetPricedItemList(pricedItemViewList.Count);
            
            _TxtHeaderPrintCount.Clear();
            LoadBody(pricedItemViewList);
            LoadFooter();
        }

        private void TxtItemCount_KeyUp(object sender, KeyEventArgs e)
        {
            _TxtHeaderPrintCount.Clear();
        }

        private void TxtItemCount_TextChanged(object sender, EventArgs e)
        {
            var totalPrintCount = 0;
            foreach (Control control in PanelBody.Controls.Cast<Control>())
            {
                if (control is TextBox && control.Text != string.Empty && int.TryParse(control.Text, out _))
                {
                    totalPrintCount += int.Parse(control.Text);
                }
            }

            _TxtFooterTotalPrintCount.Text = totalPrintCount.ToString();
        }
        #endregion
    }
}
