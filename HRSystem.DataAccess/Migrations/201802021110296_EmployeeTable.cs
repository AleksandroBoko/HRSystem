namespace HRSystem.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        SecondName = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 200),
                        DateBorn = c.DateTime(nullable: false),
                        Image = c.String(nullable: false, maxLength: 200),
                        DepartmentId = c.Guid(nullable: false),
                        PositionId = c.Guid(nullable: false),
                        SpecializationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Position", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Specialization", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId)
                .Index(t => t.SpecializationId);
            
            CreateTable(
                "dbo.EmployeeTechnologies",
                c => new
                    {
                        Employee_Id = c.Guid(nullable: false),
                        Technology_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.Technology_Id })
                .ForeignKey("dbo.Employee", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Technology", t => t.Technology_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.Technology_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTechnologies", "Technology_Id", "dbo.Technology");
            DropForeignKey("dbo.EmployeeTechnologies", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Employee", "SpecializationId", "dbo.Specialization");
            DropForeignKey("dbo.Employee", "PositionId", "dbo.Position");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.EmployeeTechnologies", new[] { "Technology_Id" });
            DropIndex("dbo.EmployeeTechnologies", new[] { "Employee_Id" });
            DropIndex("dbo.Employee", new[] { "SpecializationId" });
            DropIndex("dbo.Employee", new[] { "PositionId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropTable("dbo.EmployeeTechnologies");
            DropTable("dbo.Employee");
        }
    }
}
