using System;
using System.Collections.Generic;
using EF6Library.EFClasses;
using EFDataServices;
using EFDomain;
using EFDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("Enter one of the following options to run a test...");
                Console.WriteLine("1. EF test");
                Console.WriteLine("2. SMO test");
                Console.WriteLine("ESC. Exit");

                var input = Console.ReadKey();

                ProcessMenuOptions(input);
            }
        }

        private static void ProcessMenuOptions(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    EFTest();
                    PromptForClear();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    SMOTest();
                    PromptForClear();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }


        private static void SMOTest()
        {
            Console.Clear();
            Console.WriteLine("Performing test using SMO...");
            Console.WriteLine("Adding some test weapons to the database, please wait...");
            var service = new DataServices(DataServiceTypes.SMO);
            service.CheckDatabaseAction(true);

            foreach (var weapon in GetSampleWeapons())
            {
                service.Weapons.AddEntity(weapon);
            }

            Console.WriteLine("Test Weapons added, press any key to display whats in the database.");
            Console.ReadKey();
            foreach (var weapon in service.Weapons.GetAllEntities()) Console.WriteLine(weapon.WeaponName);
        }

        private static void EFTest()
        {
            Console.Clear();
            Console.WriteLine("Performing test using EF6...");

            DropAndMigrate();

            Console.WriteLine("Adding some test monsters to the database, please wait...");

            using (var db = new EFDbContext())
            {
                db.Monsters.AddRange(GetSampleMonsters());
                db.SaveChanges();
                Console.WriteLine("Test monsters added, press any key to display whats in the database.");
                Console.ReadKey();

                foreach (var monster in db.Monsters) Console.WriteLine(monster.MonsterName);
            }

        }

        private static void PromptForClear()
        {
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DropAndMigrate()
        {
            using (var db = new EFDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();
            }
        }

        private static List<Monster> GetSampleMonsters()
        {
            return new List<Monster>
            {
                new Monster
                {
                    MonsterName = "Morz",
                    MonsterType = "Huge Cell"
                },
                new Monster
                {
                    MonsterName = "Black Lizard",
                    MonsterType = "Reptile"
                },
                new Monster
                {
                    MonsterName = "Brachioradios",
                    MonsterType = "Dragon"
                }

            };
        }

        private static List<Weapon> GetSampleWeapons()
        {
            return new List<Weapon>
            {
                new Weapon
                {
                    WeaponName = "Caladabolg",
                    WeaponType = "Sword"
                },
                new Weapon
                {
                    WeaponName = "Ragnarok",
                    WeaponType = "Sword",
                },
                new Weapon
                {
                    WeaponName = "Trident",
                    WeaponType = "Spear"
                },
                new Weapon
                {
                    WeaponName = "Zodiac Spear",
                    WeaponType = "Spear"
                }
            };
        }
    }
}