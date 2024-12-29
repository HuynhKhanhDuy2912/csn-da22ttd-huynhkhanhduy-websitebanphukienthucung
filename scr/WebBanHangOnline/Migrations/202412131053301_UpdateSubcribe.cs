namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubcribe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Subcribe", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Subcribe", "Email", c => c.String());
        }
    }
}
