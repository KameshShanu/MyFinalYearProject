using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vehicles
{
    public class Vehicle : BaseEntity
    {
        public int VehicleId
        {
            get;
            set;
        }

        public string VehicleNumber
        {
            get;
            set;
        }

        public string LicenseNumber
        {
            get;
            set;
        }

        public DateTime? LicenseExpDate
        {
            get;
            set;
        }
        
        public string InsuranceNumber
        {
            get;
            set;
        }

        public DateTime? InsuranceExpDate
        {
            get;
            set;
        }

        public string GoodsNumber
        {
            get;
            set;
        }

        public DateTime? GoodsExpDate
        {
            get;
            set;
        }

        public string VehicleMFYear
        {
            get;
            set;
        }

        public string EngineNumber
        {
            get;
            set;
        }

        public string ChassisNumber
        {
            get;
            set;
        }

        public string VehicleMake
        {
            get;
            set;
        }

        public string VehicleModel
        {
            get;
            set;
        }

        public DateTime? FirstRegistrationDate
        {
            get;
            set;
        }

        public DateTime? FireReportExpDate
        {
            get;
            set;
        }

        public DateTime? CalibrationReportExpDate
        {
            get;
            set;
        }

        public DateTime? EmissionTestExpDate
        {
            get;
            set;
        }

        public DateTime? VehicleFitnessExpDate
        {
            get;
            set;
        }        

        public DateTime? DangerousLicenseExpDate
        {
            get;
            set;
        }

        public DateTime? HighSecurityPassExpiryDate
        {
            get;
            set;
        }

        public string VehicleDeliveryType
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Quantity
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public virtual IEnumerable<VehicleMaintenance.VehicleMaintenance> VehicleMaintenance
        {
            get;
            set;
        }

        //public virtual ICollection<Driver.Driver> Drivers
        //{
        //    get;
        //    set;
        //}

        public override bool IsTransient()
        {
            return VehicleId == 0;
        }
    }
}
