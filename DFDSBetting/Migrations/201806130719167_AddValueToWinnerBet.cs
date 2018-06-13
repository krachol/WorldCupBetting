namespace DFDSBetting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValueToWinnerBet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WinnerBets", "Value", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WinnerBets", "Value");
        }
    }
}
