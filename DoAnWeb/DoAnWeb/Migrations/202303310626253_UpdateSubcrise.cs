namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubcrise : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.table_Subcribe", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.table_Subcribe", "email", c => c.String());
        }
    }
}
