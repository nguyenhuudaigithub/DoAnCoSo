namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2203 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.table_Product", "pricesale", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.table_Product", "pricesale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
