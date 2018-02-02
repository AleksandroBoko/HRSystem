namespace HRSystem.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SpecializationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specialization");
        }
    }
}
