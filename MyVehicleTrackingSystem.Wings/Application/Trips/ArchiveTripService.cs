using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Trips;
using DBStorage.Trips;

namespace Application.Trips
{
    public class ArchiveTripService : IArchiveTripService
    {
        private IArchiveTripRepository _archiveTripRepository;

        public ArchiveTripService(ArchiveTripRepository archiveTripRepository)
        {
            _archiveTripRepository = archiveTripRepository;
        }

        public ArchiveTripCommonDTO Retrieve(int? pageNumber, string voucherNumber)
        {
            return _archiveTripRepository.Retrieve(pageNumber, voucherNumber);
        }
    }
}
