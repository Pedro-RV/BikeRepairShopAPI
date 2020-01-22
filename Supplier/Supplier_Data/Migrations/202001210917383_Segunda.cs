namespace Supplier_Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segunda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SupplyCompany", "SupplyCompanyName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SupplyCompany", "SupplyCompanyName", c => c.String(maxLength: 30));
        }
    }
}
