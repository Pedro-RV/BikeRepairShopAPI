namespace Sale_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.string(maxLength: 20),
                        Surname = c.string(maxLength: 30),
                        Email = c.string(maxLength: 20),
                        ClientAddress = c.string(maxLength: 100),
                        CP = c.string(maxLength: 10),
                        MobileNum = c.string(maxLength: 15),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        PaymentMethodDescription = c.string(maxLength: 20),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductTypeId = c.Int(nullable: false),
                        ProductDescription = c.string(maxLength: 500),
                        Prize = c.Double(nullable: false),
                        Cuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductType", t => t.ProductTypeId, cascadeDelete: true)
                .Index(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        ProductTypeDescription = c.string(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        Cuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.Shipping",
                c => new
                    {
                        ShippingId = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        TransportCompanyId = c.Int(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        PackingTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingId)
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .ForeignKey("dbo.TransportCompany", t => t.TransportCompanyId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.TransportCompanyId);
            
            CreateTable(
                "dbo.TransportCompany",
                c => new
                    {
                        TransportCompanyId = c.Int(nullable: false, identity: true),
                        TransportCompanyName = c.string(maxLength: 100),
                        TelephoneNum = c.string(maxLength: 15),
                    })
                .PrimaryKey(t => t.TransportCompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipping", "TransportCompanyId", "dbo.TransportCompany");
            DropForeignKey("dbo.Shipping", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Sale", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Sale", "PaymentMethodId", "dbo.PaymentMethod");
            DropForeignKey("dbo.Sale", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType");
            DropIndex("dbo.Shipping", new[] { "TransportCompanyId" });
            DropIndex("dbo.Shipping", new[] { "SaleId" });
            DropIndex("dbo.Sale", new[] { "PaymentMethodId" });
            DropIndex("dbo.Sale", new[] { "ProductId" });
            DropIndex("dbo.Sale", new[] { "ClientId" });
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            DropTable("dbo.TransportCompany");
            DropTable("dbo.Shipping");
            DropTable("dbo.Sale");
            DropTable("dbo.ProductType");
            DropTable("dbo.Product");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Client");
        }
    }
}
