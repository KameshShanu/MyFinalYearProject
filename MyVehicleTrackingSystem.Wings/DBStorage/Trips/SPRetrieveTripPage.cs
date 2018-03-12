using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class SPRetrieveTripPage : SP
    {
        public SPRetrieveTripPage() { }
        public bool? IsOpen { get; set; }
        public bool? IsRemoved { get; set; }
        public bool? IsArchive { get; set; }
        public string Vouchernumber { get; set; }
        public bool? IsReopened { get; set; }
        public int? PageNumber { get; set; }

    }
}
