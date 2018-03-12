using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class SPRetrieveArchiveTrip : SP
    {
        public SPRetrieveArchiveTrip() { }

        public string VoucherNumber { get; set; }
        public int? PageNumber { get; set; }
    }
}
