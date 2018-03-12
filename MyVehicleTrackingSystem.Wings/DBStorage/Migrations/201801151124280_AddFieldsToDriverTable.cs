namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToDriverTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Driver", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Driver", "ContactNumber1", c => c.String());
            AddColumn("dbo.Driver", "ContactNumber2", c => c.String());
            AddColumn("dbo.Driver", "DateOfExpiryLicense", c => c.DateTime(nullable: false));
            AddColumn("dbo.Driver", "DefensiveLicenseNumber", c => c.String());
            AddColumn("dbo.Driver", "DefensiveLicenseExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Driver", "DriverGrade", c => c.String());
            AddColumn("dbo.Driver", "StartDateOfWork", c => c.DateTime(nullable: false));
            AddColumn("dbo.Driver", "PeriodOfService", c => c.String());
            DropColumn("dbo.Driver", "PhoneNumber1");
            DropColumn("dbo.Driver", "PhoneNumber2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Driver", "PhoneNumber2", c => c.String());
            AddColumn("dbo.Driver", "PhoneNumber1", c => c.String());
            DropColumn("dbo.Driver", "PeriodOfService");
            DropColumn("dbo.Driver", "StartDateOfWork");
            DropColumn("dbo.Driver", "DriverGrade");
            DropColumn("dbo.Driver", "DefensiveLicenseExpiryDate");
            DropColumn("dbo.Driver", "DefensiveLicenseNumber");
            DropColumn("dbo.Driver", "DateOfExpiryLicense");
            DropColumn("dbo.Driver", "ContactNumber2");
            DropColumn("dbo.Driver", "ContactNumber1");
            DropColumn("dbo.Driver", "DateOfBirth");
        }
    }
}
