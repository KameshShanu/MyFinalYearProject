using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class CustomBata : BaseEntity
    {
        public int CustomBataId
        {
            get;
            set;
        }
        public int TripId
        {
            get;
            set;
        }
        public decimal CustomAmount
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
            return CustomBataId == 0;
        }
    }
}
