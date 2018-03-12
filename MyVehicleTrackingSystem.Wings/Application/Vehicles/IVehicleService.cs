using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Vehicles;

namespace Application.Vehicles
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetAllVehicles();
        Vehicle GetVehicleDetailById(int id);
        void SaveVehicle(Vehicle model);
        void EditVehicle(int id, Vehicle model);
        void DeleteVehicle(int id);
        Vehicle GetVehicleModels(string vehi);
        int GetExpiryVehiclesCount();
        IEnumerable<Vehicle> GetExpiryVehicles();
        void UpdateMeterReading(int vehicleId, int meterReading);
        void DeleteMultipleVehicles(IEnumerable<int> vehiclesToDelete);
        bool IsVehicleExists(string vehicleNumber);
        bool IsVehicleExistsByLicenseNumber(string licenseNumber);
        bool IsVehicleExistsByInsuranceNumber(string insuranceNumber);
        bool IsVehicleExistsByGoodsNumber(string goodsNumber);
        bool IsVehicleExistsByEngineNumber(string engineNumber);
        bool IsVehicleExistsByChassisNumber(string chassisNumber);
        void UpdateVehicleAvailable(IEnumerable<int> vehiclesToUpdate);
        void UpdateVehicleUnAvailable(IEnumerable<int> vehiclesToUpdate);
        IEnumerable<Vehicle> RetrieveTripsWithVehicle();
    }
}
