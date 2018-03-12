using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Trips
{
    public interface IArchiveTripService 
    {
        ArchiveTripCommonDTO Retrieve(int? pageNumber, string voucherNumber);
    }
}
