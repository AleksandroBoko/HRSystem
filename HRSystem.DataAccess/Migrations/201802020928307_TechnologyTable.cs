namespace HRSystem.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TechnologyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Technology",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Technology");
        }
    }
}
