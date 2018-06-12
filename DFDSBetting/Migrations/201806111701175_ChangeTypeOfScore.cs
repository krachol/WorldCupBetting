namespace DFDSBetting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeOfScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "HomeTeamScore", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "AwayTeamScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "AwayTeamScore");
            DropColumn("dbo.Matches", "HomeTeamScore");
        }
    }
}
