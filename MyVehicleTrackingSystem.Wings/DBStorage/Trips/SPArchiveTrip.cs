using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class SPArchiveTrip : SP
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
