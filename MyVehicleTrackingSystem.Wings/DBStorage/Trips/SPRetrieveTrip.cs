using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class SPRetrieveTrip : SP
    {
        public SPRetrieveTrip() { }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsOpen { get; set; }
        public bool? IsRemoved { get; set; }
        public bool? IsArchive { get; set; }
        public string Vouchernumber { get; set; }
    }
}
