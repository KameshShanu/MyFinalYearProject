namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldsToClientTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "ClientRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Client", "DriverCommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Client", "PorterCommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Client", "OperationType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "OperationType");
            DropColumn("dbo.Client", "PorterCommissionRate");
            DropColumn("dbo.Client", "DriverCommissionRate");
            DropColumn("dbo.Client", "ClientRate");
        }
    }
}
