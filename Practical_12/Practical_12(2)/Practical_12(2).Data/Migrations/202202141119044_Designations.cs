namespace Practical_12_2_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Designations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        designation = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Designations");
        }
    }
}
