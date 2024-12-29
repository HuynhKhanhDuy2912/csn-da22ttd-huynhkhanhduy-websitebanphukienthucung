namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableWishList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Wishlist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Wishlist", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Wishlist", new[] { "ProductId" });
            DropTable("dbo.tb_Wishlist");
        }
    }
}
