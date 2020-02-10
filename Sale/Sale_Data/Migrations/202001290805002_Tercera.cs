namespace Sale_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tercera : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sale", "PaymentMethodId", "dbo.PaymentMethod");
            DropIndex("dbo.Sale", new[] { "PaymentMethodId" });
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        PaymentMethodId = c.Int(nullable: false),
                        BillDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethodId, cascadeDelete: true)
                .Index(t => t.PaymentMethodId);
            
            AddColumn("dbo.Sale", "BillId", c => c.Int(nullable: false));
            AlterColumn("dbo.PaymentMethod", "PaymentMethodDescription", c => c.string(maxLength: 70));
            AlterColumn("dbo.ProductType", "ProductTypeDescription", c => c.string(maxLength: 100));
            CreateIndex("dbo.Sale", "BillId");
            AddForeignKey("dbo.Sale", "BillId", "dbo.Bill", "BillId", cascadeDelete: true);
            DropColumn("dbo.Sale", "PaymentMethodId");
            DropColumn("dbo.Sale", "SaleDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sale", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sale", "PaymentMethodId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sale", "BillId", "dbo.Bill");
            DropForeignKey("dbo.Bill", "PaymentMethodId", "dbo.PaymentMethod");
            DropIndex("dbo.Sale", new[] { "BillId" });
            DropIndex("dbo.Bill", new[] { "PaymentMethodId" });
            AlterColumn("dbo.ProductType", "ProductTypeDescription", c => c.string(maxLength: 50));
            AlterColumn("dbo.PaymentMethod", "PaymentMethodDescription", c => c.string(maxLength: 20));
            DropColumn("dbo.Sale", "BillId");
            DropTable("dbo.Bill");
            CreateIndex("dbo.Sale", "PaymentMethodId");
            AddForeignKey("dbo.Sale", "PaymentMethodId", "dbo.PaymentMethod", "PaymentMethodId", cascadeDelete: true);
        }
    }
}
