namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.table_Category", "link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.table_Category", "link");
        }
    }
}
