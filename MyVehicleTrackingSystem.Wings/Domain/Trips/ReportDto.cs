using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class ReportDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PaymentType { get; set; }

        public string HotelName { get; set; }

        public string PassengerType { get; set; }

        public int VehicleId { get; set; }

        public int DriverId { get; set; }

        public string Dispatcher { get; set; }

        public string Status { get; set; }

        public string CorporateName { get; set; }

        public string PaymentCategory { get; set; }

        public string EmployeeNumber { get; set; }
    }
}
