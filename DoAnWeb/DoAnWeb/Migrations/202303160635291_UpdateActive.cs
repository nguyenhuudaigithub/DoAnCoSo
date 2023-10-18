namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.table_Category", "isactive", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_News", "isactive", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Post", "isactive", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Product", "ishot", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Product", "isactive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.table_Product", "isactive");
            DropColumn("dbo.table_Product", "ishot");
            DropColumn("dbo.table_Post", "isactive");
            DropColumn("dbo.table_News", "isactive");
            DropColumn("dbo.table_Category", "isactive");
        }
    }
}
