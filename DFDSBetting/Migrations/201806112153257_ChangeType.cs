namespace DFDSBetting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScoreBets", "ScoreHome", c => c.Int(nullable: false));
            AddColumn("dbo.ScoreBets", "ScoreAway", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScoreBets", "ScoreAway");
            DropColumn("dbo.ScoreBets", "ScoreHome");
        }
    }
}
