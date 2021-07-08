using System.Configuration;
using System.IO;

namespace GrocerySupplyManagementApp.Shared
{
    public static class UtilityService
    {
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

        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.DB_CONNECTION_STRING].ConnectionString;
            return connectionString;
        }
    }
}
