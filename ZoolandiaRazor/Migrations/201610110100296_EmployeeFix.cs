namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes");
            DropIndex("dbo.Animals", new[] { "Exhibit_ExhibitId" });
            DropIndex("dbo.Animals", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Species", new[] { "Habitat_HabitatTypeId" });
            DropIndex("dbo.Employees", new[] { "Exhibit_ExhibitId" });
            AddColumn("dbo.Exhibits", "Employee_EmployeeId", c => c.Int());
            AlterColumn("dbo.Animals", "Exhibit_ExhibitId", c => c.Int());
            AlterColumn("dbo.Animals", "Species_SpeciesId", c => c.Int());
            AlterColumn("dbo.Species", "Habitat_HabitatTypeId", c => c.Int());
            CreateIndex("dbo.Animals", "Exhibit_ExhibitId");
            CreateIndex("dbo.Animals", "Species_SpeciesId");
            CreateIndex("dbo.Exhibits", "Employee_EmployeeId");
            CreateIndex("dbo.Species", "Habitat_HabitatTypeId");
            AddForeignKey("dbo.Exhibits", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId");
            AddForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species", "SpeciesId");
            AddForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes", "HabitatTypeId");
            DropColumn("dbo.Employees", "Exhibit_ExhibitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Exhibit_ExhibitId", c => c.Int());
            DropForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes");
            DropForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Exhibits", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Species", new[] { "Habitat_HabitatTypeId" });
            DropIndex("dbo.Exhibits", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Animals", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Animals", new[] { "Exhibit_ExhibitId" });
            AlterColumn("dbo.Species", "Habitat_HabitatTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "Species_SpeciesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "Exhibit_ExhibitId", c => c.Int(nullable: false));
            DropColumn("dbo.Exhibits", "Employee_EmployeeId");
            CreateIndex("dbo.Employees", "Exhibit_ExhibitId");
            CreateIndex("dbo.Species", "Habitat_HabitatTypeId");
            CreateIndex("dbo.Animals", "Species_SpeciesId");
            CreateIndex("dbo.Animals", "Exhibit_ExhibitId");
            AddForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes", "HabitatTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId");
        }
    }
}
