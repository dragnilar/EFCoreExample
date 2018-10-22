using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6Library.EFClasses;
using EF6Library.Models;

namespace EF6Console
{
    class Program
    {
        static void Main(string[] args)
        {
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

                foreach (var monster in db.Monsters)
                {
                    Console.WriteLine(monster.MonsterName);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
