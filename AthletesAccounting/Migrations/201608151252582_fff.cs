namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Couches", "sport_code", "dbo.Sports");
            DropForeignKey("dbo.MainSports", "sport_code", "dbo.Sports");
            DropForeignKey("dbo.Athletes", "sport_code", "dbo.Sports");
            DropPrimaryKey("dbo.Sports");
            AlterColumn("dbo.Sports", "sports_code", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Sports", "sports_code");
            AddForeignKey("dbo.Couches", "sport_code", "dbo.Sports", "sports_code", cascadeDelete: true);
            AddForeignKey("dbo.MainSports", "sport_code", "dbo.Sports", "sports_code", cascadeDelete: true);
            AddForeignKey("dbo.Athletes", "sport_code", "dbo.Sports", "sports_code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "sport_code", "dbo.Sports");
            DropForeignKey("dbo.MainSports", "sport_code", "dbo.Sports");
            DropForeignKey("dbo.Couches", "sport_code", "dbo.Sports");
            DropPrimaryKey("dbo.Sports");
            AlterColumn("dbo.Sports", "sports_code", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Sports", "sports_code");
            AddForeignKey("dbo.Athletes", "sport_code", "dbo.Sports", "sports_code");
            AddForeignKey("dbo.MainSports", "sport_code", "dbo.Sports", "sports_code", cascadeDelete: true);
            AddForeignKey("dbo.Couches", "sport_code", "dbo.Sports", "sports_code", cascadeDelete: true);
        }
    }
}
