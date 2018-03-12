using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public interface IPreDefineTripService
    {
        Domain.Trips.PreDefineTrip GetPreDefineTripById(int id);
        IEnumerable<Domain.Trips.PreDefineTrip> GetAllPreDefineTrip();
        void SavePreDefineTrip(Domain.Trips.PreDefineTrip trip);
        void DeletePreDefineTrip(int id);
        void DeleteMultiplePackages(IEnumerable<int> packagesToDelete);
    }
}
