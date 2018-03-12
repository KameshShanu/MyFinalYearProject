using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VehicleMaintenance
{
    public interface IVehicleMaintenanceService
    {
        IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetAllVehicleMaintenances();
        void DeleteMultipleVehicleMaintenances(IEnumerable<int> vehicleMaintenancesToDelete);
        void SaveVehicleMaintenance(Domain.VehicleMaintenance.VehicleMaintenance vehicleMaintenance);
        Domain.VehicleMaintenance.VehicleMaintenance GetVehicleMaintenanceById(int id);
        IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetVehicleMaintenancesByVehicleNumber(string vehicleNumber);
        IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetVehicleMaintenancesByVehicleId(int vehicleId);
        void EditVehicleMaintenance(int id, Domain.VehicleMaintenance.VehicleMaintenance vehicleMaintenance);
    }
}
