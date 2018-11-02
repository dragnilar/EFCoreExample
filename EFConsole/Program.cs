﻿using System;
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
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    SMOTest();
                    Console.Clear();
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
            Console.WriteLine("Performing test using SMO...");
            Console.WriteLine("Adding some test weapons to the database, please wait...");
            var service = new DataServices(DataServiceTypes.SMO);
            service.CheckDatabaseAction(true);
            service.Weapons.AddEntity(new Weapon {WeaponName = "Test", WeaponType = "Test"});
            service.Weapons.AddEntity(new Weapon {WeaponName = "Test 2", WeaponType = "Test"});
            service.Weapons.AddEntity(new Weapon {WeaponName = "Test 3", WeaponType = "Test"});
            Console.WriteLine("Test Weapons added, press any key to display whats in the database.");
            Console.ReadKey();
            foreach (var weapon in service.Weapons.GetAllEntities()) Console.WriteLine(weapon.WeaponName);
        }

        private static void EFTest()
        {
            Console.WriteLine("Performing test using EF6...");

            DropAndMigrate();

            Console.WriteLine("Adding some test monsters to the database, please wait...");

            using (var db = new EFDbContext())
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

                foreach (var monster in db.Monsters) Console.WriteLine(monster.MonsterName);
            }
        }

        private static void DropAndMigrate()
        {
            using (var db = new EFDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();
            }
        }
    }
}