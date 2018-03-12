using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class VehicleRateConfiguration : EntityTypeConfiguration<Domain.Trips.VehicleRate>
    {
        public VehicleRateConfiguration()
        {
            HasKey(r => r.VehicleRateId);
        }
    }
}
