namespace JetSpring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attendace : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserEmail = c.String(),
                        EventJoined = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attendances");
        }
    }
}
