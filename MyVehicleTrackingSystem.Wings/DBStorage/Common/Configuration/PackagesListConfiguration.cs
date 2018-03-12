using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class PackagesListConfiguration : EntityTypeConfiguration<PackagesList>
    {
        public PackagesListConfiguration()
        {
            HasKey(t => t.PackageId);
            this.HasRequired(oi => oi.Trip).WithMany(o => o.PackagesList).HasForeignKey(o => o.TripId);
        }
 
    }
}
