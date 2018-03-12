using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class PackagesList : BaseEntity
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

        public virtual Trip Trip
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

        //public virtual PreDefineTrip PreDefineTrip
        //{
        //    get;
        //    set;
        //}

        public override bool IsTransient()
        {
            return PackageId == 0;
        }
    }
}
