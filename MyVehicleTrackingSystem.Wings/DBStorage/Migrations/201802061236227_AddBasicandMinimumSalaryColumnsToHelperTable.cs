namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicandMinimumSalaryColumnsToHelperTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Helper", "Name", c => c.String());
            AddColumn("dbo.Helper", "BasicSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Helper", "MinimumSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Driver", "PoliceReportExpiryDate");
            DropColumn("dbo.Helper", "HelperFirstName");
            DropColumn("dbo.Helper", "HelperLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Helper", "HelperLastName", c => c.String());
            AddColumn("dbo.Helper", "HelperFirstName", c => c.String());
            AddColumn("dbo.Driver", "PoliceReportExpiryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Helper", "MinimumSalary");
            DropColumn("dbo.Helper", "BasicSalary");
            DropColumn("dbo.Helper", "Name");
        }
    }
}
