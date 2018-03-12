using Domain.BataRates;
using Domain.Roles;
using Domain.Trips;
using Domain.Users;
using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DBStorage.Common
{
    public class WingsSeeder : DropCreateDatabaseIfModelChanges<WingsContext>
    {
        protected override void Seed(WingsContext context)
        {
            Role dispatcher = new Role()
            {
                RoleId = 2,
                RoleName = "Dispatcher",
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                Users = new List<User>()
                {
                    new User()
                    {
                        FirstName = "malshan",
                        LastName = "malshan",
                        Email = "malshan@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },
                    new User()
                    {
                        FirstName = "dilini",
                        LastName = "dilini",
                        Email = "dilini@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },
                     new User()
                    {
                        FirstName = "sachitra",
                        LastName = "sachitra",
                        Email = "sachitra@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },
                     new User()
                    {
                        FirstName = "yohan",
                        LastName = "yohan",
                        Email = "yohan@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },
                    new User()
                    {
                        FirstName = "darrell",
                        LastName = "darrell",
                        Email = "darrell@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },
                      new User()
                    {
                        FirstName = "sugeeth",
                        LastName = "sugeeth",
                        Email = "sugeeth@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },
                    new User()
                    {
                        FirstName = "diran",
                        LastName = "diran",
                        Email = "diran@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    }
                }
            };

            Role admin = new Role()
            {
                RoleId = 1,
                RoleName = "Admin",
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                Users = new List<User>()
                {
                    new User()
                    {
                        FirstName = "shanaka",
                        LastName = "shanaka",
                        Email = "shanaka@transcenddrive.com ", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },

                    new User()
                    {
                        FirstName = "cheyenne",
                        LastName = "cheyenne",
                        Email = "cheyenne@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },

                    new User()
                    {
                        FirstName = "prasad",
                        LastName = "prasad",
                        Email = "prasad@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },

                    new User()
                    {
                        FirstName = "roshan",
                        LastName = "roshan",
                        Email = "roshan@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    },
                    new User()
                    {
                        FirstName = "chaminda",
                        LastName = "chaminda",
                        Email = "chaminda@transcenddrive.com", // Username
                        Password = "User@123", // User@123
                        //PasswordSalt = "100000.YD4FrpXzZ1Dv3iUX3LZBCuvAYs/XkKCZkR9d2l0R5b6XnQ==",
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow
                    }
                }
            };

            Vehicle car = new Vehicle()
            {
                VehicleNumber = "HG-1234",
                ChassisNumber = "876ythgrsqwqee-wqwqsqe",
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                EmissionTestExpDate = DateTime.UtcNow,
                EngineNumber = "engine0098ythee",
                InsuranceNumber = "Ceylinco",
                InsuranceExpDate = DateTime.UtcNow,
                LicenseExpDate = DateTime.UtcNow,
                IsDeleted = false,
                //VehicleId = 001,
                VehicleMake = "Nissan",
                VehicleMFYear = "2000",
                VehicleModel = "Cefiro",
                VehicleDeliveryType = "Car"
            };

            Vehicle suv = new Vehicle()
            {
                VehicleNumber = "KG-7801",
                ChassisNumber = "876yth679hgjyqwqee-wqwqsqe",
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                EmissionTestExpDate = DateTime.UtcNow,
                EngineNumber = "engine009mnjythee",
                IsDeleted = false,
                InsuranceNumber = "Ceylinco",
                InsuranceExpDate = DateTime.UtcNow,
                LicenseExpDate = DateTime.UtcNow,
                //VehicleId = 001,
                VehicleMake = "Toyota",
                VehicleMFYear = "2008",
                VehicleModel = "Prado",
                VehicleDeliveryType = "SUV",
            };

            VehicleRate rateOne = new VehicleRate()
            {
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                IsDeleted = false,
                PassengerType = "Guest",
                FarePerKm = 85,
                WaitingChargers = 300,
                VehicleType = "Car"
            };

            VehicleRate rateTwo = new VehicleRate()
            {
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                IsDeleted = false,
                PassengerType = "Guest",
                FarePerKm = 100,
                WaitingChargers = 300,
                VehicleType = "SUV"
            };

            VehicleRate rateThree = new VehicleRate()
            {
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                IsDeleted = false,
                PassengerType = "Staff",
                FarePerKm = 70,
                WaitingChargers = 300,
                VehicleType = "Car/SUV"
            };

            PreDefineTrip tripOne = new PreDefineTrip()
            {
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                IsDeleted = false,
                VehicleType = "Car",
                Distance = "100",
                Rate = 2500,
                PreDefineTripName = "Odel, Alexandra Place"
            };

            PreDefineTrip tripTwo = new PreDefineTrip()
            {
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                IsDeleted = false,
                VehicleType = "SUV",
                Distance = "120",
                Rate = 4500,
                PreDefineTripName = "Airport, Katunayake"
            };

            Domain.Driver.Driver driverOne = new Domain.Driver.Driver()
            {
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                DLNumber = "gr23334!!334244rdewe**&32232",                
                EPFNumber = "16700982",
                Name = "Eranda Asiri",               
                IsDeleted = false,
                ResidentAddress = "Ratnapura",
                NIC = "907865434v",
                ContactNumber1 = "098767656",
                ContactNumber2 = "87876544356"           
            };

            Domain.Driver.Driver driverTwo = new Domain.Driver.Driver()
            {
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                DLNumber = "gr23334==-334244rdewe**&32232",              
                EPFNumber = "16704582",
                Name = "Asanka Madushan",               
                IsDeleted = false,
                ResidentAddress = "Seeduwa",
                NIC = "867869634v",
                ContactNumber1 = "098767656",
                ContactNumber2 = "87876544356"            
            };

            BataRate bataRateOne = new BataRate()
            {
                Description = "Overnight",
                Amount = 1000,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            BataRate bataRateTwo = new BataRate()
            {
                Description = "Full Day - Colombo",
                Amount = 400,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            BataRate bataRateThree = new BataRate()
            {
                Description = "Full Day - Outstation",
                Amount = 600,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            BataRate bataRateFour = new BataRate()
            {
                Description = "Airport - Pick Up",
                Amount = 200,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            BataRate bataRateFive = new BataRate()
            {
                Description = "Airport - Drop",
                Amount = 200,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            BataRate bataRateSix = new BataRate()
            {
                Description = "Airort - Drop & Pickup",
                Amount = 750,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            context.Role.Add(admin);
            context.Role.Add(dispatcher);

            //context.Vehicle.Add(car);
            //context.Vehicle.Add(suv);

            context.VehicleRate.Add(rateOne);
            context.VehicleRate.Add(rateTwo);
            context.VehicleRate.Add(rateThree);

            //context.PreDefineTrip.Add(tripOne);
            //context.PreDefineTrip.Add(tripTwo);

            //context.Driver.Add(driverOne);
            //context.Driver.Add(driverTwo);


            //context.BataRate.Add(bataRateOne);
            //context.BataRate.Add(bataRateTwo);
            //context.BataRate.Add(bataRateThree);
            //context.BataRate.Add(bataRateFour);
            //context.BataRate.Add(bataRateFive);
            //context.BataRate.Add(bataRateSix);

            base.Seed(context);
        }
    }
}
