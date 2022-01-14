using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZXing;
using MsWord = Microsoft.Office.Interop.Word;

namespace GrocerySupplyManagementApp.Shared
{
    public class MSWord
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private const int TABLE_COLUMN_COUNT = 4;

        public static bool Export(string filename, List<MSWordField> data, bool generateBarcode = false)
        {
            var result = false;

            try
            {
                var tableRowCount = 0;
                if (data.Count == 0)
                {
                    return result;
                }
                else if (data.Count % TABLE_COLUMN_COUNT == 0)
                {
                    tableRowCount = data.Count / TABLE_COLUMN_COUNT;
                }
                else
                {
                    tableRowCount = (data.Count / TABLE_COLUMN_COUNT) + 1;
                }

                object objMissing = System.Reflection.Missing.Value;
                object objEndOfDocument = "\\endofdoc";

                // Create the application
                MsWord.Application wordApplication = new MsWord.Application
                {
                    Visible = false
                };

                // Create the document
                MsWord.Document wordDocument = wordApplication.Documents.Add(ref objMissing, ref objMissing, ref objMissing, ref objMissing);
                wordDocument.PageSetup.PaperSize = MsWord.WdPaperSize.wdPaperA4;
                wordDocument.PageSetup.TopMargin = 25.0F;
                wordDocument.PageSetup.RightMargin = 0.0F;
                wordDocument.PageSetup.BottomMargin = 25.0F;
                wordDocument.PageSetup.LeftMargin = 0.0F;

                // Create the table
                MsWord.Table wordTable;
                MsWord.Range wordRange = wordDocument.Bookmarks.get_Item(ref objEndOfDocument).Range;
                wordTable = wordDocument.Tables.Add(wordRange, tableRowCount, TABLE_COLUMN_COUNT, ref objMissing, ref objMissing);
                wordTable.Borders.InsideLineStyle = MsWord.WdLineStyle.wdLineStyleSingle;
                wordTable.Borders.OutsideLineStyle = MsWord.WdLineStyle.wdLineStyleSingle;
                wordTable.Range.Bold = 1;
                wordTable.Range.ParagraphFormat.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphCenter;
                wordTable.Range.ParagraphFormat.SpaceBefore = 1.3F;
                wordTable.Range.ParagraphFormat.SpaceAfter = 1.3F;
                wordTable.Range.Rows.Height = generateBarcode ? 80 : 30;

                BarcodeWriter barcodeWriter = null;
                if (generateBarcode)
                {
                    barcodeWriter = new BarcodeWriter() { Format = BarcodeFormat.CODE_39 };
                    barcodeWriter.Options.Height = 50;
                    barcodeWriter.Options.Width = 60;
                    barcodeWriter.Options.Margin = 10;
                }

                var textToPrint = string.Empty;
                var counter = 0;
                for (int row = 1; row <= tableRowCount; row++)
                {
                    for (int column = 1; column <= TABLE_COLUMN_COUNT; column++)
                    {
                        if(counter >= data.Count)
                        {
                            break;
                        }

                        var range = wordTable.Cell(row, column).Range;
                        if(generateBarcode)
                        {
                            Clipboard.SetImage(barcodeWriter.Write(data[counter].Code));
                            range.Paste();

                            textToPrint = "Samyukta Manab Grocery" + "\n" + "Price : " + data[counter].Price;
                            range.InsertBefore(textToPrint);

                            Clipboard.Clear();
                        }
                        else
                        {
                            textToPrint = "Samyukta Manab Grocery" + "\n" + "Item Code : " + data[counter].Code + "\n" + "Price : " + data[counter].Price;
                            range.Text = textToPrint;
                        }
                      
                        counter++;
                    }
                }

                wordDocument.SaveAs2(filename);
                wordDocument.Close();
                wordApplication.Quit();
                result = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }
    }
}
