namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientDriverPorterCommissionRatesToDispatchTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispatchNote", "ClientRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DispatchNote", "DriverCommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DispatchNote", "PorterCommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DispatchNote", "PorterCommissionRate");
            DropColumn("dbo.DispatchNote", "DriverCommissionRate");
            DropColumn("dbo.DispatchNote", "ClientRate");
        }
    }
}
