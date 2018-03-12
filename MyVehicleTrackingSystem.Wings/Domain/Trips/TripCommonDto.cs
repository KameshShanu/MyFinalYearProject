using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class TripCommonDto
    {
        public IEnumerable<TripDto> trips { get; set; }
        public int ItemCount { get; set; }
    }
}
