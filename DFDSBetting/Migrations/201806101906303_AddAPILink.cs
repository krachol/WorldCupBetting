namespace DFDSBetting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAPILink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "ApiLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "ApiLink");
        }
    }
}
