using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Vehicles;
using DBStorage.Vehicles;

namespace Application.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _repository;

        public VehicleService(VehicleRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _repository.RetrieveAllVehicles();
        }

        public void SaveVehicle(Vehicle vehicle)
        {
            _repository.SaveVehicle(vehicle);
        }

        public Vehicle GetVehicleDetailById(int id)
        {
            return _repository.RetrieveByKey(id);
        }

        public void EditVehicle(int id, Vehicle model)
        {
            _repository.EditVehicle(id, model);
        }

        public void DeleteVehicle(int id)
        {
            _repository.DeleteVehicle(id);
        }

        public Vehicle GetVehicleModels(string vehicle)
        {
            return _repository.RetrieveVehicleModels(vehicle);
        }

        public int GetExpiryVehiclesCount()
        {
            return _repository.RetrieveExpiryVehiclesCount();
        }

        public IEnumerable<Vehicle> GetExpiryVehicles()
        {
            return _repository.RetrieveExpiryVehicles();
        }

        public void UpdateMeterReading(int vehicleId, int meterReading)
        {
            _repository.UpdateMeterReading(vehicleId, meterReading);
        }

        public void DeleteMultipleVehicles(IEnumerable<int> vehiclesToDelete)
        {
            _repository.DeleteMultipleVehicles(vehiclesToDelete);
        }

        public bool IsVehicleExists(string vehicleNumber)
        {
            return _repository.IsVehicleExists(vehicleNumber);
        }

        public bool IsVehicleExistsByLicenseNumber(string licenseNumber)
        {
            return _repository.IsVehicleExistsByLicenseNumber(licenseNumber);
        }

        public bool IsVehicleExistsByInsuranceNumber(string insuranceNumber)
        {
            return _repository.IsVehicleExistsByInsuranceNumber(insuranceNumber);
        }

        public bool IsVehicleExistsByGoodsNumber(string goodsNumber)
        {
            return _repository.IsVehicleExistsByGoodsNumber(goodsNumber);
        }

        public bool IsVehicleExistsByEngineNumber(string engineNumber)
        {
            return _repository.IsVehicleExistsByEngineNumber(engineNumber);
        }

        public bool IsVehicleExistsByChassisNumber(string chassisNumber)
        {
            return _repository.IsVehicleExistsByChassisNumber(chassisNumber);
        }       

        public void UpdateVehicleAvailable(IEnumerable<int> vehiclesToUpdate)
        {
            _repository.UpdateVehicleAvailable(vehiclesToUpdate);
        }

        public void UpdateVehicleUnAvailable(IEnumerable<int> vehiclesToUpdate)
        {
            _repository.UpdateVehicleUnAvailable(vehiclesToUpdate);
        }

        public IEnumerable<Vehicle> RetrieveTripsWithVehicle()
        {
            return _repository.RetrieveTripsWithVehicle();
        }
    }
}
