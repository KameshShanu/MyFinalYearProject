using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public interface ITripBataRepository : IRepository<TripBata>
    {
        void SaveBataData(TripBata bataDetails);
        bool IsBattaNotExists(int id);
        void RemoveBata(int tripId);
        TripBata RetrieveByTripId(int tripId);
        TripBata RetrieveLastDeletedBataById(int tripId);
        void RevertToOldBata(int bataRateId);
    }
}
