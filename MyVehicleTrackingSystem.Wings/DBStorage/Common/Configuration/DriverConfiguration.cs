using Domain.Driver;
using System.Data.Entity.ModelConfiguration;

namespace DBStorage.Common.Configuration
{
    public class DriverConfiguration : EntityTypeConfiguration<Domain.Driver.Driver>
    {
        public DriverConfiguration()
        {
            HasKey(d => d.DriverId);
            //this.HasOptional(d => d.Vehicle).WithMany().HasForeignKey(d => d.VehicleId);
            //this.HasRequired(d => d.Vehicle).WithMany(o => o.Drivers).HasForeignKey(o => o.VehicleId);
        }
    }
}
