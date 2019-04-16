namespace RestuarantReviews.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestuarantReviews", "Restuarant_Id", "dbo.Restuarants");
            DropIndex("dbo.RestuarantReviews", new[] { "Restuarant_Id" });
            RenameColumn(table: "dbo.RestuarantReviews", name: "Restuarant_Id", newName: "RestuarantId");
            AlterColumn("dbo.RestuarantReviews", "RestuarantId", c => c.Int(nullable: false));
            CreateIndex("dbo.RestuarantReviews", "RestuarantId");
            AddForeignKey("dbo.RestuarantReviews", "RestuarantId", "dbo.Restuarants", "Id", cascadeDelete: true);
            DropColumn("dbo.RestuarantReviews", "RestaurantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestuarantReviews", "RestaurantId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RestuarantReviews", "RestuarantId", "dbo.Restuarants");
            DropIndex("dbo.RestuarantReviews", new[] { "RestuarantId" });
            AlterColumn("dbo.RestuarantReviews", "RestuarantId", c => c.Int());
            RenameColumn(table: "dbo.RestuarantReviews", name: "RestuarantId", newName: "Restuarant_Id");
            CreateIndex("dbo.RestuarantReviews", "Restuarant_Id");
            AddForeignKey("dbo.RestuarantReviews", "Restuarant_Id", "dbo.Restuarants", "Id");
        }
    }
}
