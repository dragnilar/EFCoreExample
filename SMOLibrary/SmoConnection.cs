using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SMOLibrary
{
    internal static class SmoConnection
    {

        public static Database GetDatabase(Server server)
        {
            return new Database(server, "EF6DbContextDb");
        }

        

        internal static Server GetServer()
        {
            var server = new Server();

            server.ConnectionContext.ConnectionString = EF6Common.Config.LocalDbConnectionStringRegular;

            return server;
        }

        internal static Server GetServerWithoutDatabaseSpecified()
        {
            var server = new Server();
            server.ConnectionContext.ConnectionString = EF6Common.Config.LocalDbConnectionStringRegularWithNoDb;
            return server;
        }
    }
}
