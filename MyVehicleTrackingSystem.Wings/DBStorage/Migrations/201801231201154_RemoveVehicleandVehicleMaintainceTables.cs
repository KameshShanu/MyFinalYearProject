namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveVehicleandVehicleMaintainceTables : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VehicleMaintenance");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleMaintenance",
                c => new
                    {
                        VehicleMaintenanceId = c.Int(nullable: false, identity: true),
                        MaintenanceDate = c.DateTime(nullable: false),
                        MaintenanceDescription = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleNumber = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleMaintenanceId);
            
        }
    }
}
