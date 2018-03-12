using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class SPRetrieveDriverWiseBata : SP
    {
        public SPRetrieveDriverWiseBata() { }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DriverId { get; set; }
        public string VehicleId { get; set; }
        public string EmployeeNumber { get; set; }
    }
}
