using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Trips;

namespace Application.Trips
{
    public interface ICustomBataService
    {
        void SaveCustomBataData(CustomBata customBata);
        void RemoveCustomBata(int id);
        CustomBata RetrieveCustomBataByTripId(int id);
        bool IsCustomBattaNotExists(int tripId);
    }
}
