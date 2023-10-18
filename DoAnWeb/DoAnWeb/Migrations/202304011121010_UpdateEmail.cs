namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.table_Order", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.table_Order", "email");
        }
    }
}
