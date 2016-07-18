namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AthletesAccounting2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athletes", "dateTimeNextProbe", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Athletes", "dateTimeNextProbe");
        }
    }
}
