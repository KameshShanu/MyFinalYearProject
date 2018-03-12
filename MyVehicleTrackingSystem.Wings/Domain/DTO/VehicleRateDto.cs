using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class VehicleRateDto
    {
        public int VehicleRateId
        {
            get;
            set;
        }

        public string VehicleType
        {
            get;
            set;
        }

        public decimal FarePerKm
        {
            get;
            set;
        }

        public decimal WaitingChargers
        {
            get;
            set;
        }

        public string PassengerType
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

    }
}
