using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class TripBata : BaseEntity
    {
        public int BataRateId
        {
            get;
            set;
        }

        public int TripId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public virtual Trip Trip
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return BataRateId == 0;
        }
    }
}
