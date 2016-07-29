namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d1b : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        id_role = c.Int(nullable: false, identity: true),
                        name_role = c.String(),
                        description_role = c.String(),
                    })
                .PrimaryKey(t => t.id_role);
            
            AddColumn("dbo.Users", "id_role", c => c.Int());
            CreateIndex("dbo.Users", "id_role");
            AddForeignKey("dbo.Users", "id_role", "dbo.RoleUsers", "id_role");
            DropColumn("dbo.Users", "id_roles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "id_roles", c => c.Int());
            DropForeignKey("dbo.Users", "id_role", "dbo.RoleUsers");
            DropIndex("dbo.Users", new[] { "id_role" });
            DropColumn("dbo.Users", "id_role");
            DropTable("dbo.RoleUsers");
        }
    }
}
