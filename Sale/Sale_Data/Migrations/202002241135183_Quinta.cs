namespace Sale_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quinta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sale", "CuantityToPay", c => c.Int(nullable: false));
            AddColumn("dbo.Sale", "ProductCuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Sale", "Cuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sale", "Cuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Sale", "ProductCuantity");
            DropColumn("dbo.Sale", "CuantityToPay");
        }
    }
}
