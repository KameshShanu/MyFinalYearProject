namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDangerousLicenseNumberFromVehcileTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicle", "DangerousLicenseNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "DangerousLicenseNumber", c => c.String());
        }
    }
}
