using DBStorage.Common;
using Domain.Trips;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DBStorage.Trips
{
    public class PreDefineTripRepository : Repository<Domain.Trips.PreDefineTrip>, IPreDefineTripRepository
    {
        public PreDefineTripRepository(WingsContext context) : base(context)
        {
        }

        public void DeleteMultiplePackages(IEnumerable<int> packagesToDelete)
        {
            Context.PreDefineTrip.Where(p => packagesToDelete.Contains(p.PreDefineTripId)).ToList().ForEach(p => p.IsDeleted = true);
            Context.Commit();
        }

        public void DeletePreDefineTrip(int id)
        {
            PreDefineTrip trip = RetrieveByKey(id);
            if (trip != null)
            {
                Delete(trip);
            }
        }

        public PreDefineTrip GetPreDefineTripById(int id)
        {
            return RetrieveByKey(id);
        }

        public IEnumerable<PreDefineTrip> RetrieveAllPreDefineTrip()
        {
            return Context.Set<PreDefineTrip>();
        }

        public void SavePreDefineTrip(PreDefineTrip trip)
        {
            Save(trip);
        }
    }
}
