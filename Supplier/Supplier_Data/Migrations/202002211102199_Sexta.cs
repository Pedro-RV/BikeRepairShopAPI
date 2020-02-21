namespace Supplier_Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sexta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        ProductTypeDescription = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductTypeId);
            
            AddColumn("dbo.Product", "ProductTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "ProductTypeId");
            AddForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType", "ProductTypeId", cascadeDelete: true);
            DropColumn("dbo.Product", "WarehouseId");
            DropColumn("dbo.Product", "ProductStateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductStateId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "WarehouseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType");
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            DropColumn("dbo.Product", "ProductTypeId");
            DropTable("dbo.ProductType");
        }
    }
}
