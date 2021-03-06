using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MsExcel = Microsoft.Office.Interop.Excel;

namespace GrocerySupplyManagementApp.Shared
{
    public class MSExcel
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        public static bool Export(Dictionary<string, List<MSExcelField>> excelSheets, string title, string sheetname, string filename)
        {
            var result = false;
            try
            {
                var xlApp = new MsExcel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed in you computer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    object MissingValue = System.Reflection.Missing.Value;

                    xlApp.Visible = false;
                    MsExcel.Workbook xlWorkBook = xlApp.Workbooks.Add(MissingValue);
                    MsExcel.Worksheet xlWorkSheet = xlWorkBook.ActiveSheet as MsExcel.Worksheet;
                    xlWorkSheet.Name = sheetname;
                    
                    int j = 1;
                    xlWorkSheet.Cells[1, j] = title;
                    xlWorkSheet.Cells[1, j].Font.FontStyle = "bold";

                    foreach (KeyValuePair<string, List<MSExcelField>> entry in excelSheets)
                    {
                        int i = 2;
                        xlWorkSheet.Cells[i, j] = entry.Key;
                        xlWorkSheet.Cells[i, j].Font.FontStyle = "bold";

                        List<MSExcelField> excelFields = entry.Value;
                        i++;
                        foreach (var excelField in excelFields.ToList().OrderBy(x => x.Order))
                        {
                            xlWorkSheet.Cells[i, j] = excelField.Field;
                            xlWorkSheet.Cells[i, j + 1] = excelField.Value;
                            i++;
                        }

                        j += 3;
                    }

                    xlWorkBook.SaveAs(filename);
                    xlWorkBook.Close(true, MissingValue, MissingValue);
                    xlApp.UserControl = true;
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                    result = true;
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }

        public static bool Export(List<MSExcelPricedItemField> excelRows, string sheetname, string filename)
        {
            var result = false;
            try
            {
                var xlApp = new MsExcel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed in you computer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    object MissingValue = System.Reflection.Missing.Value;

                    xlApp.Visible = false;
                    MsExcel.Workbook xlWorkBook = xlApp.Workbooks.Add(MissingValue);
                    MsExcel.Worksheet xlWorkSheet = xlWorkBook.ActiveSheet as MsExcel.Worksheet;
                    xlWorkSheet.Name = sheetname;

                    MsExcel.Range range = xlWorkSheet.Cells;
                    range.HorizontalAlignment = MsExcel.XlHAlign.xlHAlignRight;
                    xlWorkSheet.Columns[1].NumberFormat = "@";
                    xlWorkSheet.Columns[2].NumberFormat = "@";
                    xlWorkSheet.Columns[3].NumberFormat = "0.00";

                    xlWorkSheet.Cells[1, 1] = "Code";
                    xlWorkSheet.Cells[1, 1].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 2] = "Name";
                    xlWorkSheet.Cells[1, 2].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 3] = "Price";
                    xlWorkSheet.Cells[1, 3].Font.FontStyle = "bold";

                    int i = 2;
                    foreach (var excelRow in excelRows)
                    {
                        xlWorkSheet.Cells[i, 1] = excelRow.Code;
                        xlWorkSheet.Cells[i, 2] = excelRow.Name;
                        xlWorkSheet.Cells[i, 3] = excelRow.Price;

                        i++;
                    }

                    xlWorkBook.SaveAs(filename);
                    xlWorkBook.Close(true, MissingValue, MissingValue);
                    xlApp.UserControl = true;
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }

        public static bool Export(List<MSExcelDailyTransactionField> excelRows, string sheetname, string filename)
        {
            var result = false;
            try
            {
                var xlApp = new MsExcel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed in you computer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    object MissingValue = System.Reflection.Missing.Value;

                    xlApp.Visible = false;
                    MsExcel.Workbook xlWorkBook = xlApp.Workbooks.Add(MissingValue);
                    MsExcel.Worksheet xlWorkSheet = xlWorkBook.ActiveSheet as MsExcel.Worksheet;
                    xlWorkSheet.Name = sheetname;

                    MsExcel.Range range = xlWorkSheet.Cells;
                    range.HorizontalAlignment = MsExcel.XlHAlign.xlHAlignRight;
                    xlWorkSheet.Columns[1].NumberFormat = "@";
                    xlWorkSheet.Columns[2].NumberFormat = "@";
                    xlWorkSheet.Columns[3].NumberFormat = "@";
                    xlWorkSheet.Columns[4].NumberFormat = "@";
                    xlWorkSheet.Columns[5].NumberFormat = "@";
                    xlWorkSheet.Columns[6].NumberFormat = "@";
                    xlWorkSheet.Columns[7].NumberFormat = "0.00";

                    xlWorkSheet.Cells[1, 1] = "Date";
                    xlWorkSheet.Cells[1, 1].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 2] = "Description";
                    xlWorkSheet.Cells[1, 2].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 3] = "Mem/Supp Id";
                    xlWorkSheet.Cells[1, 3].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 4] = "Invoice/Bill No";
                    xlWorkSheet.Cells[1, 4].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 5] = "Type";
                    xlWorkSheet.Cells[1, 5].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 6] = "Bank";
                    xlWorkSheet.Cells[1, 6].Font.FontStyle = "bold";
                    xlWorkSheet.Cells[1, 7] = "Amount";
                    xlWorkSheet.Cells[1, 7].Font.FontStyle = "bold";

                    int i = 2;
                    foreach (var excelRow in excelRows)
                    {
                        xlWorkSheet.Cells[i, 1] = excelRow.Date;
                        xlWorkSheet.Cells[i, 2] = excelRow.Description;
                        xlWorkSheet.Cells[i, 3] = excelRow.MemberSupplierId;
                        xlWorkSheet.Cells[i, 4] = excelRow.InvoiceBillNumber;
                        xlWorkSheet.Cells[i, 5] = excelRow.Type;
                        xlWorkSheet.Cells[i, 6] = excelRow.Bank;
                        xlWorkSheet.Cells[i, 7] = excelRow.Amount;

                        i++;
                    }

                    xlWorkBook.SaveAs(filename);
                    xlWorkBook.Close(true, MissingValue, MissingValue);
                    xlApp.UserControl = true;
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                    result = true;
                }
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
