namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicandMinimumSalaryColumnsToDriverTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Driver", "BasicSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Driver", "MinimumSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Driver", "MinimumSalary");
            DropColumn("dbo.Driver", "BasicSalary");
        }
    }
}
