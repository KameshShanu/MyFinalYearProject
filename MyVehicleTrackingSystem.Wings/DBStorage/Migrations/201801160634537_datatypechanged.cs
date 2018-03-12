namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Helper", "PeriodOfService", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Helper", "PeriodOfService", c => c.DateTime(nullable: false));
        }
    }
}
