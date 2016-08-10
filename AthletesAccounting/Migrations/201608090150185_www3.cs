namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class www3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "nameOrg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "nameOrg");
        }
    }
}
