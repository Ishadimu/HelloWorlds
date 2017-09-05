namespace HelloWorlds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                        Type_Id = c.Int(),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CityTypes", t => t.Type_Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.CityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                        Type_Id = c.Int(),
                        World_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryTypes", t => t.Type_Id)
                .ForeignKey("dbo.Worlds", t => t.World_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.World_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                        Type_Id = c.Int(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StateTypes", t => t.Type_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.StateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CountryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FutureVisits",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                        City_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.City_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PastVisits",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                        City_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.City_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Worlds",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorldTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.WorldTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(),
                        InsertedBy = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.DateTime(),
                        VoidTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Worlds", "Type_Id", "dbo.WorldTypes");
            DropForeignKey("dbo.Countries", "World_Id", "dbo.Worlds");
            DropForeignKey("dbo.PastVisits", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PastVisits", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.FutureVisits", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FutureVisits", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Countries", "Type_Id", "dbo.CountryTypes");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.States", "Type_Id", "dbo.StateTypes");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropForeignKey("dbo.Cities", "Type_Id", "dbo.CityTypes");
            DropIndex("dbo.Worlds", new[] { "Type_Id" });
            DropIndex("dbo.PastVisits", new[] { "User_Id" });
            DropIndex("dbo.PastVisits", new[] { "City_Id" });
            DropIndex("dbo.FutureVisits", new[] { "User_Id" });
            DropIndex("dbo.FutureVisits", new[] { "City_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.States", new[] { "Type_Id" });
            DropIndex("dbo.Countries", new[] { "World_Id" });
            DropIndex("dbo.Countries", new[] { "Type_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropIndex("dbo.Cities", new[] { "Type_Id" });
            DropTable("dbo.WorldTypes");
            DropTable("dbo.Worlds");
            DropTable("dbo.PastVisits");
            DropTable("dbo.FutureVisits");
            DropTable("dbo.CountryTypes");
            DropTable("dbo.StateTypes");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.CityTypes");
            DropTable("dbo.Cities");
        }
    }
}
