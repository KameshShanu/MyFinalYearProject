using DBStorage.Common;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class CustomBataRepository : Repository<CustomBata>, ICustomBataRepository
    {
        public CustomBataRepository(WingsContext context) : base(context)
        {
        }

        public bool IsCustomBattaNotExists(int tripId)
        {
            return !Context.CustomBata.Any(x => x.TripId == tripId);
        }

        public void RemoveCustomBata(int id)
        {
            try
            {
                Context.CustomBata.Where(t => t.TripId == id).ToList().ForEach(t => t.IsDeleted = true);
                Context.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomBata RetrieveCustomBataByTripId(int tripId)
        {
            try
            {
                CustomBata bata = Retrieve(t => t.TripId == tripId).LastOrDefault();
                return bata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveCustomBataData(CustomBata customBata)
        {
            Save(customBata);
        }
    }
}
