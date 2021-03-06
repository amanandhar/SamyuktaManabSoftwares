using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Shared
{
    public static class UtilityService
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly static string[] units = { 
            "Zero", "One", "Two", "Three","Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", 
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" 
        };
        private readonly static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }

        public static bool CreateFolder(string rootPath, string folderName)
        {
            bool result = false;
            string folderPath = Path.Combine(rootPath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                result = true;
            }

            return result;
        }

        public static bool DeleteImage(string imagePath)
        {
            var result = false;
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                result = true;
            }

            return result;
        }

        public static string ConvertAmount(decimal amount)
        {
            try
            {
                long amount_int = (long)amount;
                long amount_dec = (long)Math.Round((amount - (decimal)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return Convert(amount_int) + " Only.";
                }
                else
                {
                    return Convert(amount_int) + " Point " + Convert(amount_dec) + " Only.";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }

            return "";
        }

        public static string Convert(long i)
        {
            if (i < 20)
            {
                return units[i];
            }
            else if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");
            }
            else if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + Convert(i % 100) : "");
            }
            else if (i < 100000)
            {
                return Convert(i / 1000) + " Thousand "
                + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
            }
            else if (i < 10000000)
            {
                return Convert(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + Convert(i % 100000) : "");
            }
            else if (i < 1000000000)
            {
                return Convert(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + Convert(i % 10000000) : "");
            }
            else
            {
                return Convert(i / 1000000000) + " Arab "
                    + ((i % 1000000000 > 0) ? " " + Convert(i % 1000000000) : "");
            }
        }

        public static string GetDate(string value)
        {
            if (!string.IsNullOrWhiteSpace(value.Replace("-", string.Empty).Trim()))
            {
                return value.Trim();
            }

            return null;
        }

        public static void ShowExceptionMessageBox()
        {
            MessageBox.Show("Fatal error occurred. \nPlease contact administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
