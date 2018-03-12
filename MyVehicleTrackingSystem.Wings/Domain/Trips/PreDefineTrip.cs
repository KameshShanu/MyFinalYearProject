using Domin.Common;

namespace Domain.Trips
{
    public class PreDefineTrip : BaseEntity
    {
        public int PreDefineTripId
        {
            get;
            protected set;
        }

        public string PreDefineTripName
        {
            get;
            set;
        }
        public string TripType
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }

        public string VehicleType
        {
            get;
            set;
        }

        public string Distance
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        //public virtual PackagesList PackageList
        //{
        //    get;
        //    set;
        //}

        public override bool IsTransient()
        {
            return PreDefineTripId == 0;
        }
    }
}
