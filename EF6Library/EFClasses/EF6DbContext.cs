using System.Data.Entity;
using EFDomain;
using EFDomain.Models;

namespace EF6Library.EFClasses
{
    public class EF6DbContext : DbContext
    {
        public EF6DbContext() : base(Config.LocalDbConnectionStringEf)
        {
        }


        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}