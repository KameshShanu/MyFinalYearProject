namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDieselLitersColumnToVehcleMaintenanceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleMaintenance", "DieselLiters", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleMaintenance", "DieselLiters");
        }
    }
}
