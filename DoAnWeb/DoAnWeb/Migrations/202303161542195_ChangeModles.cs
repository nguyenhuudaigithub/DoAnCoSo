namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.table_Post", "alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.table_Post", "image", c => c.String(maxLength: 250));
            AlterColumn("dbo.table_Post", "seotitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.table_Post", "seodescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.table_Post", "seokeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.table_Product", "productcode", c => c.String(maxLength: 50));
            AlterColumn("dbo.table_Product", "image", c => c.String(maxLength: 250));
            AlterColumn("dbo.table_Product", "seotitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.table_Product", "seodescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.table_Product", "seokeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.table_Product", "seokeywords", c => c.String());
            AlterColumn("dbo.table_Product", "seodescription", c => c.String());
            AlterColumn("dbo.table_Product", "seotitle", c => c.String());
            AlterColumn("dbo.table_Product", "image", c => c.String());
            AlterColumn("dbo.table_Product", "productcode", c => c.String());
            AlterColumn("dbo.table_Post", "seokeywords", c => c.String());
            AlterColumn("dbo.table_Post", "seodescription", c => c.String());
            AlterColumn("dbo.table_Post", "seotitle", c => c.String());
            AlterColumn("dbo.table_Post", "image", c => c.String());
            AlterColumn("dbo.table_Post", "alias", c => c.String());
        }
    }
}
