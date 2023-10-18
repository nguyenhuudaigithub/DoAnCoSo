namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.table_Category", "title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.table_Category", "seotitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.table_Category", "seodescription", c => c.String(maxLength: 350));
            AlterColumn("dbo.table_Category", "seokeywords", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.table_Category", "seokeywords", c => c.String());
            AlterColumn("dbo.table_Category", "seodescription", c => c.String());
            AlterColumn("dbo.table_Category", "seotitle", c => c.String());
            AlterColumn("dbo.table_Category", "title", c => c.String());
        }
    }
}
