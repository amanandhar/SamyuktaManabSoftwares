using System;
using MsWord = Microsoft.Office.Interop.Word;

namespace GrocerySupplyManagementApp.Shared
{
    public class MSWord
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        public static bool Export(string filename)
        {
            var result = false;

            try
            {
                object objMissing = System.Reflection.Missing.Value;
                object objEndOfDocument = "\\endofdoc";

                // Create the application
                MsWord.Application wordApplication = new MsWord.Application
                {
                    Visible = true,
                };

                // Create the document
                MsWord.Document wordDocument = wordApplication.Documents.Add(ref objMissing, ref objMissing, ref objMissing, ref objMissing);
                wordDocument.PageSetup.PaperSize = MsWord.WdPaperSize.wdPaperA4;
                wordDocument.PageSetup.TopMargin = 0.0F;
                wordDocument.PageSetup.RightMargin = 0.0F;
                wordDocument.PageSetup.BottomMargin = 0.0F;
                wordDocument.PageSetup.LeftMargin = 0.0F;

                // Create the table
                MsWord.Table wordTable;
                MsWord.Range wordRange = wordDocument.Bookmarks.get_Item(ref objEndOfDocument).Range;
                wordTable = wordDocument.Tables.Add(wordRange, 16, 4, ref objMissing, ref objMissing);
                wordTable.Borders.InsideLineStyle = MsWord.WdLineStyle.wdLineStyleSingle;
                wordTable.Borders.OutsideLineStyle = MsWord.WdLineStyle.wdLineStyleSingle;
                wordTable.Range.Bold = 1;
                wordTable.Range.ParagraphFormat.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphCenter;
                wordTable.Range.ParagraphFormat.SpaceBefore = 2.0F;
                wordTable.Range.ParagraphFormat.SpaceAfter = 2.0F;

                var str = string.Empty;
                for (int row = 0; row <= 16; row++)
                {
                    if (row != 0)
                    {
                        wordTable.Rows[row].Height = 30;
                    }
                    for (int column = 0; column <= 4; column++)
                    {
                        str = "Samyukta Manab Grocery" + "\n" + "Item Code: 10.000101" + "\n" + "Price: 999.99";

                        wordTable.Cell(row, column).Range.Text = str;
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
