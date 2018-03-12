using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public interface IVehicleRateRepository : IRepository<VehicleRate>
    {
        IEnumerable<VehicleRate> RetrieveAllVehicleRates();
        bool VehicleExists(string VehicleType);
        void DeleteMultipleRates(IEnumerable<int> ratesToDelete);
    }
}
