namespace JetSpring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "UserId", c => c.Int(nullable: false));
        }
    }
}
