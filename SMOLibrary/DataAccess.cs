using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SMOLibrary
{
    public static class DataAccess
    {

        public static Database GetDatabase(Server server)
        {
            return new Database(server, "EF6DbContextDb");
        }

        public static Server GetServer()
        {
            var server = new Server();
            var connectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "EF6DbContextDb",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };

            server.ConnectionContext.ConnectionString = connectionBuilder.ToString();

            return server;
        }
    }
}
