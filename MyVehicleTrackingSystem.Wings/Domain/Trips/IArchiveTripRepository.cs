using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public interface IArchiveTripRepository : IRepository<ArchiveTrip>
    {
        ArchiveTripCommonDTO Retrieve(int? pageNumber, string voucherNumber);
    }
}
