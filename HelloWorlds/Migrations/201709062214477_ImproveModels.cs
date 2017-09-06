namespace HelloWorlds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImproveModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "World_Id", "dbo.Worlds");
            DropIndex("dbo.Countries", new[] { "World_Id" });
            RenameColumn(table: "dbo.Countries", name: "World_Id", newName: "WorldId");
            AlterColumn("dbo.Countries", "WorldId", c => c.Int(nullable: false));
            CreateIndex("dbo.Countries", "WorldId");
            AddForeignKey("dbo.Countries", "WorldId", "dbo.Worlds", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "WorldId", "dbo.Worlds");
            DropIndex("dbo.Countries", new[] { "WorldId" });
            AlterColumn("dbo.Countries", "WorldId", c => c.Int());
            RenameColumn(table: "dbo.Countries", name: "WorldId", newName: "World_Id");
            CreateIndex("dbo.Countries", "World_Id");
            AddForeignKey("dbo.Countries", "World_Id", "dbo.Worlds", "Id");
        }
    }
}
