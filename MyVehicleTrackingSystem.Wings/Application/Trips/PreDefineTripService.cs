using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Trips;
using DBStorage.Trips;

namespace Application.Trips
{
    public class PreDefineTripService : IPreDefineTripService
    {
        private IPreDefineTripRepository _preDefineRepository;

        public PreDefineTripService(PreDefineTripRepository preDefineRepository)
        {
            _preDefineRepository = preDefineRepository;
        }

        public void DeleteMultiplePackages(IEnumerable<int> packagesToDelete)
        {
            _preDefineRepository.DeleteMultiplePackages(packagesToDelete);
        }

        public void DeletePreDefineTrip(int id)
        {
            _preDefineRepository.DeletePreDefineTrip(id);
        }

        public IEnumerable<PreDefineTrip> GetAllPreDefineTrip()
        {
            return _preDefineRepository.RetrieveAllPreDefineTrip().Where(pt => pt.IsDeleted.Equals(false));
        }

        public PreDefineTrip GetPreDefineTripById(int id)
        {
            return _preDefineRepository.GetPreDefineTripById(id);
        }

        public void SavePreDefineTrip(PreDefineTrip trip)
        {
            _preDefineRepository.SavePreDefineTrip(trip);
        }
    }
}
