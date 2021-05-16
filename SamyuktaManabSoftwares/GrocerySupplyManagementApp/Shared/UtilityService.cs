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
    }
}
