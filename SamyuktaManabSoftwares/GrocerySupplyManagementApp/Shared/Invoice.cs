using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace GrocerySupplyManagementApp.Shared
{
    public class Invoice
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        public static bool PrintThermalInvoice(PrintPageEventArgs e)
        {
            var result = false;

            try
            {
                Graphics graphics = e.Graphics;
                //Font regular12 = new Font("Arial", 12, FontStyle.Regular);
                Font regular10 = new Font("Arial", 10, FontStyle.Regular);
                Font regular08 = new Font("Arial", 8, FontStyle.Regular);
                //Font bold = new Font("Arial", 12, FontStyle.Bold);
                SolidBrush solidBrush = new SolidBrush(Color.Black);

                float x = 5;
                float y = 10;
                float headerWidth = 299;
                float width = 289;
                float footerWidth = 299;
                float height = 0;
                float rightOffset = 100;

                // Set format of string
                StringFormat drawFormatCenter = new StringFormat
                {
                    Alignment = StringAlignment.Center
                };
                StringFormat drawFormatLeft = new StringFormat
                {
                    Alignment = StringAlignment.Near
                };
                StringFormat drawFormatRight = new StringFormat
                {
                    Alignment = StringAlignment.Far
                };
                StringBuilder text = new StringBuilder();

                // Draw header
                text.Clear().Append("Samyukta Manab Grocery");
                graphics.DrawString(text.ToString(),
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular10).Height;

                text.Clear().Append("Nayabazar - 16");
                graphics.DrawString(text.ToString(),
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular10).Height;

                text.Clear().Append("PAN No. : 303954909");
                graphics.DrawString(text.ToString(),
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular10).Height;

                text.Clear().Append("Tax Invoice");
                graphics.DrawString(text.ToString(),
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular10).Height;

                // Draw empty space
                text.Clear().Append(" ");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                // Draw body
                text.Clear().Append("Member Id: " + "M-0001");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text.Clear().Append("Time: " + "01:12 PM");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Invoice No: " + "IN-01-0001");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text.Clear().Append("Miti: " + "23/09/2078");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Pay Type: " + "CASH");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text.Clear().Append("User: " + "bhai");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                // Draw empty space
                text.Clear().Append(" ");
                graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;
                // Empty space Ends

                text.Clear().Append("-----------------------------------------------------------------------------");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("SN");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text.Clear().Append("Particulars");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x + 30, y, width, height));
                text.Clear().Append("Qty");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x + 180, y, width, height));
                text.Clear().Append("Rate");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x + 210, y, width, height));
                text.Clear().Append("Amount");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);

                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("-----------------------------------------------------------------------------");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                // Draw Grid
                text.Clear().Append("1");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text.Clear().Append("Newari Basmati Rice-20kg");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x + 30, y, width, height));
                text.Clear().Append("1.0");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x + 180, y, width, height));
                text.Clear().Append("295.00");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x + 210, y, width, height));
                text.Clear().Append("295.00");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);

                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("-----------------------------------------------------------------------------");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Total :");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text.Clear().Append("295.00");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Discount :");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text.Clear().Append("-29.50");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("-----------------------------------------------------------------------------");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Taxable Amount :");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text.Clear().Append("265.50");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("VAT 13% :");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text.Clear().Append("34.52");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("-----------------------------------------------------------------------------");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Grand Total :");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text.Clear().Append("300.00");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                // Draw Footer
                text.Clear().Append("-----------------------------------------------------------------------------");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Rs. Three Hundred only");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, footerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text.ToString(), regular08).Height;

                text.Clear().Append("Thank you for doing business with us.");
                e.Graphics.DrawString(text.ToString(),
                    regular08, solidBrush, new RectangleF(x, y, footerWidth, height), drawFormatCenter);
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
