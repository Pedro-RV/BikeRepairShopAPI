namespace Supplier_Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class Primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 20),
                        Surname = c.String(maxLength: 30),
                        DNI = c.String(maxLength: 15),
                        Email = c.String(maxLength: 20),
                        EmployeeAddress = c.String(maxLength: 100),
                        CP = c.String(maxLength: 10),
                        MobileNum = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        ProductStateId = c.Int(nullable: false),
                        ProductDescription = c.String(maxLength: 100),
                        Prize = c.Double(nullable: false),
                        Cuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductState", t => t.ProductStateId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductStateId);
            
            CreateTable(
                "dbo.ProductState",
                c => new
                    {
                        ProductStateId = c.Int(nullable: false, identity: true),
                        ProductStateDescription = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductStateId);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false, identity: true),
                        WarehouseAdminId = c.Int(nullable: false),
                        WarehouseAddress = c.String(maxLength: 100),
                        Extension = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseId)
                .ForeignKey("dbo.WarehouseAdmin", t => t.WarehouseAdminId, cascadeDelete: true)
                .Index(t => t.WarehouseAdminId);
            
            CreateTable(
                "dbo.WarehouseAdmin",
                c => new
                    {
                        WarehouseAdminId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseAdminId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SupplyCompanyId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Cuantity = c.Int(nullable: false),
                        Prize = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SupplyCompany", t => t.SupplyCompanyId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SupplyCompanyId);
            
            CreateTable(
                "dbo.SupplyCompany",
                c => new
                    {
                        SupplyCompanyId = c.Int(nullable: false, identity: true),
                        SupplyCompanyName = c.String(maxLength: 30),
                        TelephoneNum = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.SupplyCompanyId);


            string path = Path.GetFullPath("../../");
            string sqlFile = path + "CrearEmpleado_Supplier_CodeFirst.sql";
            Sql(File.ReadAllText(sqlFile));

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "SupplyCompanyId", "dbo.SupplyCompany");
            DropForeignKey("dbo.Purchase", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.Warehouse", "WarehouseAdminId", "dbo.WarehouseAdmin");
            DropForeignKey("dbo.WarehouseAdmin", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Product", "ProductStateId", "dbo.ProductState");
            DropIndex("dbo.Purchase", new[] { "SupplyCompanyId" });
            DropIndex("dbo.Purchase", new[] { "ProductId" });
            DropIndex("dbo.WarehouseAdmin", new[] { "EmployeeId" });
            DropIndex("dbo.Warehouse", new[] { "WarehouseAdminId" });
            DropIndex("dbo.Product", new[] { "ProductStateId" });
            DropIndex("dbo.Product", new[] { "WarehouseId" });
            DropTable("dbo.SupplyCompany");
            DropTable("dbo.Purchase");
            DropTable("dbo.WarehouseAdmin");
            DropTable("dbo.Warehouse");
            DropTable("dbo.ProductState");
            DropTable("dbo.Product");
            DropTable("dbo.Employee");
        }
    }
}
