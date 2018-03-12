using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vehicles
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> RetrieveAllVehicles();
        void EditVehicle(int id, Vehicle model);
        Vehicle RetrieveVehicleModels(string vehi);
        int RetrieveExpiryVehiclesCount();
        IEnumerable<Vehicle> RetrieveExpiryVehicles();
        void UpdateMeterReading(int vehicleId, int meterReading);
        void DeleteMultipleVehicles(IEnumerable<int> vehiclesToDelete);
        bool IsVehicleExists(string vehicleNumber);
        bool IsVehicleExistsByLicenseNumber(string licenseNumber);
        bool IsVehicleExistsByInsuranceNumber(string insuranceNumber);
        bool IsVehicleExistsByGoodsNumber(string goodsNumber);
        bool IsVehicleExistsByEngineNumber(string engineNumber);
        bool IsVehicleExistsByChassisNumber(string chassisNumber);
        void SaveVehicle(Vehicle vehicle);
        void DeleteVehicle(int id);
        void UpdateVehicleAvailable(IEnumerable<int> vehiclesToUpdate);
        void UpdateVehicleUnAvailable(IEnumerable<int> vehiclesToUpdate);
        IEnumerable<Vehicle> RetrieveTripsWithVehicle();
    }
}
