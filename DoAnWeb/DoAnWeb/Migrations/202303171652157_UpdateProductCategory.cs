namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.table_ProductCategory", "alias", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.table_ProductCategory", "seotitle", c => c.String(maxLength: 250));
            AddColumn("dbo.table_ProductCategory", "seodescription", c => c.String(maxLength: 500));
            AddColumn("dbo.table_ProductCategory", "seokeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.table_ProductCategory", "description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.table_ProductCategory", "description", c => c.String());
            DropColumn("dbo.table_ProductCategory", "seokeywords");
            DropColumn("dbo.table_ProductCategory", "seodescription");
            DropColumn("dbo.table_ProductCategory", "seotitle");
            DropColumn("dbo.table_ProductCategory", "alias");
        }
    }
}
