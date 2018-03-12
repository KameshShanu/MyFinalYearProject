using DBStorage.Trips;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public class CustomBataService: ICustomBataService
    {
        private ICustomBataRepository _bataRepository;

        public CustomBataService(CustomBataRepository bataRepository)
        {
            _bataRepository = bataRepository;
        }

        public bool IsCustomBattaNotExists(int tripId)
        {
            return _bataRepository.IsCustomBattaNotExists(tripId);
        }

        public void RemoveCustomBata(int id)
        {
            _bataRepository.RemoveCustomBata(id);
        }

        public CustomBata RetrieveCustomBataByTripId(int id)
        {
            return _bataRepository.RetrieveCustomBataByTripId(id);
        }

        public void SaveCustomBataData(CustomBata customBata)
        {
            _bataRepository.SaveCustomBataData(customBata);
        }
    }
}
