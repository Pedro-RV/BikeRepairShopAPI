namespace Supplier_Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cuarta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ProductStateId", "dbo.ProductState");
            DropForeignKey("dbo.Product", "WarehouseId", "dbo.Warehouse");
            DropIndex("dbo.Product", new[] { "WarehouseId" });
            DropIndex("dbo.Product", new[] { "ProductStateId" });
            CreateTable(
                "dbo.ProductInfo",
                c => new
                    {
                        ProductInfoId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        ProductStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductInfoId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductState", t => t.ProductStateId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductStateId);
            
            AddColumn("dbo.Product", "ActiveFlag", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Product", "ProductDescription", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInfo", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.ProductInfo", "ProductStateId", "dbo.ProductState");
            DropForeignKey("dbo.ProductInfo", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductInfo", new[] { "ProductStateId" });
            DropIndex("dbo.ProductInfo", new[] { "WarehouseId" });
            DropIndex("dbo.ProductInfo", new[] { "ProductId" });
            AlterColumn("dbo.Product", "ProductDescription", c => c.String(maxLength: 100));
            DropColumn("dbo.Product", "ActiveFlag");
            DropTable("dbo.ProductInfo");
            CreateIndex("dbo.Product", "ProductStateId");
            CreateIndex("dbo.Product", "WarehouseId");
            AddForeignKey("dbo.Product", "WarehouseId", "dbo.Warehouse", "WarehouseId", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductStateId", "dbo.ProductState", "ProductStateId", cascadeDelete: true);
        }
    }
}
