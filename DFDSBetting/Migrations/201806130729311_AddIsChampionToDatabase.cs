namespace DFDSBetting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsChampionToDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "IsChampion", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "IsChampion");
        }
    }
}
