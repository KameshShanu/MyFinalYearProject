using DBStorage.Trips;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public class TripBataService : ITripBataService
    {
        private ITripBataRepository _tripBataRepository;

        public TripBataService(TripBataRepository tripBataRepository)
        {
            _tripBataRepository = tripBataRepository;
        }

        public bool IsBattaNotExists(int id)
        {
            return _tripBataRepository.IsBattaNotExists(id);
        }

        public void RemoveBata(int tripId)
        {
            _tripBataRepository.RemoveBata(tripId);
        }

        public TripBata RetrieveById(int tripId)
        {
            return _tripBataRepository.RetrieveByTripId(tripId);
        }

        public TripBata RetrieveLastDeletedBataById(int tripId)
        {
            return _tripBataRepository.RetrieveLastDeletedBataById(tripId);
        }

        public void RevertToOldBata(int bataRateId)
        {
            _tripBataRepository.RevertToOldBata(bataRateId);
        }

        public void SaveBataData(TripBata bataDetails)
        {
            _tripBataRepository.SaveBataData(bataDetails);
        }
    }
}
