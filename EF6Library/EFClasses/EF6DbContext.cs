using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6Common.Models;

namespace EF6Library.EFClasses
{
    public class EF6DbContext : DbContext
    {

        public EF6DbContext() : base(EF6Common.Config.LocalDbConnectionStringEf)
        {

        }


        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

    }
}
