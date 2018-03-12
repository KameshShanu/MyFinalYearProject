using Domain.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class BataReportDto
    {
        public DateTime Date { get; set; }
        public IList<DailyDriverPerformanceDto> BataDetails { get; set; }
    }
}
