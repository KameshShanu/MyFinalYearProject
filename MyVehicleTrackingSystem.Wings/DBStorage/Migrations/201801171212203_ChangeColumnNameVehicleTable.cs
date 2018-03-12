namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNameVehicleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "InsuranceExpDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vehicle", "InsuranceDueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "InsuranceDueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vehicle", "InsuranceExpDate");
        }
    }
}
