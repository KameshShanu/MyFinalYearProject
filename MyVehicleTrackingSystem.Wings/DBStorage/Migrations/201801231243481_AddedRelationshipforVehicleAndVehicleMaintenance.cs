namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipforVehicleAndVehicleMaintenance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMaintenance",
                c => new
                    {
                        VehicleMaintenanceId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        MaintenanceDate = c.DateTime(nullable: false),
                        MaintenanceDescription = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleNumber = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleMaintenanceId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleMaintenance", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.VehicleMaintenance", new[] { "VehicleId" });
            DropTable("dbo.VehicleMaintenance");
        }
    }
}
