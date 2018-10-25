namespace EF6Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArmorName = c.String(maxLength: 1000),
                        ArmorType = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(maxLength: 1000),
                        CharacterType = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(maxLength: 1000),
                        ItemType = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
            DropTable("dbo.Characters");
            DropTable("dbo.Armors");
        }
    }
}
