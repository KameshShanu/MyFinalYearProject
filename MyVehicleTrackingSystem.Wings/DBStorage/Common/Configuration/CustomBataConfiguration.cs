using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class CustomBataConfiguration : EntityTypeConfiguration<CustomBata>
    {
        public CustomBataConfiguration()
        {
            HasKey(b => b.CustomBataId);
            this.HasRequired(oi => oi.Trip).WithMany(o => o.CustomBata).HasForeignKey(o => o.TripId);
        }
    }
}
