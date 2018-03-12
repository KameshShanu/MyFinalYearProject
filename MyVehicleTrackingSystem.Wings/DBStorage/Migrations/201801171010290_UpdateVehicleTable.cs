namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVehicleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "LicenseNumber", c => c.String());
            AddColumn("dbo.Vehicle", "LicenseExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "InsuranceNumber", c => c.String());
            AddColumn("dbo.Vehicle", "GoodsNumber", c => c.String());
            AddColumn("dbo.Vehicle", "GoodsExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "FirstRegistrationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "FireReportExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "CalibrationReportExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "EmissionTestExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "VehicleFitnessExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "DangerousLicenseNumber", c => c.String());
            AddColumn("dbo.Vehicle", "DangerousLicenseExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "VehicleDeliveryType", c => c.String());
            AddColumn("dbo.Vehicle", "GoodsType", c => c.String());
            AddColumn("dbo.Vehicle", "Quantity", c => c.String());
            DropColumn("dbo.Vehicle", "Owner");
            DropColumn("dbo.Vehicle", "OwnershipStatus");
            DropColumn("dbo.Vehicle", "VehicleType");
            DropColumn("dbo.Vehicle", "FuelType");
            DropColumn("dbo.Vehicle", "PurchaseDate");
            DropColumn("dbo.Vehicle", "Vendor");
            DropColumn("dbo.Vehicle", "Value");
            DropColumn("dbo.Vehicle", "Warranty");
            DropColumn("dbo.Vehicle", "NoOfYrWarranty");
            DropColumn("dbo.Vehicle", "WarrantyExpiryDate");
            DropColumn("dbo.Vehicle", "LeaseInformation");
            DropColumn("dbo.Vehicle", "Insurance");
            DropColumn("dbo.Vehicle", "License");
            DropColumn("dbo.Vehicle", "EmissionTest");
            DropColumn("dbo.Vehicle", "CurrentMeterReading");
            DropColumn("dbo.Vehicle", "InitialMeterReading");
            DropColumn("dbo.Vehicle", "LeaseAmount");
            DropColumn("dbo.Vehicle", "LeaseRental");
            DropColumn("dbo.Vehicle", "LeaseDueDate");
            DropColumn("dbo.Vehicle", "InsuranceCompany");
            DropColumn("dbo.Vehicle", "InsurancePolicyNo");
            DropColumn("dbo.Vehicle", "InsurancePremium");
            DropColumn("dbo.Vehicle", "OtherInfo");
            DropColumn("dbo.Vehicle", "TripId");
            DropTable("dbo.Client");
            DropTable("dbo.OperationType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OperationType",
                c => new
                    {
                        OperationTypeId = c.Int(nullable: false, identity: true),
                        OperationTypeName = c.String(),
                        ClientRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverCommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorterCommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OperationTypeId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        VAT = c.String(),
                        SVAT = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            AddColumn("dbo.Vehicle", "TripId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "OtherInfo", c => c.String());
            AddColumn("dbo.Vehicle", "InsurancePremium", c => c.String());
            AddColumn("dbo.Vehicle", "InsurancePolicyNo", c => c.String());
            AddColumn("dbo.Vehicle", "InsuranceCompany", c => c.String());
            AddColumn("dbo.Vehicle", "LeaseDueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "LeaseRental", c => c.String());
            AddColumn("dbo.Vehicle", "LeaseAmount", c => c.String());
            AddColumn("dbo.Vehicle", "InitialMeterReading", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "CurrentMeterReading", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "EmissionTest", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "License", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "Insurance", c => c.String());
            AddColumn("dbo.Vehicle", "LeaseInformation", c => c.String());
            AddColumn("dbo.Vehicle", "WarrantyExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "NoOfYrWarranty", c => c.String());
            AddColumn("dbo.Vehicle", "Warranty", c => c.String());
            AddColumn("dbo.Vehicle", "Value", c => c.String());
            AddColumn("dbo.Vehicle", "Vendor", c => c.String());
            AddColumn("dbo.Vehicle", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "FuelType", c => c.String());
            AddColumn("dbo.Vehicle", "VehicleType", c => c.String());
            AddColumn("dbo.Vehicle", "OwnershipStatus", c => c.String());
            AddColumn("dbo.Vehicle", "Owner", c => c.String());
            DropColumn("dbo.Vehicle", "Quantity");
            DropColumn("dbo.Vehicle", "GoodsType");
            DropColumn("dbo.Vehicle", "VehicleDeliveryType");
            DropColumn("dbo.Vehicle", "DangerousLicenseExpDate");
            DropColumn("dbo.Vehicle", "DangerousLicenseNumber");
            DropColumn("dbo.Vehicle", "VehicleFitnessExpDate");
            DropColumn("dbo.Vehicle", "EmissionTestExpDate");
            DropColumn("dbo.Vehicle", "CalibrationReportExpDate");
            DropColumn("dbo.Vehicle", "FireReportExpDate");
            DropColumn("dbo.Vehicle", "FirstRegistrationDate");
            DropColumn("dbo.Vehicle", "GoodsExpDate");
            DropColumn("dbo.Vehicle", "GoodsNumber");
            DropColumn("dbo.Vehicle", "InsuranceNumber");
            DropColumn("dbo.Vehicle", "LicenseExpDate");
            DropColumn("dbo.Vehicle", "LicenseNumber");
        }
    }
}
