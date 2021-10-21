using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;

namespace GrocerySupplyManagementApp.Shared
{
    public static class DatabaseService
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();

        private static bool BackupDatabase(string server, string database, string username, string password)
        {
            var result = false;

            try
            {
                Server dbServer = new Server(new ServerConnection(server, username, password));
                Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = database };
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }
    }
}
