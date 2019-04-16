namespace RestuarantReviews.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestuarantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        ReviewerName = c.String(),
                        RestaurantId = c.Int(nullable: false),
                        ReviewDate = c.DateTime(nullable: false),
                        Restuarant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restuarants", t => t.Restuarant_Id)
                .Index(t => t.Restuarant_Id);
            
            CreateTable(
                "dbo.Restuarants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        Website = c.String(),
                        Country = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestuarantReviews", "Restuarant_Id", "dbo.Restuarants");
            DropIndex("dbo.RestuarantReviews", new[] { "Restuarant_Id" });
            DropTable("dbo.Restuarants");
            DropTable("dbo.RestuarantReviews");
        }
    }
}
