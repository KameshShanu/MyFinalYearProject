using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CustomBataDto
    {
        public int CustomBataId
        {
            get;
            set;
        }
        public int TripId
        {
            get;
            set;
        }
        public decimal CustomAmount
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
