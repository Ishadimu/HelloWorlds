namespace HelloWorlds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumModification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Worlds", "Type_Id", "dbo.WorldTypes");
            DropIndex("dbo.Worlds", new[] { "Type_Id" });
            AddColumn("dbo.Worlds", "WorldType", c => c.Int(nullable: false));
            DropColumn("dbo.Worlds", "Type_Id");
            AddForeignKey("dbo.Worlds", "WorldType", "dbo.WorldTypes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Worlds", "WorldType", "dbo.WorldTypes");
            AddColumn("dbo.Worlds", "Type_Id", c => c.Int());
            DropColumn("dbo.Worlds", "WorldType");
            CreateIndex("dbo.Worlds", "Type_Id");
            AddForeignKey("dbo.Worlds", "Type_Id", "dbo.WorldTypes", "Id");
        }
    }
}
