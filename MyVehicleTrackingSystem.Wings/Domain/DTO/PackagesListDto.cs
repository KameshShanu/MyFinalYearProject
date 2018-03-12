using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PackagesListDto
    {
        public int PackageId
        {
            get;
            set;
        }

        public int TripId
        {
            get;
            set;
        }

        public string PreDefineTripName
        {
            get;
            set;
        }

        public decimal Rate
        {
            get;
            set;
        }
    }
}
