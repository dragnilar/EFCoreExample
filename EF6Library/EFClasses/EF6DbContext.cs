using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6Library.Models;

namespace EF6Library.EFClasses
{
    public class EF6DbContext : DbContext
    {

        public EF6DbContext() : base(ConnectionString())
        {

        }


        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }



        /// <summary>
        /// The connection string for the DbContext. Can be changed on the fly if you so desire. It is recommended to create this using
        /// System.Data.SqlClient.SqlConnectionStringBuilder to ensure that the string is formatted correctly.
        /// TODO - Consider making this more configurable and not making it static
        /// </summary>
        /// <returns>A SQL Connection string</returns>
        public static string ConnectionString()
        {
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "EF6DbContextDb",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
                ApplicationName = "EntityFramework"
            };


            return connectionString.ToString();


        }


    }
}
