namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Couches",
                c => new
                    {
                        id_couch = c.Int(nullable: false),
                        fam = c.String(),
                        name = c.String(),
                        parent = c.String(),
                        sport_code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_couch)
                .ForeignKey("dbo.Sports", t => t.sport_code, cascadeDelete: true)
                .Index(t => t.sport_code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Couches", "sport_code", "dbo.Sports");
            DropIndex("dbo.Couches", new[] { "sport_code" });
            DropTable("dbo.Couches");
        }
    }
}
