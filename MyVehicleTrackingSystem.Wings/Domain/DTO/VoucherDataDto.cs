using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class VoucherDataDto
    {
        public string VoucherNumber { get; set; }
        public string VehicleRegNumber { get; set; }
        public string DriverCode { get; set; }
        public string DriverName { get; set; }
        public string Status { get; set; }

    }
}
