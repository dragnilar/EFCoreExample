using EFDomain;
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

            server.ConnectionContext.ConnectionString = Config.LocalDbConnectionStringRegular;

            return server;
        }

        internal static Server GetServerWithoutDatabaseSpecified()
        {
            var server = new Server();
            server.ConnectionContext.ConnectionString = Config.LocalDbConnectionStringRegularWithNoDb;
            return server;
        }
    }
}