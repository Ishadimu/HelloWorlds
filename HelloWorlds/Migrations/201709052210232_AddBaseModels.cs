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
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        Type_Id = c.Int(),
                        UpdatedBy_Id = c.String(maxLength: 128),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.CityTypes", t => t.Type_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.UpdatedBy_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.CityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        Type_Id = c.Int(),
                        UpdatedBy_Id = c.String(maxLength: 128),
                        World_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.CountryTypes", t => t.Type_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.Worlds", t => t.World_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.UpdatedBy_Id)
                .Index(t => t.World_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        Type_Id = c.Int(),
                        UpdatedBy_Id = c.String(maxLength: 128),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.StateTypes", t => t.Type_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.UpdatedBy_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.StateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.CountryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.FutureVisits",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        City_Id = c.Int(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.City_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.UpdatedBy_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PastVisits",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        City_Id = c.Int(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.City_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.UpdatedBy_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Worlds",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        Type_Id = c.Int(),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.WorldTypes", t => t.Type_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.WorldTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        InsertedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        VoidTime = c.DateTime(),
                        InsertedBy_Id = c.String(maxLength: 128),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InsertedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy_Id)
                .Index(t => t.InsertedBy_Id)
                .Index(t => t.UpdatedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Worlds", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Worlds", "Type_Id", "dbo.WorldTypes");
            DropForeignKey("dbo.WorldTypes", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorldTypes", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Worlds", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "World_Id", "dbo.Worlds");
            DropForeignKey("dbo.PastVisits", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PastVisits", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PastVisits", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PastVisits", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.FutureVisits", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FutureVisits", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FutureVisits", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FutureVisits", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Countries", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "Type_Id", "dbo.CountryTypes");
            DropForeignKey("dbo.CountryTypes", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CountryTypes", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.States", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.States", "Type_Id", "dbo.StateTypes");
            DropForeignKey("dbo.StateTypes", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StateTypes", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.States", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropForeignKey("dbo.Countries", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "Type_Id", "dbo.CityTypes");
            DropForeignKey("dbo.CityTypes", "UpdatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CityTypes", "InsertedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cities", "InsertedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WorldTypes", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.WorldTypes", new[] { "InsertedBy_Id" });
            DropIndex("dbo.Worlds", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Worlds", new[] { "Type_Id" });
            DropIndex("dbo.Worlds", new[] { "InsertedBy_Id" });
            DropIndex("dbo.PastVisits", new[] { "User_Id" });
            DropIndex("dbo.PastVisits", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.PastVisits", new[] { "InsertedBy_Id" });
            DropIndex("dbo.PastVisits", new[] { "City_Id" });
            DropIndex("dbo.FutureVisits", new[] { "User_Id" });
            DropIndex("dbo.FutureVisits", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.FutureVisits", new[] { "InsertedBy_Id" });
            DropIndex("dbo.FutureVisits", new[] { "City_Id" });
            DropIndex("dbo.CountryTypes", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.CountryTypes", new[] { "InsertedBy_Id" });
            DropIndex("dbo.StateTypes", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.StateTypes", new[] { "InsertedBy_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.States", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.States", new[] { "Type_Id" });
            DropIndex("dbo.States", new[] { "InsertedBy_Id" });
            DropIndex("dbo.Countries", new[] { "World_Id" });
            DropIndex("dbo.Countries", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Countries", new[] { "Type_Id" });
            DropIndex("dbo.Countries", new[] { "InsertedBy_Id" });
            DropIndex("dbo.CityTypes", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.CityTypes", new[] { "InsertedBy_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropIndex("dbo.Cities", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.Cities", new[] { "Type_Id" });
            DropIndex("dbo.Cities", new[] { "InsertedBy_Id" });
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
