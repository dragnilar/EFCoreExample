
using EFDomain;
using EFDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6Library.EFClasses
{
    public class EFDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Config.LocalDbConnectionStringEf);
        }




        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}