namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeExhibitTableNameBecomesExhibit_Name : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exhibits", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes");
            DropIndex("dbo.Animals", new[] { "Exhibit_ExhibitId" });
            DropIndex("dbo.Animals", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Exhibits", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Species", new[] { "Habitat_HabitatTypeId" });
            AddColumn("dbo.Exhibits", "Exhibit_Name", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Exhibit_ExhibitId", c => c.Int());
            AlterColumn("dbo.Animals", "Exhibit_ExhibitId", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "Species_SpeciesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Species", "Habitat_HabitatTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animals", "Exhibit_ExhibitId");
            CreateIndex("dbo.Animals", "Species_SpeciesId");
            CreateIndex("dbo.Species", "Habitat_HabitatTypeId");
            CreateIndex("dbo.Employees", "Exhibit_ExhibitId");
            AddForeignKey("dbo.Employees", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId");
            AddForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
            AddForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes", "HabitatTypeId", cascadeDelete: true);
            DropColumn("dbo.Exhibits", "Name");
            DropColumn("dbo.Exhibits", "Employee_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exhibits", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.Exhibits", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes");
            DropForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Employees", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropIndex("dbo.Employees", new[] { "Exhibit_ExhibitId" });
            DropIndex("dbo.Species", new[] { "Habitat_HabitatTypeId" });
            DropIndex("dbo.Animals", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Animals", new[] { "Exhibit_ExhibitId" });
            AlterColumn("dbo.Species", "Habitat_HabitatTypeId", c => c.Int());
            AlterColumn("dbo.Animals", "Species_SpeciesId", c => c.Int());
            AlterColumn("dbo.Animals", "Exhibit_ExhibitId", c => c.Int());
            DropColumn("dbo.Employees", "Exhibit_ExhibitId");
            DropColumn("dbo.Exhibits", "Exhibit_Name");
            CreateIndex("dbo.Species", "Habitat_HabitatTypeId");
            CreateIndex("dbo.Exhibits", "Employee_EmployeeId");
            CreateIndex("dbo.Animals", "Species_SpeciesId");
            CreateIndex("dbo.Animals", "Exhibit_ExhibitId");
            AddForeignKey("dbo.Species", "Habitat_HabitatTypeId", "dbo.HabitatTypes", "HabitatTypeId");
            AddForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species", "SpeciesId");
            AddForeignKey("dbo.Animals", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId");
            AddForeignKey("dbo.Exhibits", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
