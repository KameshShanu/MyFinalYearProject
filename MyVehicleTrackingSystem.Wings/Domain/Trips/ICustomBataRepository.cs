using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public interface ICustomBataRepository
    {
        void SaveCustomBataData(CustomBata customBata);
        void RemoveCustomBata(int id);
        CustomBata RetrieveCustomBataByTripId(int id);
        bool IsCustomBattaNotExists(int tripId);
    }
}
