namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AthletesAccounting : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Athletes", name: "mainSport_code", newName: "mainSport_id");
            RenameIndex(table: "dbo.Athletes", name: "IX_mainSport_code", newName: "IX_mainSport_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Athletes", name: "IX_mainSport_id", newName: "IX_mainSport_code");
            RenameColumn(table: "dbo.Athletes", name: "mainSport_id", newName: "mainSport_code");
        }
    }
}
