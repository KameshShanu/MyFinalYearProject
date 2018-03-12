using Domain.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class BataReportModel
    {
        public DateTime Date { get; set; }
        public IList<DailyDriverPerformanceDto> BataDetails { get; set; }
    }
}