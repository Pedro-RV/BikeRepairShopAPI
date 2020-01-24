namespace Supplier_Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tercera : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Warehouse", "WarehouseAdminId", "dbo.WarehouseAdmin");
            DropIndex("dbo.Warehouse", new[] { "WarehouseAdminId" });
            AddColumn("dbo.WarehouseAdmin", "WarehouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.WarehouseAdmin", "WarehouseId");
            AddForeignKey("dbo.WarehouseAdmin", "WarehouseId", "dbo.Warehouse", "WarehouseId", cascadeDelete: true);
            DropColumn("dbo.Warehouse", "WarehouseAdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouse", "WarehouseAdminId", c => c.Int(nullable: false));
            DropForeignKey("dbo.WarehouseAdmin", "WarehouseId", "dbo.Warehouse");
            DropIndex("dbo.WarehouseAdmin", new[] { "WarehouseId" });
            DropColumn("dbo.WarehouseAdmin", "WarehouseId");
            CreateIndex("dbo.Warehouse", "WarehouseAdminId");
            AddForeignKey("dbo.Warehouse", "WarehouseAdminId", "dbo.WarehouseAdmin", "WarehouseAdminId", cascadeDelete: true);
        }
    }
}
