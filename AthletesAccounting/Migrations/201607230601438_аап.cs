namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class аап : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athletes", "id_couch", c => c.Int());
            CreateIndex("dbo.Athletes", "id_couch");
            AddForeignKey("dbo.Athletes", "id_couch", "dbo.Couches", "id_couch");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "id_couch", "dbo.Couches");
            DropIndex("dbo.Athletes", new[] { "id_couch" });
            DropColumn("dbo.Athletes", "id_couch");
        }
    }
}
