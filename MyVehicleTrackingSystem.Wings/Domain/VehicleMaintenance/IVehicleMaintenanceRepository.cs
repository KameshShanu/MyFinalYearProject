using Domin.Common;
using System.Collections.Generic;

namespace Domain.VehicleMaintenance
{
    public interface IVehicleMaintenanceRepository : IRepository<VehicleMaintenance>
    {
        IEnumerable<VehicleMaintenance> GetAllVehicleMaintenances();
        void DeleteMultipleVehicleMaintenances(IEnumerable<int> vehicleMaintenancesToDelete);
        void SaveVehicleMaintenance(VehicleMaintenance vehicleMaintenance);
        Domain.VehicleMaintenance.VehicleMaintenance GetVehicleMaintenanceById(int id);
        IEnumerable<VehicleMaintenance> GetVehicleMaintenancesByVehicleNumber(string vehicleNumber);
        IEnumerable<VehicleMaintenance> GetVehicleMaintenancesByVehicleId(int vehicleId);
        void EditVehicleMaintenance(int id, VehicleMaintenance vehicleMaintenance);
    }
}