namespace DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.table_Adv",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 150),
                        description = c.String(),
                        image = c.String(),
                        link = c.String(maxLength: 500),
                        type = c.Int(nullable: false),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.table_Category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        seotitle = c.String(),
                        seodescription = c.String(),
                        seokeywords = c.String(),
                        position = c.Int(nullable: false),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.table_News",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 150),
                        description = c.String(),
                        detail = c.String(),
                        image = c.String(),
                        categoryid = c.Int(nullable: false),
                        seotitle = c.String(),
                        seodescription = c.String(),
                        seokeywords = c.String(),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.table_Category", t => t.categoryid, cascadeDelete: true)
                .Index(t => t.categoryid);
            
            CreateTable(
                "dbo.table_Post",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 150),
                        description = c.String(),
                        detail = c.String(),
                        image = c.String(),
                        categoryid = c.Int(nullable: false),
                        seotitle = c.String(),
                        seodescription = c.String(),
                        seokeywords = c.String(),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.table_Category", t => t.categoryid, cascadeDelete: true)
                .Index(t => t.categoryid);
            
            CreateTable(
                "dbo.table_Contract",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 150),
                        website = c.String(),
                        email = c.String(maxLength: 150),
                        message = c.String(maxLength: 3000),
                        isread = c.Boolean(nullable: false),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.table_OrderDetail",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        orderid = c.Int(nullable: false),
                        productid = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.table_Order", t => t.orderid, cascadeDelete: true)
                .ForeignKey("dbo.table_Product", t => t.productid, cascadeDelete: true)
                .Index(t => t.orderid)
                .Index(t => t.productid);
            
            CreateTable(
                "dbo.table_Order",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(nullable: false),
                        customername = c.String(),
                        phone = c.String(nullable: false),
                        address = c.String(nullable: false),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.table_Product",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 250),
                        productcode = c.String(),
                        description = c.String(),
                        detail = c.String(),
                        image = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pricesale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        ishome = c.Boolean(nullable: false),
                        issale = c.Boolean(nullable: false),
                        isfeature = c.Boolean(nullable: false),
                        productcategoryid = c.Int(nullable: false),
                        seotitle = c.String(),
                        seodescription = c.String(),
                        seokeywords = c.String(),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.table_ProductCategory", t => t.productcategoryid, cascadeDelete: true)
                .Index(t => t.productcategoryid);
            
            CreateTable(
                "dbo.table_ProductCategory",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 150),
                        description = c.String(),
                        icon = c.String(),
                        createdby = c.String(),
                        createddate = c.DateTime(nullable: false),
                        modifierdate = c.DateTime(nullable: false),
                        modifierby = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.table_Subcribe",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        createddate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.table_SystemSetting",
                c => new
                    {
                        settingkey = c.String(nullable: false, maxLength: 100),
                        settingvalue = c.String(maxLength: 1000),
                        settingdescription = c.String(),
                    })
                .PrimaryKey(t => t.settingkey);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        fullname = c.String(),
                        phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.table_OrderDetail", "productid", "dbo.table_Product");
            DropForeignKey("dbo.table_Product", "productcategoryid", "dbo.table_ProductCategory");
            DropForeignKey("dbo.table_OrderDetail", "orderid", "dbo.table_Order");
            DropForeignKey("dbo.table_Post", "categoryid", "dbo.table_Category");
            DropForeignKey("dbo.table_News", "categoryid", "dbo.table_Category");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.table_Product", new[] { "productcategoryid" });
            DropIndex("dbo.table_OrderDetail", new[] { "productid" });
            DropIndex("dbo.table_OrderDetail", new[] { "orderid" });
            DropIndex("dbo.table_Post", new[] { "categoryid" });
            DropIndex("dbo.table_News", new[] { "categoryid" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.table_SystemSetting");
            DropTable("dbo.table_Subcribe");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.table_ProductCategory");
            DropTable("dbo.table_Product");
            DropTable("dbo.table_Order");
            DropTable("dbo.table_OrderDetail");
            DropTable("dbo.table_Contract");
            DropTable("dbo.table_Post");
            DropTable("dbo.table_News");
            DropTable("dbo.table_Category");
            DropTable("dbo.table_Adv");
        }
    }
}
