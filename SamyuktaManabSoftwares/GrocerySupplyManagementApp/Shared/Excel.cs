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
        public static bool Export(Dictionary<string, List<ExcelField>> excelSheets, string filename)
        {
            var result = false;
            try
            {
                MsExcel.Application xlApp = new MsExcel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed in you computer!");
                }
                else
                {
                    object MissingValue = System.Reflection.Missing.Value;

                    xlApp.Visible = false;
                    MsExcel.Workbook xlWorkBook = xlApp.Workbooks.Add(MissingValue);
                    int counter = 0;
                    foreach (KeyValuePair<string, List<ExcelField>> entry in excelSheets)
                    {
                        if (counter == 0)
                        {
                            MsExcel.Worksheet xlSheet_1 = xlWorkBook.ActiveSheet as MsExcel.Worksheet;
                            xlSheet_1.Name = entry.Key;

                            List<ExcelField> excelFields = entry.Value;
                            int i = 1;
                            foreach (var excelField in excelFields.ToList().OrderBy(x => x.Order))
                            {
                                
                                xlSheet_1.Cells[i, 1] = excelField.Field;
                                xlSheet_1.Cells[i, 2] = excelField.Value;
                                i++;
                            }
                        }
                        else
                        {
                            MsExcel.Worksheet xlSheet_2 = xlWorkBook.Sheets.Add(MissingValue, MissingValue, 1, MissingValue) as MsExcel.Worksheet;
                            xlSheet_2.Name = entry.Key;
                            
                            List<ExcelField> excelFields = entry.Value;
                            int i = 1;
                            foreach (var excelField in excelFields.ToList().OrderBy(x => x.Order))
                            {
                                xlSheet_2.Cells[i, 1] = excelField.Field;
                                xlSheet_2.Cells[i, 2] = excelField.Value;
                                i++;
                            }
                        }

                        counter++;
                    }

                    xlWorkBook.SaveAs(filename);
                    xlWorkBook.Close(true, MissingValue, MissingValue);
                    xlApp.UserControl = true;
                    xlApp.Quit();
                    //Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                    result = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
