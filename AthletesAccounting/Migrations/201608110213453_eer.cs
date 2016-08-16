namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AnthropometricDatas", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnthropometricDatas", "Age", c => c.Int(nullable: false));
        }
    }
}
