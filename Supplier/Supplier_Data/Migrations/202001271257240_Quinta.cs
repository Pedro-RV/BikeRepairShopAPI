namespace Supplier_Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quinta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductInfo", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductInfo", "ProductStateId", "dbo.ProductState");
            DropForeignKey("dbo.ProductInfo", "WarehouseId", "dbo.Warehouse");
            DropIndex("dbo.ProductInfo", new[] { "ProductId" });
            DropIndex("dbo.ProductInfo", new[] { "WarehouseId" });
            DropIndex("dbo.ProductInfo", new[] { "ProductStateId" });
            CreateTable(
                "dbo.WarehouseProduct",
                c => new
                    {
                        WarehouseProductId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        ProductStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseProductId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductState", t => t.ProductStateId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductStateId);
            
            DropTable("dbo.ProductInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductInfo",
                c => new
                    {
                        ProductInfoId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        ProductStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductInfoId);
            
            DropForeignKey("dbo.WarehouseProduct", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.WarehouseProduct", "ProductStateId", "dbo.ProductState");
            DropForeignKey("dbo.WarehouseProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.WarehouseProduct", new[] { "ProductStateId" });
            DropIndex("dbo.WarehouseProduct", new[] { "WarehouseId" });
            DropIndex("dbo.WarehouseProduct", new[] { "ProductId" });
            DropTable("dbo.WarehouseProduct");
            CreateIndex("dbo.ProductInfo", "ProductStateId");
            CreateIndex("dbo.ProductInfo", "WarehouseId");
            CreateIndex("dbo.ProductInfo", "ProductId");
            AddForeignKey("dbo.ProductInfo", "WarehouseId", "dbo.Warehouse", "WarehouseId", cascadeDelete: true);
            AddForeignKey("dbo.ProductInfo", "ProductStateId", "dbo.ProductState", "ProductStateId", cascadeDelete: true);
            AddForeignKey("dbo.ProductInfo", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
    }
}
