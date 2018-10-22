using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SMOLibrary
{
    public class DatabaseBuilder
    {
        public void CreateDatabaseIfNotExists()
        {
            var server = DataAccess.GetServer();
            if (!server.Databases.Contains("EF6DbContextDb"))
            {
                var database = DataAccess.GetDatabase(server);
                database.Create();
                database.Tables.Add(GenerateMonsterTable(database));
                database.Tables.Add(GenerateWeaponsTable(database));
                
            }
        }


        private Table GenerateMonsterTable(Database database)
        {
            var table = new Table(database, "Monsters");
            var idColumn = new Column
            {
                Parent = table,
                Identity = true,
                DataType = DataType.Int,
                Name = "MonsterId"

            };
            table.Columns.Add(idColumn);
            table.Columns.Add(new Column(table, "MonsterName", DataType.NVarChar(1000)));
            table.Columns.Add(new Column(table, "MonsterType", DataType.NVarChar(250)));
            var pkIndex = new Index(table, "PK_Monsters")
            {
                IsUnique = true,
                IndexKeyType = IndexKeyType.DriPrimaryKey,
                IsClustered = true
            };
            pkIndex.IndexedColumns.Add(new IndexedColumn(pkIndex, idColumn.Name));

            return table;
        }

        private Table GenerateWeaponsTable(Database database)
        {
            var table = new Table(database, "Weapons");
            var idColumn = new Column
            {
                Parent = table,
                Identity = true,
                DataType = DataType.Int,
                Name = "WeaponId"

            };
            table.Columns.Add(idColumn);
            table.Columns.Add(new Column(table, "WeaponName", DataType.NVarChar(1000)));
            table.Columns.Add(new Column(table, "WeaponType", DataType.NVarChar(250)));
            var pkIndex = new Index(table, "PK_Weapons")
            {
                IsUnique = true,
                IndexKeyType = IndexKeyType.DriPrimaryKey,
                IsClustered = true
            };
            pkIndex.IndexedColumns.Add(new IndexedColumn(pkIndex, idColumn.Name));

            return table;
        }



    }
}
