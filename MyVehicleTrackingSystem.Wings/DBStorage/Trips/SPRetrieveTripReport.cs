using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Trips
{
    public class SPRetrieveTripReport : SP
    {
        public SPRetrieveTripReport() { }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentType { get; set; }
        public string DispatchedHotel { get; set; }
        public string PassengerType { get; set; }
        public string VehicleId { get; set; }
        public string DriverId { get; set; }
        public string Dispatcher { get; set; }
        public bool? IsOpen { get; set; }
        public bool? IsRemoved { get; set; }
        public string CorporateName { get; set; }
        public string PaymentCategory { get; set; }
    }
}
