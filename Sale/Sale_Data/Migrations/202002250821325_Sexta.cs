namespace Sale_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sexta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sale", "CuantityToPay", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sale", "CuantityToPay", c => c.Int(nullable: false));
        }
    }
}
