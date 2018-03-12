using System.Collections.Generic;
using DBStorage.Common;
using Domain.VehicleMaintenance;
using System.Linq;
using System.Data;

namespace DBStorage.VehicleMaintenance
{
    public class VehicleMaintenanceRepository : Repository<Domain.VehicleMaintenance.VehicleMaintenance>, IVehicleMaintenanceRepository
    {
        public VehicleMaintenanceRepository(WingsContext context) : base(context)
        {
        }

        public void DeleteMultipleVehicleMaintenances(IEnumerable<int> vehicleMaintenancesToDelete)
        {
            Context.VehicleMaintenance.Where(d => vehicleMaintenancesToDelete.Contains(d.VehicleMaintenanceId)).ToList().ForEach(
                 d =>
                 {
                     d.IsDeleted = true;
                 }
                 );
            Context.Commit();
        }

        public IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetAllVehicleMaintenances()
        {
            return Retrieve(v => v.IsDeleted == false);
        }

        public Domain.VehicleMaintenance.VehicleMaintenance GetVehicleMaintenanceById(int id)
        {
            return Retrieve(v => v.VehicleMaintenanceId == id).SingleOrDefault();
        }

        public IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetVehicleMaintenancesByVehicleNumber(string vehicleNumber)
        {
            return Retrieve(v => v.IsDeleted == false).Where(c => c.VehicleNumber == vehicleNumber);
        }

        public IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetVehicleMaintenancesByVehicleId(int vehicleId)
        {
            return Retrieve(v => v.IsDeleted == false).Where(c => c.VehicleId == vehicleId);
        }

        public void SaveVehicleMaintenance(Domain.VehicleMaintenance.VehicleMaintenance vehicleMaintenance)
        {
            Save(vehicleMaintenance);
        }

        public void EditVehicleMaintenance(int id, Domain.VehicleMaintenance.VehicleMaintenance vehicleMaintenance)
        {
            Domain.VehicleMaintenance.VehicleMaintenance vm = RetrieveByKey(id);

            vm.MaintenanceDate = vehicleMaintenance.MaintenanceDate;
            vm.MaintenanceDescription = vehicleMaintenance.MaintenanceDescription;
            vm.Cost = vehicleMaintenance.Cost;
            Save(vm);
        }
    }
}
