namespace DFDSBetting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBetModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        Began = c.Boolean(nullable: false),
                        Finished = c.Boolean(nullable: false),
                        AwayTeam_Id = c.Guid(),
                        HomeTeam_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .Index(t => t.AwayTeam_Id)
                .Index(t => t.HomeTeam_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScoreBets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Match_Id = c.Guid(),
                        Placer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.Match_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Placer_Id)
                .Index(t => t.Match_Id)
                .Index(t => t.Placer_Id);
            
            CreateTable(
                "dbo.WinnerBets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Placer_Id = c.String(maxLength: 128),
                        Team_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Placer_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Placer_Id)
                .Index(t => t.Team_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WinnerBets", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.WinnerBets", "Placer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ScoreBets", "Placer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ScoreBets", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.Matches", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeam_Id", "dbo.Teams");
            DropIndex("dbo.WinnerBets", new[] { "Team_Id" });
            DropIndex("dbo.WinnerBets", new[] { "Placer_Id" });
            DropIndex("dbo.ScoreBets", new[] { "Placer_Id" });
            DropIndex("dbo.ScoreBets", new[] { "Match_Id" });
            DropIndex("dbo.Matches", new[] { "HomeTeam_Id" });
            DropIndex("dbo.Matches", new[] { "AwayTeam_Id" });
            DropTable("dbo.WinnerBets");
            DropTable("dbo.ScoreBets");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
        }
    }
}
