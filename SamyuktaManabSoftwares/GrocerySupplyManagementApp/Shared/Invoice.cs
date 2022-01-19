using System;
using System.Drawing;
using System.Drawing.Printing;

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
                float headerWidth = 314;
                float width = 304;
                float footerWidth = 314;
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

                // Draw header
                string text = "Samyukta Manab Grocery";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Nayabazar - 16";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "PAN No. : 303954909";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Tax Invoice";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                // Draw empty space
                text = " ";
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                // Draw body
                text = "Customer: " + "CASH";
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Time: " + "01:12 PM";
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "Invoice No: " + "IN-01-0001";
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Date: " + DateTime.Now.ToShortDateString();
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "User: " + "bhai";
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Miti: " + "23/09/2078";
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;
                // Empty space Ends

                text = "-----------------------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "SN";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Particulars";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 30, y, width, height));
                text = "Qty";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 190, y, width, height));
                text = "Rate";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 220, y, width, height));
                text = "Amount";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 260, y, width, height));

                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "-----------------------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "1";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Newari Basmati Rice-20kg";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 30, y, width, height));
                text = "1.0";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 190, y, width, height));
                text = "295.00";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 220, y, width, height));
                text = "295.00";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x + 260, y, width, height));

                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "-----------------------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "Total :";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "295.00";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "Discount :";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "-29.50";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;
                // Empty space ends

                text = "-----------------------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "Taxable Amount :";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "265.50";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "VAT 13% :";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "34.52";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;
                // Empty space ends

                text = "-----------------------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "Grand Total :";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "300.00";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular08).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;
                // Empty space ends

                // Draw Footer
                text = "-----------------------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "Rs. Three Hundred only";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, footerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular08).Height;

                text = "Thank you for doing business with us.";
                e.Graphics.DrawString(text,
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
