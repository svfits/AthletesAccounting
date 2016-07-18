namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AthletesAccounting1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athletes", "notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Athletes", "notes");
        }
    }
}
