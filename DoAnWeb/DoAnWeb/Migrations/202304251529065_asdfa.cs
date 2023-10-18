namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.table_Product", "topping", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Product", "iceP", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Product", "iceB", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Product", "sugarSmall", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Product", "sugarNormal", c => c.Boolean(nullable: false));
            AddColumn("dbo.table_Product", "sugarMany", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.table_Product", "sugarMany");
            DropColumn("dbo.table_Product", "sugarNormal");
            DropColumn("dbo.table_Product", "sugarSmall");
            DropColumn("dbo.table_Product", "iceB");
            DropColumn("dbo.table_Product", "iceP");
            DropColumn("dbo.table_Product", "topping");
        }
    }
}
