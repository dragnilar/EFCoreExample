namespace EF6Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Monsters",
                c => new
                    {
                        MonsterId = c.Int(nullable: false, identity: true),
                        MonsterName = c.String(maxLength: 1000),
                        MonsterType = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.MonsterId);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        WeaponName = c.String(maxLength: 1000),
                        WeaponType = c.String(maxLength: 250),
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
