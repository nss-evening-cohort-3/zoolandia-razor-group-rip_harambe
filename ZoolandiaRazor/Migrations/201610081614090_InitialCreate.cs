namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Exhibit_ExhibitId = c.Int(nullable: false),
                        Species_SpeciesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Exhibits", t => t.Exhibit_ExhibitId, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.Species_SpeciesId, cascadeDelete: true)
                .Index(t => t.Exhibit_ExhibitId)
                .Index(t => t.Species_SpeciesId);
            
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        ExhibitId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Habitat_Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExhibitId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        Scientific_Name = c.String(nullable: false),
                        Common_Name = c.String(nullable: false),
                        Habitat_HabitatTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpeciesId)
                .ForeignKey("dbo.HabitatTypes", t => t.Habitat_HabitatTypeId, cascadeDelete: true)
                .Index(t => t.Habitat_HabitatTypeId);
            
            CreateTable(
                "dbo.HabitatTypes",
                c => new
                    {
                        HabitatTypeId = c.Int(nullable: false, identity: true),
                        Habitat = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HabitatTypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Exhibit_ExhibitId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Exhibits", t => t.Exhibit_ExhibitId)
                .Index(t => t.Exhibit_ExhibitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes");
            DropForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropIndex("dbo.Employees", new[] { "Exhibit_ExhibitId" });
            DropIndex("dbo.Species", new[] { "Habitat_HabitatTypeId" });
            DropIndex("dbo.Animals", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Animals", new[] { "Exhibit_ExhibitId" });
            DropTable("dbo.Employees");
            DropTable("dbo.HabitatTypes");
            DropTable("dbo.Species");
            DropTable("dbo.Exhibits");
            DropTable("dbo.Animals");
        }
    }
}
