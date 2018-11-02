using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDomain.Models;

namespace EF6Library.EFClasses
{
    public class EF6DbContext : DbContext
    {

        public EF6DbContext() : base(EFDomain.Config.LocalDbConnectionStringEf)
        {

        }


        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
