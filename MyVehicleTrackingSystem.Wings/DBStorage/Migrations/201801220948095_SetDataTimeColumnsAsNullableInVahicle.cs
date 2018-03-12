namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDataTimeColumnsAsNullableInVahicle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicle", "LicenseExpDate", c => c.DateTime());
            AlterColumn("dbo.Vehicle", "InsuranceExpDate", c => c.DateTime());
            AlterColumn("dbo.Vehicle", "GoodsExpDate", c => c.DateTime());
            AlterColumn("dbo.Vehicle", "FirstRegistrationDate", c => c.DateTime());
            AlterColumn("dbo.Vehicle", "FireReportExpDate", c => c.DateTime());
            AlterColumn("dbo.Vehicle", "CalibrationReportExpDate", c => c.DateTime());
            AlterColumn("dbo.Vehicle", "EmissionTestExpDate", c => c.DateTime());
            AlterColumn("dbo.Vehicle", "VehicleFitnessExpDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "VehicleFitnessExpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "EmissionTestExpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "CalibrationReportExpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "FireReportExpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "FirstRegistrationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "GoodsExpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "InsuranceExpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "LicenseExpDate", c => c.DateTime(nullable: false));
        }
    }
}
