using System;
using System.Collections.Generic;
using GenericConversion;
using EFDomain.Interfaces;
using EFDomain.Models;

namespace SMOLibrary.DAOs
{
    public class WeaponDaoSMO : IWeaponDAO
    {
        public IEnumerable<Weapon> GetAllWeapons()
        {
            var server = SmoConnection.GetServer();
            var sqlText = "Select * From Weapons";
            var result = server.ConnectionContext.ExecuteWithResults(sqlText);
            var list = Cast.ToGenericList<Weapon>(result.Tables[0], false);
            return list;
        }

        public Weapon GetWeapon(Weapon weapon)
        {
            var server = SmoConnection.GetServer();
            var sqlText = $"Select Top 1 * from Weapons Where WeaponId = {weapon.WeaponId}";
            var result = server.ConnectionContext.ExecuteWithResults(sqlText);
            var list = Cast.ToGenericList<Weapon>(result.Tables[0], false);
            return list.Count > 0 ? list[0] : null;
        }

        
        public void AddWeapon(Weapon weapon)
        {
            if (weapon.WeaponId >= 1)
            {
                throw new ArgumentException("Cannot insert a weapon with a preset Id");
            }
            var server = SmoConnection.GetServer();

            var sqlText = $"INSERT INTO Weapons" +
                          $"(WeaponName, WeaponType)" +
                          $"VALUES" +
                          $"('{weapon.WeaponName}', '{weapon.WeaponType}')";

            server.ConnectionContext.ExecuteNonQuery(sqlText);
        }

        public void UpdateWeapon(Weapon weapon)
        {
            if (weapon.WeaponId <= 0)
            {
                throw new ArgumentException("Weapon must have a valid Id");
            }
            var server = SmoConnection.GetServer();

            var sqlText = $"Update Weapons" +
                          $"Set WeaponName = {weapon.WeaponName}, WeaponType = {weapon.WeaponType}" +
                          $"Where WeaponId = {weapon.WeaponId}";

            server.ConnectionContext.ExecuteNonQuery(sqlText);
        }

        public void DeleteWeapon(Weapon weapon)
        {
            if (weapon.WeaponId <= 0)
            {
                throw new ArgumentException("Weapon must have a valid Id.");
            }
            var server = SmoConnection.GetServer();

            var sqlText = $"DELETE From Weapons"
                          + $"Where WeaponId = {weapon.WeaponId}";

            server.ConnectionContext.ExecuteNonQuery(sqlText);
        }
    }
}
