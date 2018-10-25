using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6Common.Models;

namespace EF6Common.Interfaces
{
    public interface IWeaponDAO
    {
        IEnumerable<Weapon> GetAllWeapons();
        Weapon GetWeapon(Weapon weapon);
        void AddWeapon(Weapon weapon);
        void UpdateWeapon(Weapon weapon);
        void DeleteWeapon(Weapon weapon);
    }
}
