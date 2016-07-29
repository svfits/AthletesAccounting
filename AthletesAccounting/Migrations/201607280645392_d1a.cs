namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d1a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "id_roles", c => c.Int());
            DropColumn("dbo.Users", "id_role");
            DropTable("dbo.RoleUsers");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Users", "id_role", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "id_roles");
        }
    }
}
