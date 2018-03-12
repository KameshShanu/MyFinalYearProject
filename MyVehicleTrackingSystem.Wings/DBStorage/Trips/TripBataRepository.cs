using DBStorage.Common;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class TripBataRepository : Repository<TripBata>, ITripBataRepository
    {
        public TripBataRepository(WingsContext context) : base(context)
        {
        }

        public bool IsBattaNotExists(int id)
        {
            return !Context.TripBata.Any(x => x.TripId == id);
        }

        public void RemoveBata(int tripId)
        {
            Context.TripBata.Where(t => t.TripId == tripId).ToList().ForEach(t => t.IsDeleted = true);
            Context.Commit();
        }

        public TripBata RetrieveByTripId(int tripId)
        {
            TripBata trip = Retrieve(t => t.TripId == tripId).LastOrDefault();
            return trip;
        }

        public TripBata RetrieveLastDeletedBataById(int tripId)
        {
            TripBata bata = Retrieve(t => t.TripId == tripId && t.IsDeleted == true).LastOrDefault();
            return bata;
        }

        public void RevertToOldBata(int bataRateId)
        {
            Context.TripBata.Where(t => t.BataRateId == bataRateId).ToList().ForEach(t => t.IsDeleted = false);
            Context.Commit();
        }

        public void SaveBataData(TripBata bataDetails)
        {
            Save(bataDetails);
        }
    }
}
