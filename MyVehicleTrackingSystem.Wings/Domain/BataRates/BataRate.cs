using Domain.Trips;
using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BataRates
{
    public class BataRate : BaseEntity
    {
        public int BataId
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

        public bool IsDeleted
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return BataId == 0;
        }
    }
}
