using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class TripBataConfiguration : EntityTypeConfiguration<TripBata>
    {
        public TripBataConfiguration()
        {
            HasKey(b => b.BataRateId);
            this.HasRequired(oi => oi.Trip).WithMany(o => o.TripBata).HasForeignKey(o => o.TripId);
        }
    }
}
