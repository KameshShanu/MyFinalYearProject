using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VehicleMaintenance
{
    public class VehicleMaintenance : BaseEntity
    {

        public int VehicleMaintenanceId
        {
            get;
            set;
        }

        public int VehicleId
        {
            get;
            set;
        }

        public DateTime MaintenanceDate
        {
            get;
            set;
        }

        public string MaintenanceDescription
        {
            get;
            set;
        }

        public decimal Cost
        {
            get;
            set;
        }

        public string VehicleNumber
        {
            get;
            set;
        }

        public string DieselLiters
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }

        public virtual Vehicles.Vehicle Vehicle
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return VehicleMaintenanceId == 0;
        }
    }
}
