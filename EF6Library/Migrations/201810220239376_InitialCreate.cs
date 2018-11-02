using System.Data.Entity.Migrations;

namespace EF6Library.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Monsters",
                    c => new
                    {
                        MonsterId = c.Int(false, true),
                        MonsterName = c.String(maxLength: 1000),
                        MonsterType = c.String(maxLength: 250)
                    })
                .PrimaryKey(t => t.MonsterId);

            CreateTable(
                    "dbo.Weapons",
                    c => new
                    {
                        WeaponId = c.Int(false, true),
                        WeaponName = c.String(maxLength: 1000),
                        WeaponType = c.String(maxLength: 250)
                    })
                .PrimaryKey(t => t.WeaponId);
        }

        public override void Down()
        {
            DropTable("dbo.Weapons");
            DropTable("dbo.Monsters");
        }
    }
}