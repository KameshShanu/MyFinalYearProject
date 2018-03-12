namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextChangeErrorResolve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Driver", "PoliceReportExpiryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Driver", "PoliceReportExpiryDate");
        }
    }
}
