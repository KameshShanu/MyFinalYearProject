using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public interface ITripBataService
    {
        void SaveBataData(TripBata bataDetails);
        bool IsBattaNotExists(int id);
        void RemoveBata(int bataIdOld);
        TripBata RetrieveById(int tripId);
        TripBata RetrieveLastDeletedBataById(int id);
        void RevertToOldBata(int bataRateId);
    }
}
