using System;
using System.Collections.Generic;
using Domain.VehicleMaintenance;
using DBStorage.VehicleMaintenance;
using System.Linq;

namespace Application.VehicleMaintenance
{
    public class VehicleMaintenanceService : IVehicleMaintenanceService
    {
        private IVehicleMaintenanceRepository _vehiclemaintenanceRepository;
        public VehicleMaintenanceService(VehicleMaintenanceRepository vehiclemaintenanceRepository)
        {
            _vehiclemaintenanceRepository = vehiclemaintenanceRepository;
        }

        public void DeleteMultipleVehicleMaintenances(IEnumerable<int> vehicleMaintenancesToDelete)
        {
            _vehiclemaintenanceRepository.DeleteMultipleVehicleMaintenances(vehicleMaintenancesToDelete);
        }

        public IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetAllVehicleMaintenances()
        {
            return _vehiclemaintenanceRepository.GetAllVehicleMaintenances();
        }

        public Domain.VehicleMaintenance.VehicleMaintenance GetVehicleMaintenanceById(int id)
        {
            return _vehiclemaintenanceRepository.GetVehicleMaintenanceById(id);
        }

        public IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetVehicleMaintenancesByVehicleNumber(string vehicleNumber)
        {
            return _vehiclemaintenanceRepository.GetVehicleMaintenancesByVehicleNumber(vehicleNumber);
        }

        public IEnumerable<Domain.VehicleMaintenance.VehicleMaintenance> GetVehicleMaintenancesByVehicleId(int vehicleId)
        {
            return _vehiclemaintenanceRepository.GetVehicleMaintenancesByVehicleId(vehicleId);
        }

        public void SaveVehicleMaintenance(Domain.VehicleMaintenance.VehicleMaintenance vehicleMaintenance)
        {
            _vehiclemaintenanceRepository.SaveVehicleMaintenance(vehicleMaintenance);
        }

        public void EditVehicleMaintenance(int id, Domain.VehicleMaintenance.VehicleMaintenance vehicleMaintenance)
        {
            _vehiclemaintenanceRepository.EditVehicleMaintenance(id, vehicleMaintenance);
        }
    }
}
