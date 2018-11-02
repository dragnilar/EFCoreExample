using System;
using EFDomain.Interfaces;
using EFDomain.Models;
using SMOLibrary;
using SMOLibrary.DAOs;

namespace EFDataServices
{
    public class DataServices
    {
        public DataServices(string accessType)
        {
            if (accessType == "SMO")
                SetDAOForSMO();
            else
                throw new ArgumentException("Invalid access type!");
        }

        public IWeaponService<Weapon> Weapons { get; set; }
        public Action<bool> CheckDatabaseAction { get; set; }

        private void SetDAOForSMO()
        {
            Weapons = new WeaponDaoSMO();
            CheckDatabaseAction = DatabaseBuilder.CreateDatabaseIfNotExists;
        }
    }
}