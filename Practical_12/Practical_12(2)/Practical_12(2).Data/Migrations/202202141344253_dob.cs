namespace Practical_12_2_.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.Int(nullable: false));
        }
    }
}
