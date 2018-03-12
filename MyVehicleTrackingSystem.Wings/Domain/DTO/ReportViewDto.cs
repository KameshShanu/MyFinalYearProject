using Domain.Driver;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ReportViewDto
    {
        public List<DailyReportDto> ReportList { get; set; }
        public IEnumerable<DailyDriverPerformanceDto> DriverReportList { get; set; }
        public IEnumerable<DailyVehiclePerformanceDto> VehicleReportList { get; set; }
        public IEnumerable<BataReportDto> BataList { get; set; }
        public ReportDto ReportDto
        {
            get;
            set;
        }
        public DateTime CurrentDate
        {
            get;
            set;
        }
    }
}
