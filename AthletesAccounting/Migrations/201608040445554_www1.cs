namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class www1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Templates", "templateFilename", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Templates", "templateFilename");
        }
    }
}
