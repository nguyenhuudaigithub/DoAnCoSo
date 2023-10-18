namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatepayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.table_Order", "typepayment", c => c.Int(nullable: false));
            AlterColumn("dbo.table_Order", "customername", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.table_Order", "customername", c => c.String());
            DropColumn("dbo.table_Order", "typepayment");
        }
    }
}
