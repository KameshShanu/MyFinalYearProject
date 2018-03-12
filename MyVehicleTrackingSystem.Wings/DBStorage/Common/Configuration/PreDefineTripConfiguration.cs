using System.Data.Entity.ModelConfiguration;

namespace DBStorage.Common.Configuration
{
    public class PreDefineTripConfiguration : EntityTypeConfiguration<Domain.Trips.PreDefineTrip>
    {
        public PreDefineTripConfiguration()
        {
            HasKey(t => t.PreDefineTripId);
            //HasOptional(t => t.PackageList).WithRequired(pl => pl.PreDefineTrip);
        }
    }
}
