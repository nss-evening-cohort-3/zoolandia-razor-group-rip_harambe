namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVirtualTagforForeignKeyAssignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Exhibit_ExhibitId", "dbo.Exhibits");
            DropIndex("dbo.Employees", new[] { "Exhibit_ExhibitId" });
            AddColumn("dbo.Exhibits", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Exhibits", "Employee_EmployeeId");
            AddForeignKey("dbo.Exhibits", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            DropColumn("dbo.Employees", "Exhibit_ExhibitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Exhibit_ExhibitId", c => c.Int());
            DropForeignKey("dbo.Exhibits", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Exhibits", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Exhibits", "Employee_EmployeeId");
            CreateIndex("dbo.Employees", "Exhibit_ExhibitId");
            AddForeignKey("dbo.Employees", "Exhibit_ExhibitId", "dbo.Exhibits", "ExhibitId");
        }
    }
}
