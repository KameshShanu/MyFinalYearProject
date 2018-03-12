using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DriverDto
    {
        public int DriverId
        {
            get;
            protected set;
        }

        public string EmpNumber
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string PixURL
        {
            get;
            set;
        }


        public string NIC
        {
            get;
            set;
        }

        public string HomeAddress
        {
            get;
            set;
        }

        public string ResidentAddress
        {
            get;
            set;
        }

        public string PhoneNumber1
        {
            get;
            set;
        }

        public string PhoneNumber2
        {
            get;
            set;
        }

        public string PhoneNumber3
        {
            get;
            set;
        }

        public string DLNumber
        {
            get;
            set;
        }

        public string EPFNumber
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public int TripId
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }
    }
}
