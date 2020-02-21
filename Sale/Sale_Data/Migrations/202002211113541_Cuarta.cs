namespace Sale_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cuarta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType");
            DropForeignKey("dbo.Sale", "ProductId", "dbo.Product");
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            DropIndex("dbo.Sale", new[] { "ProductId" });
            AddColumn("dbo.Sale", "SupplierProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Sale", "ProductId");
            DropTable("dbo.Product");
            DropTable("dbo.ProductType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        ProductTypeDescription = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductTypeId = c.Int(nullable: false),
                        ProductDescription = c.String(maxLength: 500),
                        Prize = c.Double(nullable: false),
                        Cuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            AddColumn("dbo.Sale", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Sale", "SupplierProductId");
            CreateIndex("dbo.Sale", "ProductId");
            CreateIndex("dbo.Product", "ProductTypeId");
            AddForeignKey("dbo.Sale", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType", "ProductTypeId", cascadeDelete: true);
        }
    }
}
