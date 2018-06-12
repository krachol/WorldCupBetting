namespace DFDSBetting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePlaceFromWinner1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "FlagUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "FlagUrl");
        }
    }
}
