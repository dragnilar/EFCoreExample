using System.Data.Entity.Migrations;

namespace EF6Library.Migrations
{
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Armors",
                    c => new
                    {
                        Id = c.Int(false, true),
                        ArmorName = c.String(maxLength: 1000),
                        ArmorType = c.String(maxLength: 250)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Characters",
                    c => new
                    {
                        Id = c.Int(false, true),
                        CharacterName = c.String(maxLength: 1000),
                        CharacterType = c.String(maxLength: 250)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Items",
                    c => new
                    {
                        Id = c.Int(false, true),
                        ItemName = c.String(maxLength: 1000),
                        ItemType = c.String(maxLength: 250)
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