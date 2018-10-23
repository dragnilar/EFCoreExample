using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace SMOLibrary
{
    internal static class TableGenerator
    {
        private static List<Func<Database, Table>> TableFunctions;


        static TableGenerator()
        {
            TableFunctions.Add(GenerateWeaponsTable);
            TableFunctions.Add(GenerateMonsterTable);
            TableFunctions.Add(GenerateArmorsTable);
            TableFunctions.Add(GenerateCharactersTable);
            TableFunctions.Add(GenerateItemsTable);
        }

        internal static void GenerateTables(Database database)
        {
            foreach (var function in TableFunctions)
            {
                function.Invoke(database);
            }
        }

        private static Table GenerateMonsterTable(Database database)
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

        private static Table GenerateWeaponsTable(Database database)
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

        private static Table GenerateCharactersTable(Database database)
        {
            var table = new Table(database, "Characters");
            var idColumn = new Column
            {
                Parent = table,
                Identity = true,
                DataType = DataType.Int,
                Name = "CharacterId"

            };
            table.Columns.Add(idColumn);
            table.Columns.Add(new Column(table, "CharacterName", DataType.NVarChar(1000)));
            table.Columns.Add(new Column(table, "CharacterType", DataType.NVarChar(250)));
            var pkIndex = new Index(table, "PK_Characters")
            {
                IsUnique = true,
                IndexKeyType = IndexKeyType.DriPrimaryKey,
                IsClustered = true
            };
            pkIndex.IndexedColumns.Add(new IndexedColumn(pkIndex, idColumn.Name));

            return table;
        }

        private static Table GenerateItemsTable(Database database)
        {
            var table = new Table(database, "Items");
            var idColumn = new Column
            {
                Parent = table,
                Identity = true,
                DataType = DataType.Int,
                Name = "ItemId"

            };
            table.Columns.Add(idColumn);
            table.Columns.Add(new Column(table, "ItemName", DataType.NVarChar(1000)));
            table.Columns.Add(new Column(table, "ItemType", DataType.NVarChar(250)));
            var pkIndex = new Index(table, "PK_Items")
            {
                IsUnique = true,
                IndexKeyType = IndexKeyType.DriPrimaryKey,
                IsClustered = true
            };
            pkIndex.IndexedColumns.Add(new IndexedColumn(pkIndex, idColumn.Name));

            return table;
        }

        private static Table GenerateArmorsTable(Database database)
        {
            var table = new Table(database, "Armors");
            var idColumn = new Column
            {
                Parent = table,
                Identity = true,
                DataType = DataType.Int,
                Name = "ArmorId"

            };
            table.Columns.Add(idColumn);
            table.Columns.Add(new Column(table, "ArmorName", DataType.NVarChar(1000)));
            table.Columns.Add(new Column(table, "ArmorType", DataType.NVarChar(250)));
            var pkIndex = new Index(table, "PK_Armors")
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
