using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SMOLibrary
{
    public class DatabaseBuilder
    {
        public void CreateDatabaseIfNotExists()
        {
            var server = DataAccess.GetServer();
            if (!server.Databases.Contains("EF6DbContextDb"))
            {
                var database = DataAccess.GetDatabase(server);
                database.Create();
                new TableGenerator().GenerateTables(database);
            }
        }






    }
}
