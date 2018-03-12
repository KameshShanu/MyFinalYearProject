using Domin.Common;
using System.Collections.Generic;

namespace Domain.Trips
{
    public interface IPreDefineTripRepository : IRepository<PreDefineTrip>
    {
        IEnumerable<PreDefineTrip> RetrieveAllPreDefineTrip();
        void DeleteMultiplePackages(IEnumerable<int> packagesToDelete);
        void DeletePreDefineTrip(int id);
        PreDefineTrip GetPreDefineTripById(int id);
        void SavePreDefineTrip(PreDefineTrip trip);
    }
}
