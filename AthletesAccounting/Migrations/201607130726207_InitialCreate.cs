namespace AthletesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fam = c.String(),
                        name = c.String(),
                        parent = c.String(),
                        sex = c.String(),
                        adress = c.String(),
                        telefon = c.String(),
                        PlaceofStudyAndWork = c.String(),
                        livingСonditions = c.String(),
                        sportTeam_code = c.Int(),
                        profAthlets = c.String(),
                        education_code = c.Int(),
                        alcohol = c.String(),
                        housing = c.String(),
                        smoke = c.String(),
                        pastIllnes = c.String(),
                        injuries = c.String(),
                        operations = c.String(),
                        sport_code = c.Int(),
                        rank_code = c.Int(),
                        DOB = c.DateTime(nullable: false),
                        mainSport_code = c.Int(),
                        otherSports = c.String(),
                        sportsGame = c.String(),
                        rankDateGet = c.String(),
                        DateGreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Educations", t => t.education_code)
                .ForeignKey("dbo.MainSports", t => t.mainSport_code)
                .ForeignKey("dbo.Ranks", t => t.rank_code)
                .ForeignKey("dbo.Sports", t => t.sport_code)
                .ForeignKey("dbo.SportTeams", t => t.sportTeam_code)
                .Index(t => t.sportTeam_code)
                .Index(t => t.education_code)
                .Index(t => t.sport_code)
                .Index(t => t.rank_code)
                .Index(t => t.mainSport_code);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        education_code = c.Int(nullable: false),
                        education = c.String(),
                    })
                .PrimaryKey(t => t.education_code);
            
            CreateTable(
                "dbo.MainSports",
                c => new
                    {
                        mainSport_id = c.Int(nullable: false, identity: true),
                        dateOnSports = c.DateTime(nullable: false),
                        sport_code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.mainSport_id)
                .ForeignKey("dbo.Sports", t => t.sport_code, cascadeDelete: true)
                .Index(t => t.sport_code);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        sports_code = c.Int(nullable: false),
                        sport = c.String(),
                    })
                .PrimaryKey(t => t.sports_code);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        rank_code = c.Int(nullable: false),
                        rank = c.String(),
                    })
                .PrimaryKey(t => t.rank_code);
            
            CreateTable(
                "dbo.SportTeams",
                c => new
                    {
                        sportTeam_code = c.Int(nullable: false),
                        sportTeam = c.String(),
                    })
                .PrimaryKey(t => t.sportTeam_code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "sportTeam_code", "dbo.SportTeams");
            DropForeignKey("dbo.Athletes", "sport_code", "dbo.Sports");
            DropForeignKey("dbo.Athletes", "rank_code", "dbo.Ranks");
            DropForeignKey("dbo.Athletes", "mainSport_code", "dbo.MainSports");
            DropForeignKey("dbo.MainSports", "sport_code", "dbo.Sports");
            DropForeignKey("dbo.Athletes", "education_code", "dbo.Educations");
            DropIndex("dbo.MainSports", new[] { "sport_code" });
            DropIndex("dbo.Athletes", new[] { "mainSport_code" });
            DropIndex("dbo.Athletes", new[] { "rank_code" });
            DropIndex("dbo.Athletes", new[] { "sport_code" });
            DropIndex("dbo.Athletes", new[] { "education_code" });
            DropIndex("dbo.Athletes", new[] { "sportTeam_code" });
            DropTable("dbo.SportTeams");
            DropTable("dbo.Ranks");
            DropTable("dbo.Sports");
            DropTable("dbo.MainSports");
            DropTable("dbo.Educations");
            DropTable("dbo.Athletes");
        }
    }
}
