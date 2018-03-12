using Domain.Trips;
using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public class Customer : BaseEntity
    {
        public int CustomerId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public int TripCount
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public virtual IEnumerable<Trip> Trips
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return CustomerId == 0;
        }
    }
}
