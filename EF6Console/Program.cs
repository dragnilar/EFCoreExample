using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6Common;
using EF6Common.Models;
using EF6DataService;
using EF6Library.EFClasses;

namespace EF6Console
{
    class Program
    {
        static void Main(string[] args)
        {
            EFTest();
            SMOTest();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        private static void SMOTest()
        {
            Console.WriteLine("Performing test using SMO...");
            Console.WriteLine("Adding some test weapons to the database, please wait...");
            var service = new DataServices(DataServiceTypes.SMO);
            service.CheckDatabaseAction(true);
            service.WeaponDAO.AddWeapon(new Weapon{WeaponName = "Test", WeaponType = "Test"});
            service.WeaponDAO.AddWeapon(new Weapon{WeaponName = "Test 2", WeaponType = "Test"});
            service.WeaponDAO.AddWeapon(new Weapon{WeaponName = "Test 3", WeaponType = "Test"});
            Console.WriteLine("Test Weapons added, press any key to display whats in the database.");
            Console.ReadKey();
            foreach (var weapon in service.WeaponDAO.GetAllWeapons())
            {
                Console.WriteLine(weapon.WeaponName);
            }
        }

        private static void EFTest()
        {
            Console.WriteLine("Performing test using EF6...");

            using (var db = new EF6DbContext())
            {
                db.Database.Delete();
            }

            Console.WriteLine("Adding some test monsters to the database, please wait...");

            using (var db = new EF6DbContext())
            {
                db.Monsters.Add(new Monster
                {
                    MonsterName = "Test",
                    MonsterType = "Test"
                });

                db.Monsters.Add(new Monster
                {
                    MonsterName = "Test 2",
                    MonsterType = "Test"
                });

                db.Monsters.Add(new Monster
                {
                    MonsterName = "Test 3",
                    MonsterType = "Test"
                });

                db.SaveChanges();

                Console.WriteLine("Test monsters added, press any key to display whats in the database.");
                Console.ReadKey();

                foreach (var monster in db.Monsters)
                {
                    Console.WriteLine(monster.MonsterName);
                }
            }
        }

        
    }
}
