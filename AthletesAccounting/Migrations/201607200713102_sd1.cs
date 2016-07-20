namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athletes", "id_AnthropometricData", c => c.Int());
            CreateIndex("dbo.Athletes", "id_AnthropometricData");
            AddForeignKey("dbo.Athletes", "id_AnthropometricData", "dbo.AnthropometricDatas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "id_AnthropometricData", "dbo.AnthropometricDatas");
            DropIndex("dbo.Athletes", new[] { "id_AnthropometricData" });
            DropColumn("dbo.Athletes", "id_AnthropometricData");
        }
    }
}
