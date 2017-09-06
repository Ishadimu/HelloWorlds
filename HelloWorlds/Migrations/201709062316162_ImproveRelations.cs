namespace HelloWorlds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImproveRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Type_Id", "dbo.CityTypes");
            DropForeignKey("dbo.States", "Type_Id", "dbo.StateTypes");
            DropForeignKey("dbo.Countries", "Type_Id", "dbo.CountryTypes");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropIndex("dbo.Cities", new[] { "Type_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropIndex("dbo.Countries", new[] { "Type_Id" });
            DropIndex("dbo.States", new[] { "Type_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            RenameColumn(table: "dbo.States", name: "Country_Id", newName: "CountryId");
            RenameColumn(table: "dbo.Cities", name: "State_Id", newName: "StateId");
            AddColumn("dbo.Cities", "CityType", c => c.Int(nullable: false));
            AddColumn("dbo.Countries", "CountryType", c => c.Int(nullable: false));
            AddColumn("dbo.States", "StateType", c => c.Int(nullable: false));
            AlterColumn("dbo.Cities", "StateId", c => c.Int(nullable: false));
            AlterColumn("dbo.States", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "StateId");
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Cities", "StateId", "dbo.States", "Id", cascadeDelete: false);
            AddForeignKey("dbo.States", "StateType", "dbo.StateTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Cities", "CityType", "dbo.CityTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Countries", "CountryType", "dbo.CountryTypes", "Id", cascadeDelete: false);
            DropColumn("dbo.Cities", "Type_Id");
            DropColumn("dbo.Countries", "Type_Id");
            DropColumn("dbo.States", "Type_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.States", "Type_Id", c => c.Int());
            AddColumn("dbo.Countries", "Type_Id", c => c.Int());
            AddColumn("dbo.Cities", "Type_Id", c => c.Int());
            DropForeignKey("dbo.Countries", "CountryType", "dbo.CountryTypes");
            DropForeignKey("dbo.States", "StateType", "dbo.StateTypes");
            DropForeignKey("dbo.Cities", "CityType", "dbo.CityTypes");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            AlterColumn("dbo.States", "CountryId", c => c.Int());
            AlterColumn("dbo.Cities", "StateId", c => c.Int());
            DropColumn("dbo.States", "StateType");
            DropColumn("dbo.Countries", "CountryType");
            DropColumn("dbo.Cities", "CityType");
            RenameColumn(table: "dbo.Cities", name: "StateId", newName: "State_Id");
            RenameColumn(table: "dbo.States", name: "CountryId", newName: "Country_Id");
            CreateIndex("dbo.States", "Country_Id");
            CreateIndex("dbo.States", "Type_Id");
            CreateIndex("dbo.Countries", "Type_Id");
            CreateIndex("dbo.Cities", "State_Id");
            CreateIndex("dbo.Cities", "Type_Id");
            AddForeignKey("dbo.Cities", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.States", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Countries", "Type_Id", "dbo.CountryTypes", "Id");
            AddForeignKey("dbo.States", "Type_Id", "dbo.StateTypes", "Id");
            AddForeignKey("dbo.Cities", "Type_Id", "dbo.CityTypes", "Id");
        }
    }
}
