using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SMOLibrary
{
    public static class DatabaseBuilder
    {
        public static void CreateDatabaseIfNotExists(bool dropPreExistingDatabase = true)
        {
            var server = SmoConnection.GetServerWithoutDatabaseSpecified();
            if (dropPreExistingDatabase && server.Databases.Contains("EF6DbContextDb"))
            {
                server.KillDatabase("EF6DbContextDb");
                CreateDatabase(server);
            }
            else if (!server.Databases.Contains("EF6DbContextDb"))
            {
                CreateDatabase(server);

            }
        }


        private static void CreateDatabase(Server server)
        {
            var database = SmoConnection.GetDatabase(server);
            database.Create();
            TableGenerator.GenerateTables(database);
        }






    }
}
