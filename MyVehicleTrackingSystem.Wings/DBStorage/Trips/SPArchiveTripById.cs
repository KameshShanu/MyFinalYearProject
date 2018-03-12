using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class SPArchiveTripById : SP
    {
        public SPArchiveTripById() { }

        public int TripId { get; set; }
    }
}
