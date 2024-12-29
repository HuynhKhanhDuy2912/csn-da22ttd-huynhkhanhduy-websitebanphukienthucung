namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateOrderDetailTable : DbMigration
    {
        public override void Up()
        {
            // Tạo lại bảng OrderDetail
            CreateTable(
                "dbo.tb_OrderDetail",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
        }

        public override void Down()
        {
            // Xóa bảng OrderDetail nếu rollback
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            DropTable("dbo.tb_OrderDetail");
        }
    }
}
