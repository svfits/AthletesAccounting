namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class www : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        template = c.Binary(),
                        notesTemplate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Templates");
        }
    }
}
