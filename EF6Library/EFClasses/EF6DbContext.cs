﻿using System;
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



        public static string ConnectionString()
        {
            var connectionString = new SqlConnectionStringBuilder();

            connectionString.DataSource = "(localdb)\\MSSQLLocalDB";
            connectionString.InitialCatalog = "EF6DbContextDb";
            connectionString.IntegratedSecurity = true;
            connectionString.MultipleActiveResultSets = true;
            connectionString.ApplicationName = "EntityFramework";

            return connectionString.ToString();


        }


    }
}