using DBStorage.Common;
using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DBStorage.Vehicles
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(WingsContext context)
            : base(context)
        {
        }
        private IDbConnection GetConnection()
        {
            var connection = new SqlConnection();
            WingsContext wings = WingsContext.GetInstance();
            connection.ConnectionString = wings.Database.Connection.ConnectionString;
            connection.Open();
            return connection;
        }
        public void DeleteMultipleVehicles(IEnumerable<int> vehiclesToDelete)
        {
            Context.Vehicle.Where(v => vehiclesToDelete.Contains(v.VehicleId)).ToList().ForEach(v => v.IsDeleted = true);
            Context.Commit();
        }

        public void DeleteVehicle(int id)
        {
            Vehicle vehicle = RetrieveByKey(id);
            Delete(vehicle);
        }

        public void EditVehicle(int id, Vehicle model)
        {
            Vehicle vehicle = RetrieveByKey(id);
            vehicle.VehicleNumber = model.VehicleNumber;
            vehicle.LicenseNumber = model.LicenseNumber;
            vehicle.LicenseExpDate = model.LicenseExpDate;
            vehicle.InsuranceNumber = model.InsuranceNumber;
            vehicle.InsuranceExpDate = model.InsuranceExpDate;
            vehicle.GoodsNumber = model.GoodsNumber;
            vehicle.GoodsExpDate = model.GoodsExpDate;
            vehicle.VehicleMFYear = model.VehicleMFYear;
            vehicle.EngineNumber = model.EngineNumber;
            vehicle.ChassisNumber = model.ChassisNumber;
            vehicle.VehicleMake = model.VehicleMake;
            vehicle.VehicleModel = model.VehicleModel;
            vehicle.FirstRegistrationDate = model.FirstRegistrationDate;
            vehicle.FireReportExpDate = model.FireReportExpDate;
            vehicle.CalibrationReportExpDate = model.CalibrationReportExpDate;
            vehicle.EmissionTestExpDate = model.EmissionTestExpDate;
            vehicle.VehicleFitnessExpDate = model.VehicleFitnessExpDate;            
            vehicle.DangerousLicenseExpDate = model.DangerousLicenseExpDate;
            vehicle.HighSecurityPassExpiryDate = model.HighSecurityPassExpiryDate;
            vehicle.VehicleDeliveryType = model.VehicleDeliveryType;
            vehicle.Description = model.Description;
            vehicle.Quantity = model.Quantity;

            Save(vehicle);
            UnitOfWork.Commit();
        }

        public bool IsVehicleExists(string vehicleNumber)
        {
            return Context.Vehicle.Any(x => x.VehicleNumber == vehicleNumber && x.IsDeleted.Equals(false));
        }

        public bool IsVehicleExistsByLicenseNumber(string licenseNumber)
        {
            return Context.Vehicle.Any(x => x.LicenseNumber == licenseNumber && x.IsDeleted.Equals(false));
        }

        public bool IsVehicleExistsByInsuranceNumber(string insuranceNumber)
        {
            return Context.Vehicle.Any(x => x.InsuranceNumber == insuranceNumber && x.IsDeleted.Equals(false));
        }

        public bool IsVehicleExistsByGoodsNumber(string goodsNumber)
        {
            return Context.Vehicle.Any(x => x.GoodsNumber == goodsNumber && x.IsDeleted.Equals(false));
        }

        public bool IsVehicleExistsByEngineNumber(string engineNumber)
        {
            return Context.Vehicle.Any(x => x.EngineNumber == engineNumber && x.IsDeleted.Equals(false));
        }

        public bool IsVehicleExistsByChassisNumber(string chassisNumber)
        {
            return Context.Vehicle.Any(x => x.ChassisNumber == chassisNumber && x.IsDeleted.Equals(false));
        }

        public IEnumerable<Vehicle> RetrieveAllVehicles()
        {
            return Context.Set<Vehicle>().Where(a => a.IsDeleted == false);
        }

        public Vehicle RetrieveVehicleModels(string vehicle)
        {
            return Context.Set<Vehicle>().Where(a => a.VehicleDeliveryType == vehicle).FirstOrDefault();
        }

        /// <summary>
        /// Retrieve Expiry Vehicles Count
        /// </summary>
        /// <returns></returns>
        public int RetrieveExpiryVehiclesCount()
        {
            DateTime expiryDate = DateTime.Now.AddMonths(1);
            return Context.Set<Vehicle>().Where(v => v.IsDeleted == false && (v.LicenseExpDate <= expiryDate ||
                                                                              v.InsuranceExpDate <= expiryDate ||
                                                                              v.GoodsExpDate <= expiryDate ||
                                                                              v.FireReportExpDate <= expiryDate ||
                                                                              v.CalibrationReportExpDate <= expiryDate ||
                                                                              v.EmissionTestExpDate <= expiryDate ||
                                                                              v.VehicleFitnessExpDate <= expiryDate ||
                                                                              v.DangerousLicenseExpDate <= expiryDate ||
                                                                              v.HighSecurityPassExpiryDate <= expiryDate)).Count();
        }

        /// <summary>
        /// Retrieve Expiry Vehicles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vehicle> RetrieveExpiryVehicles()
        {
            DateTime expiryDate = DateTime.Now.AddMonths(1);
            return Context.Set<Vehicle>().Where(v => v.IsDeleted == false && (v.LicenseExpDate <= expiryDate ||
                                                                              v.InsuranceExpDate <= expiryDate ||
                                                                              v.GoodsExpDate <= expiryDate ||
                                                                              v.FireReportExpDate <= expiryDate ||
                                                                              v.CalibrationReportExpDate <= expiryDate ||
                                                                              v.EmissionTestExpDate <= expiryDate ||
                                                                              v.VehicleFitnessExpDate <= expiryDate ||
                                                                              v.DangerousLicenseExpDate <= expiryDate ||
                                                                              v.HighSecurityPassExpiryDate <= expiryDate));
        }

        public void SaveVehicle(Vehicle vehicle)
        {
            Save(vehicle);
        }

        public void UpdateMeterReading(int vehicleId, int meterReading)
        {
            Vehicle vehi = new Vehicle();
            vehi = RetrieveByKey(vehicleId);
            //vehi.CurrentMeterReading = meterReading;
            Save(vehi);
        }
        public void UpdateVehicleAvailable(IEnumerable<int> vehiclesToUpdate)
        {
            Context.Vehicle.Where(v => vehiclesToUpdate.Contains(v.VehicleId)).ToList().ForEach(v => v.IsAvailable = false);
            Context.Commit();
        }

        public void UpdateVehicleUnAvailable(IEnumerable<int> vehiclesToUpdate)
        {
            Context.Vehicle.Where(v => vehiclesToUpdate.Contains(v.VehicleId)).ToList().ForEach(v => v.IsAvailable = true);
            Context.Commit();
        }
        public IEnumerable<Vehicle> RetrieveTripsWithVehicle()
        {
            try
            {
                SPRetrieveVehiclesAdmin parameters = new SPRetrieveVehiclesAdmin();
                using (var connection = GetConnection())
                {
                    return connection.Query<Vehicle>(sql: parameters.GetName(), param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
