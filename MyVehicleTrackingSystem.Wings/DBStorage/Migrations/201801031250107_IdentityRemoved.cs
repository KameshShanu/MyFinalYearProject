namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityRemoved : DbMigration
    {
        public override void Up()
        {
        //    CreateTable(
        //        "dbo.AdvertisementCategory",
        //        c => new
        //            {
        //                CategoryId = c.Int(nullable: false, identity: true),
        //                CategoryName = c.String(),
        //                OrderId = c.Int(nullable: false),
        //                FileURL = c.String(),
        //                FileType = c.String(),
        //                CreatedDate = c.String(),
        //                ModifiedDate = c.String(),
        //                IsModified = c.Boolean(nullable: false),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.CategoryId);
            
        //    CreateTable(
        //        "dbo.AdvertisementItem",
        //        c => new
        //            {
        //                ItemId = c.Int(nullable: false, identity: true),
        //                CategoryId = c.Int(nullable: false),
        //                ItemName = c.String(),
        //                OrderId = c.Int(nullable: false),
        //                FileURL = c.String(),
        //                FileType = c.String(),
        //                CreatedDate = c.String(),
        //                ModifiedDate = c.String(),
        //                IsModified = c.Boolean(nullable: false),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.ItemId)
        //        .ForeignKey("dbo.AdvertisementCategory", t => t.CategoryId, cascadeDelete: true)
        //        .Index(t => t.CategoryId);
            
        //    CreateTable(
        //        "dbo.ArchiveTrip",
        //        c => new
        //            {
        //                ArchiveTripId = c.Int(nullable: false, identity: true),
        //                TripId = c.Int(nullable: false),
        //                PackageId = c.Int(),
        //                PaymentType = c.String(),
        //                VehicleId = c.Int(),
        //                VehicleNumber = c.String(),
        //                DriverId = c.Int(),
        //                DriverName = c.String(),
        //                GuestName = c.String(),
        //                RoomNumber = c.String(),
        //                MeterReadingIn = c.Int(),
        //                MeterReadingOut = c.Int(),
        //                MeterReadingInGps = c.Int(),
        //                MeterReadingOutGps = c.Int(),
        //                MeterReadingInStatus = c.String(),
        //                MeterReadingOutStatus = c.String(),
        //                Amount = c.Decimal(precision: 18, scale: 2),
        //                PackageCost = c.Decimal(precision: 18, scale: 2),
        //                AdditionalKmCost = c.Decimal(precision: 18, scale: 2),
        //                WaitingHourCost = c.Decimal(precision: 18, scale: 2),
        //                IsOpen = c.Boolean(),
        //                IsRemoved = c.Boolean(),
        //                IsDeleted = c.Boolean(),
        //                PassengerType = c.String(),
        //                PassengerTypeList = c.String(),
        //                TimeIn = c.DateTime(),
        //                TimeOut = c.DateTime(),
        //                TripDuration = c.String(),
        //                PaymentDateTime = c.DateTime(),
        //                Remarks = c.String(),
        //                AdditionalKM = c.Int(),
        //                WaitedHrs = c.Int(),
        //                VoucherNumber = c.String(),
        //                DispatchedHotel = c.String(),
        //                Createdby = c.String(),
        //                Updatedby = c.String(),
        //                TripMileage = c.Int(nullable: false),
        //                MeterReadingInGap = c.Int(),
        //                MeterReadingOutGap = c.Int(),
        //                PaymentCategory = c.String(),
        //                CorporateName = c.String(),
        //                ReservationNo = c.String(),
        //                IsCustomPackage = c.Boolean(),
        //                IsArchive = c.Boolean(),
        //                IsReopened = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.ArchiveTripId);
            
        //    CreateTable(
        //        "dbo.BataRate",
        //        c => new
        //            {
        //                BataId = c.Int(nullable: false, identity: true),
        //                Description = c.String(),
        //                Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.BataId);
            
        //    CreateTable(
        //        "dbo.Corporate",
        //        c => new
        //            {
        //                CorporateId = c.Int(nullable: false, identity: true),
        //                CorporateName = c.String(),
        //                CorporateDetails = c.String(),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.CorporateId);
            
        //    CreateTable(
        //        "dbo.CustomBata",
        //        c => new
        //            {
        //                CustomBataId = c.Int(nullable: false, identity: true),
        //                TripId = c.Int(nullable: false),
        //                CustomAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.CustomBataId)
        //        .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
        //        .Index(t => t.TripId);
            
        //    CreateTable(
        //        "dbo.Trip",
        //        c => new
        //            {
        //                TripId = c.Int(nullable: false, identity: true),
        //                PackageId = c.Int(nullable: false),
        //                PaymentType = c.String(),
        //                CustomerId = c.Int(nullable: false),
        //                VehicleId = c.Int(nullable: false),
        //                VehicleNumber = c.String(),
        //                DriverId = c.Int(nullable: false),
        //                DriverName = c.String(),
        //                GuestName = c.String(),
        //                RoomNumber = c.String(),
        //                MeterReadingIn = c.Int(nullable: false),
        //                MeterReadingOut = c.Int(nullable: false),
        //                MeterReadingInGps = c.Int(nullable: false),
        //                MeterReadingOutGps = c.Int(nullable: false),
        //                MeterReadingInStatus = c.String(),
        //                MeterReadingOutStatus = c.String(),
        //                Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                PackageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                AdditionalKmCost = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                WaitingHourCost = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                IsOpen = c.Boolean(nullable: false),
        //                IsRemoved = c.Boolean(nullable: false),
        //                IsDeleted = c.Boolean(nullable: false),
        //                IsReopened = c.Boolean(nullable: false),
        //                PassengerType = c.String(),
        //                PassengerTypeList = c.String(),
        //                TimeIn = c.DateTime(nullable: false),
        //                TimeOut = c.DateTime(nullable: false),
        //                TripDuration = c.String(),
        //                PaymentDateTime = c.DateTime(nullable: false),
        //                Remarks = c.String(),
        //                AdditionalKM = c.Int(nullable: false),
        //                WaitedHrs = c.Int(nullable: false),
        //                VoucherNumber = c.String(),
        //                DispatchedHotel = c.String(),
        //                Createdby = c.String(),
        //                Updatedby = c.String(),
        //                TripMileage = c.Int(nullable: false),
        //                MeterReadingInGap = c.Int(nullable: false),
        //                MeterReadingOutGap = c.Int(nullable: false),
        //                PaymentCategory = c.String(),
        //                CorporateName = c.String(),
        //                ReservationNo = c.String(),
        //                IsCustomPackage = c.Boolean(nullable: false),
        //                IsArchive = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.TripId)
        //        .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
        //        .ForeignKey("dbo.Driver", t => t.DriverId, cascadeDelete: true)
        //        .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
        //        .Index(t => t.CustomerId)
        //        .Index(t => t.VehicleId)
        //        .Index(t => t.DriverId);
            
        //    CreateTable(
        //        "dbo.Customer",
        //        c => new
        //            {
        //                CustomerId = c.Int(nullable: false, identity: true),
        //                UserId = c.String(),
        //                FirstName = c.String(),
        //                LastName = c.String(),
        //                PhoneNumber = c.String(),
        //                Email = c.String(),
        //                Address = c.String(),
        //                TripCount = c.Int(nullable: false),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.CustomerId);
            
        //    CreateTable(
        //        "dbo.Driver",
        //        c => new
        //            {
        //                DriverId = c.Int(nullable: false, identity: true),
        //                ApplicationUserId = c.String(),
        //                EmpNumber = c.String(),
        //                FirstName = c.String(),
        //                LastName = c.String(),
        //                Email = c.String(),
        //                PixURL = c.String(),
        //                NIC = c.String(),
        //                HomeAddress = c.String(),
        //                ResidentAddress = c.String(),
        //                PhoneNumber1 = c.String(),
        //                PhoneNumber2 = c.String(),
        //                PhoneNumber3 = c.String(),
        //                DLNumber = c.String(),
        //                EPFNumber = c.String(),
        //                IsDeleted = c.Boolean(nullable: false),
        //                EmpStatus = c.Int(nullable: false),
        //                MaritalStatus = c.Int(nullable: false),
        //                TripId = c.Int(nullable: false),
        //                IsAvailable = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.DriverId);
            
        //    CreateTable(
        //        "dbo.PackagesList",
        //        c => new
        //            {
        //                PackageId = c.Int(nullable: false, identity: true),
        //                TripId = c.Int(nullable: false),
        //                PreDefineTripName = c.String(),
        //                Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.PackageId)
        //        .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
        //        .Index(t => t.TripId);
            
        //    CreateTable(
        //        "dbo.TripBata",
        //        c => new
        //            {
        //                BataRateId = c.Int(nullable: false, identity: true),
        //                TripId = c.Int(nullable: false),
        //                Description = c.String(),
        //                Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.BataRateId)
        //        .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
        //        .Index(t => t.TripId);
            
        //    CreateTable(
        //        "dbo.Vehicle",
        //        c => new
        //            {
        //                VehicleId = c.Int(nullable: false, identity: true),
        //                VehicleNumber = c.String(),
        //                Owner = c.String(),
        //                IsDeleted = c.Boolean(nullable: false),
        //                OwnershipStatus = c.String(),
        //                VehicleType = c.String(),
        //                VehicleMake = c.String(),
        //                VehicleModel = c.String(),
        //                VehicleMFYear = c.String(),
        //                FuelType = c.String(),
        //                EngineNumber = c.String(),
        //                ChassisNumber = c.String(),
        //                PurchaseDate = c.DateTime(nullable: false),
        //                Vendor = c.String(),
        //                Value = c.String(),
        //                Warranty = c.String(),
        //                NoOfYrWarranty = c.String(),
        //                WarrantyExpiryDate = c.DateTime(nullable: false),
        //                LeaseInformation = c.String(),
        //                Insurance = c.String(),
        //                License = c.DateTime(nullable: false),
        //                EmissionTest = c.DateTime(nullable: false),
        //                CurrentMeterReading = c.Int(nullable: false),
        //                InitialMeterReading = c.Int(nullable: false),
        //                LeaseAmount = c.String(),
        //                LeaseRental = c.String(),
        //                LeaseDueDate = c.DateTime(nullable: false),
        //                InsuranceCompany = c.String(),
        //                InsurancePolicyNo = c.String(),
        //                InsurancePremium = c.String(),
        //                InsuranceDueDate = c.DateTime(nullable: false),
        //                OtherInfo = c.String(),
        //                TripId = c.Int(nullable: false),
        //                IsAvailable = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.VehicleId);
            
        //    CreateTable(
        //        "dbo.PreDefineTrip",
        //        c => new
        //            {
        //                PreDefineTripId = c.Int(nullable: false, identity: true),
        //                PreDefineTripName = c.String(),
        //                TripType = c.String(),
        //                Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                VehicleType = c.String(),
        //                Distance = c.String(),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.PreDefineTripId);
            
        //    CreateTable(
        //        "dbo.Role",
        //        c => new
        //            {
        //                RoleId = c.Int(nullable: false, identity: true),
        //                RoleName = c.String(),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.RoleId);
            
        //    CreateTable(
        //        "dbo.User",
        //        c => new
        //            {
        //                UserId = c.Int(nullable: false, identity: true),
        //                IdentityUserId = c.String(),
        //                FirstName = c.String(),
        //                LastName = c.String(),
        //                Email = c.String(),
        //                Password = c.String(),
        //                PasswordSalt = c.String(),
        //                RoleId = c.Int(nullable: false),
        //                Role = c.String(),
        //                ContactNumber = c.String(),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.UserId)
        //        .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
        //        .Index(t => t.RoleId);
            
        //    CreateTable(
        //        "dbo.UserLog",
        //        c => new
        //            {
        //                LogId = c.Int(nullable: false, identity: true),
        //                LoggedUser = c.String(),
        //                LoggedMachineName = c.String(),
        //                Version = c.String(),
        //                TripId = c.Int(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.LogId);
            
        //    CreateTable(
        //        "dbo.VehicleRate",
        //        c => new
        //            {
        //                VehicleRateId = c.Int(nullable: false, identity: true),
        //                VehicleType = c.String(),
        //                FarePerKm = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                WaitingChargers = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                PassengerType = c.String(),
        //                IsDeleted = c.Boolean(nullable: false),
        //                Created = c.DateTime(nullable: false),
        //                Modified = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.VehicleRateId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            //DropForeignKey("dbo.CustomBata", "TripId", "dbo.Trip");
            //DropForeignKey("dbo.Trip", "VehicleId", "dbo.Vehicle");
            //DropForeignKey("dbo.TripBata", "TripId", "dbo.Trip");
            //DropForeignKey("dbo.PackagesList", "TripId", "dbo.Trip");
            //DropForeignKey("dbo.Trip", "DriverId", "dbo.Driver");
            //DropForeignKey("dbo.Trip", "CustomerId", "dbo.Customer");
            //DropForeignKey("dbo.AdvertisementItem", "CategoryId", "dbo.AdvertisementCategory");
            //DropIndex("dbo.User", new[] { "RoleId" });
            //DropIndex("dbo.TripBata", new[] { "TripId" });
            //DropIndex("dbo.PackagesList", new[] { "TripId" });
            //DropIndex("dbo.Trip", new[] { "DriverId" });
            //DropIndex("dbo.Trip", new[] { "VehicleId" });
            //DropIndex("dbo.Trip", new[] { "CustomerId" });
            //DropIndex("dbo.CustomBata", new[] { "TripId" });
            //DropIndex("dbo.AdvertisementItem", new[] { "CategoryId" });
            //DropTable("dbo.VehicleRate");
            //DropTable("dbo.UserLog");
            //DropTable("dbo.User");
            //DropTable("dbo.Role");
            //DropTable("dbo.PreDefineTrip");
            //DropTable("dbo.Vehicle");
            //DropTable("dbo.TripBata");
            //DropTable("dbo.PackagesList");
            //DropTable("dbo.Driver");
            //DropTable("dbo.Customer");
            //DropTable("dbo.Trip");
            //DropTable("dbo.CustomBata");
            //DropTable("dbo.Corporate");
            //DropTable("dbo.BataRate");
            //DropTable("dbo.ArchiveTrip");
            //DropTable("dbo.AdvertisementItem");
            //DropTable("dbo.AdvertisementCategory");
        }
    }
}
