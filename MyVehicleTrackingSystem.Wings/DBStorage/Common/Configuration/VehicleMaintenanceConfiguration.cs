using Domain.VehicleMaintenance;
using System.Data.Entity.ModelConfiguration;

namespace DBStorage.Common.Configuration
{
    public class VehicleMaintenanceConfiguration : EntityTypeConfiguration<Domain.VehicleMaintenance.VehicleMaintenance>
    {
        public VehicleMaintenanceConfiguration()
        {
            HasKey(v => v.VehicleMaintenanceId);
        }
    }
}

