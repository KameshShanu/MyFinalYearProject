using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public interface IVehicleRateService
    {
        Domain.Trips.VehicleRate GetVehicleRateById(int id);
        IEnumerable<Domain.Trips.VehicleRate> GetAllVehicleRates();
        void SaveVehicleRate(Domain.Trips.VehicleRate rate);
        void DeleteVehicleRate(int id);
        bool VehicleExists(string VehicleType);
        void UpdateVehicleRate(int vehicleRateId, VehicleRate updatedEntity);
        void DeleteMultipleRates(IEnumerable<int> ratesToDelete);
    }
}
