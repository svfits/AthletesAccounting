namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Athletes", "id_AnthropometricData", "dbo.AnthropometricDatas");
            DropIndex("dbo.Athletes", new[] { "id_AnthropometricData" });
            DropColumn("dbo.Athletes", "id_AnthropometricData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Athletes", "id_AnthropometricData", c => c.Int());
            CreateIndex("dbo.Athletes", "id_AnthropometricData");
            AddForeignKey("dbo.Athletes", "id_AnthropometricData", "dbo.AnthropometricDatas", "id");
        }
    }
}
