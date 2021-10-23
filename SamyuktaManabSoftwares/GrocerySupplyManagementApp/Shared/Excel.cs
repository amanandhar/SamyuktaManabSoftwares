using GrocerySupplyManagementApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MsExcel = Microsoft.Office.Interop.Excel;

namespace GrocerySupplyManagementApp.Shared
{
    public class Excel
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        public static bool Export(Dictionary<string, List<ExcelField>> excelSheets, string title, string sheetname, string filename)
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

                    foreach (KeyValuePair<string, List<ExcelField>> entry in excelSheets)
                    {
                        int i = 2;
                        xlWorkSheet.Cells[i, j] = entry.Key;
                        xlWorkSheet.Cells[i, j].Font.FontStyle = "bold";

                        List<ExcelField> excelFields = entry.Value;
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
    }
}
