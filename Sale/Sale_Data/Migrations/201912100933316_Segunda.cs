namespace Sale_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segunda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "DNI", c => c.string(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "DNI");
        }
    }
}
