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
                Font regular12 = new Font("Arial", 12, FontStyle.Regular);
                Font regular10 = new Font("Arial", 10, FontStyle.Regular);
                Font regular08 = new Font("Arial", 8, FontStyle.Regular);
                Font bold = new Font("Arial", 12, FontStyle.Bold);
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
                string text = "BAJEKO SEKUWA PVT. LTD";
                graphics.DrawString(text,
                    regular12, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular12).Height;

                text = "Sorakhutte, kathmandu";
                graphics.DrawString(text,
                    regular12, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular12).Height;

                text = "Vat No. : 303954909";
                graphics.DrawString(text,
                    regular12, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular12).Height;

                text = "Tax Invoice";
                graphics.DrawString(text,
                    regular12, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular12).Height;

                // Draw empty space
                text = " ";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = " ";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                // Draw body
                text = "Customer: " + "CASH (SK)";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "TPIN: " + "12345";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Time: " + "01:12 PM";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Invoice No: " + "SK/07952";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Date: " + DateTime.Now.ToShortDateString();
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "User: " + "MEGH";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "Miti: " + "23/09/2078";
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = string.Empty;
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;
                // Empty space Ends

                text = "----------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Sno";
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

                text = "----------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "1";
                e.Graphics.DrawString(text,
                    regular08, solidBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                text = "NEPALI KHANA SET (VEG)";
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

                text = "----------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Total :";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "295.00";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Discount :";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "-29.50";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;
                // Empty space ends

                text = "----------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Tax Free Value :";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "0.00";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Taxable Value :";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "265.50";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;
                // Empty space ends

                text = "----------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "VAT 13% :";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "34.52";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "ROUND OFF :";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "-0.02";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, regular10).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;
                // Empty space ends

                text = "----------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;

                text = "Grand Total :";
                e.Graphics.DrawString(text,
                    bold, solidBrush, new RectangleF(x, y, width - rightOffset, height), drawFormatRight);
                text = "300.00";
                e.Graphics.DrawString(text,
                    bold, solidBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += e.Graphics.MeasureString(text, bold).Height;

                // Draw empty space
                text = string.Empty;
                graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, regular10).Height;
                // Empty space ends

                text = "----------------------------------------------------------------";
                e.Graphics.DrawString(text,
                    regular10, solidBrush, new RectangleF(x, y, headerWidth, height), drawFormatCenter);
                y += e.Graphics.MeasureString(text, bold).Height;

                text = "Rs. Three Hundred only";
                e.Graphics.DrawString(text,
                    regular12, solidBrush, new RectangleF(x, y, footerWidth, height), drawFormatLeft);
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
