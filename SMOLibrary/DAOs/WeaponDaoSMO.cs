using System;
using System.Collections.Generic;
using EFDomain.Interfaces;
using EFDomain.Models;
using GenericConversion;

namespace SMOLibrary.DAOs
{
    public class WeaponDaoSMO : IWeaponService<Weapon>
    {
        public Weapon GetById(int id)
        {
            var server = SmoConnection.GetServer();
            var sqlText = $"Select Top 1 * from Weapons Where WeaponId = {id}";
            var result = server.ConnectionContext.ExecuteWithResults(sqlText);
            var list = Cast.ToGenericList<Weapon>(result.Tables[0], false);
            return list.Count > 0 ? list[0] : null;
        }

        public IEnumerable<Weapon> GetAllEntities()
        {
            var server = SmoConnection.GetServer();
            var sqlText = "Select * From Weapons";
            var result = server.ConnectionContext.ExecuteWithResults(sqlText);
            var list = Cast.ToGenericList<Weapon>(result.Tables[0], false);
            return list;
        }

        public void AddEntity(Weapon entity)
        {
            if (entity.WeaponId >= 1) throw new ArgumentException("Cannot insert a weapon with a preset Id");
            var server = SmoConnection.GetServer();

            var sqlText = $"INSERT INTO Weapons" +
                          $"(WeaponName, WeaponType)" +
                          $"VALUES" +
                          $"('{entity.WeaponName}', '{entity.WeaponType}')";

            server.ConnectionContext.ExecuteNonQuery(sqlText);
        }

        public void UpdateEntity(Weapon entity)
        {
            if (entity.WeaponId <= 0) throw new ArgumentException("Weapon must have a valid Id");
            var server = SmoConnection.GetServer();

            var sqlText = $"Update Weapons" +
                          $"Set WeaponName = {entity.WeaponName}, WeaponType = {entity.WeaponType}" +
                          $"Where WeaponId = {entity.WeaponId}";

            server.ConnectionContext.ExecuteNonQuery(sqlText);
        }

        public void DeleteById(int id)
        {
            if (id <= 0) throw new ArgumentException("Weapon must have a valid Id.");
            var server = SmoConnection.GetServer();

            var sqlText = $"DELETE From Weapons"
                          + $"Where WeaponId = {id}";

            server.ConnectionContext.ExecuteNonQuery(sqlText);
        }
    }
}