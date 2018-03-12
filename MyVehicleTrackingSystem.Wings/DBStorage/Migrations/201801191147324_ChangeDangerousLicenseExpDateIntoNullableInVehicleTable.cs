namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDangerousLicenseExpDateIntoNullableInVehicleTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicle", "DangerousLicenseExpDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "DangerousLicenseExpDate", c => c.DateTime(nullable: false));
        }
    }
}
