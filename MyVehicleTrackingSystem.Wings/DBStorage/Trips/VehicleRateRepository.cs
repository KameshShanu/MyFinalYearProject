using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Common;
using System.Linq.Expressions;
using DBStorage.Common;

namespace DBStorage.Trips
{
    public class VehicleRateRepository : Repository<Domain.Trips.VehicleRate>, IVehicleRateRepository
    {
        public VehicleRateRepository(WingsContext context) : base(context)
        {
        }

        public void DeleteMultipleRates(IEnumerable<int> ratesToDelete)
        {
            Context.VehicleRate.Where(r => ratesToDelete.Contains(r.VehicleRateId)).ToList().ForEach(r => r.IsDeleted = true);
            Context.Commit();
        }

        public IEnumerable<VehicleRate> RetrieveAllVehicleRates()
        {
            return Context.Set<VehicleRate>();
        }

        public bool VehicleExists(string VehicleType)
        {
            return !Context.VehicleRate.Any(x => x.VehicleType == VehicleType && x.IsDeleted.Equals(false));
        }
    }
}
