using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class ArchiveTripConfiguration : EntityTypeConfiguration<ArchiveTrip>
    {
        public ArchiveTripConfiguration()
        {
            HasKey(b => b.ArchiveTripId);
        }
    }
}
