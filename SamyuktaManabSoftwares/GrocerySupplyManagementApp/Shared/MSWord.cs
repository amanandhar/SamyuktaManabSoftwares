using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ZXing;
using MsWord = Microsoft.Office.Interop.Word;

namespace GrocerySupplyManagementApp.Shared
{
    public class MSWord
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        public static bool Export(string filename, List<MSWordField> data, bool generateBarcode = false)
        {
            int tableColumnCount = generateBarcode ? 6 : 4;
            var result = false;

            try
            {
                var tableRowCount = 0;
                if (data.Count == 0)
                {
                    return result;
                }
                else if (data.Count % tableColumnCount == 0)
                {
                    tableRowCount = data.Count / tableColumnCount;
                }
                else
                {
                    tableRowCount = (data.Count / tableColumnCount) + 1;
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
                if(generateBarcode)
                {
                    wordDocument.PageSetup.TopMargin = 15.0F;
                    wordDocument.PageSetup.RightMargin = 15.0F;
                    wordDocument.PageSetup.BottomMargin = 5.0F;
                    wordDocument.PageSetup.LeftMargin = 15.0F;
                }
                else
                {
                    wordDocument.PageSetup.TopMargin = 25.0F;
                    wordDocument.PageSetup.RightMargin = 0.0F;
                    wordDocument.PageSetup.BottomMargin = 25.0F;
                    wordDocument.PageSetup.LeftMargin = 0.0F;
                }

                // Create the table
                MsWord.Table wordTable;
                MsWord.Range wordRange = wordDocument.Bookmarks.get_Item(ref objEndOfDocument).Range;
                wordTable = wordDocument.Tables.Add(wordRange, tableRowCount, tableColumnCount, ref objMissing, ref objMissing);
                wordTable.Borders.InsideLineStyle = MsWord.WdLineStyle.wdLineStyleSingle;
                wordTable.Borders.OutsideLineStyle = MsWord.WdLineStyle.wdLineStyleSingle;
                wordTable.Range.Bold = 1;
                wordTable.Range.ParagraphFormat.LineSpacing = 12.00F;
                wordTable.Range.ParagraphFormat.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphCenter;
                wordTable.Range.ParagraphFormat.SpaceBefore = generateBarcode ? 0.1F : 1.3F;
                wordTable.Range.ParagraphFormat.SpaceAfter = generateBarcode ? 0.1F : 1.3F;
                wordTable.Range.Rows.Height = generateBarcode ? 80 : 30;

                BarcodeWriter barcodeWriter = null;
                if (generateBarcode)
                {
                    barcodeWriter = new BarcodeWriter() { Format = BarcodeFormat.CODABAR };
                    barcodeWriter.Options.Height = 50;
                    barcodeWriter.Options.Width = 60;
                    barcodeWriter.Options.Margin = 10;
                }

                var textToPrint = string.Empty;
                var counter = 0;
                for (int row = 1; row <= tableRowCount; row++)
                {
                    for (int column = 1; column <= tableColumnCount; column++)
                    {
                        if(counter >= data.Count)
                        {
                            break;
                        }

                        var range = wordTable.Cell(row, column).Range;
                        if(generateBarcode)
                        {
                            var barcode = string.IsNullOrWhiteSpace(data[counter].SubCode) 
                                ? data[counter].Code 
                                : data[counter].Code + "." + data[counter].SubCode;
                            var image = barcodeWriter.Write(barcode);
                            Clipboard.SetImage(image);
                            Thread.Sleep(100);

                            range.Paste();

                            textToPrint = "Samyukta Manab" + "\n" + "Grocery" + "\n" + "Price : " + data[counter].Price;
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
