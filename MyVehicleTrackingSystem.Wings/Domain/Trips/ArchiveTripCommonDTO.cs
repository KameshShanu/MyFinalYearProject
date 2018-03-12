using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class ArchiveTripCommonDTO
    {
        public IEnumerable<ArchiveTrip> ArchivedTrips { get; set; }
        public int ItemCount { get; set; }
    }
}
