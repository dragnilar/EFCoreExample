using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6Common.Interfaces;
using SMOLibrary;
using SMOLibrary.DAOs;

namespace EF6DataService
{
    public class DataServices
    {
        public IWeaponDAO WeaponDAO;
        public Action<bool> CheckDatabaseAction { get; set; }

        public DataServices(string accessType)
        {
            if (accessType == "SMO")
            {
                SetDAOForSMO();
            }
            else
            {
                throw new ArgumentException("Invalid access type!");
            }
        }

        private void SetDAOForSMO()
        {
            WeaponDAO = new WeaponDaoSMO();
            CheckDatabaseAction = DatabaseBuilder.CreateDatabaseIfNotExists;

        }

        
    }

}
