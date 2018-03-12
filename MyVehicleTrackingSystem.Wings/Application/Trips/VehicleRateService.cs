using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Trips;
using DBStorage.Trips;

namespace Application.Trips
{
    public class VehicleRateService : IVehicleRateService
    {
        private IVehicleRateRepository _vehicleRateRepository;

        public VehicleRateService(VehicleRateRepository vehicleRateRepository)
        {
            _vehicleRateRepository = vehicleRateRepository;
        }

        public void DeleteVehicleRate(int id)
        {
            VehicleRate rate = GetVehicleRateById(id);
            if (rate != null)
            {
                _vehicleRateRepository.Delete(rate);
            }
        }

        public IEnumerable<VehicleRate> GetAllVehicleRates()
        {
            return _vehicleRateRepository.RetrieveAllVehicleRates().Where(r => r.IsDeleted.Equals(false));
        }

        public VehicleRate GetVehicleRateById(int id)
        {
            return _vehicleRateRepository.Retrieve(t => t.VehicleRateId == id).FirstOrDefault();
        }

        public void SaveVehicleRate(VehicleRate rate)
        {
            _vehicleRateRepository.Save(rate);
        }

        public bool VehicleExists(string VehicleType)
        {
            return _vehicleRateRepository.VehicleExists(VehicleType);
        }

        public void UpdateVehicleRate(int vehicleRateId, VehicleRate updatedEntity)
        {
            VehicleRate originalVehicleRate = GetVehicleRateById(vehicleRateId);
            if (originalVehicleRate != null)
            {
                originalVehicleRate.VehicleType = updatedEntity.VehicleType;
                originalVehicleRate.FarePerKm = updatedEntity.FarePerKm;
                originalVehicleRate.WaitingChargers = updatedEntity.WaitingChargers;
                SaveVehicleRate(originalVehicleRate);
            }
        }

        public void DeleteMultipleRates(IEnumerable<int> ratesToDelete)
        {
            _vehicleRateRepository.DeleteMultipleRates(ratesToDelete);
        }
    }
}
