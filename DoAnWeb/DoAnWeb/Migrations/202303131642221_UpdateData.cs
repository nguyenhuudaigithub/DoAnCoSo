namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.table_Category", "alias", c => c.String());
            AddColumn("dbo.table_News", "alias", c => c.String());
            AddColumn("dbo.table_Post", "alias", c => c.String());
            AddColumn("dbo.table_Product", "alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.table_Product", "alias");
            DropColumn("dbo.table_Post", "alias");
            DropColumn("dbo.table_News", "alias");
            DropColumn("dbo.table_Category", "alias");
        }
    }
}
