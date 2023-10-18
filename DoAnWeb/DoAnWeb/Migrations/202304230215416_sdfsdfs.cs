namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsdfs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 250));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.AspNetUsers", "phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "phone", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
