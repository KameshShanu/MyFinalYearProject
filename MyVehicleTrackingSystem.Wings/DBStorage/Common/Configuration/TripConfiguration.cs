using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class TripConfiguration : EntityTypeConfiguration<Trip>
    {
        public TripConfiguration()
        {
            HasKey(d => d.TripId);
            //HasOptional(d => d.TripBata).WithOptionalPrincipal(l => l.Trip);
            //HasOptional(t => t.TripBata).WithRequired(b => b.Trip);
        }
    }
}
