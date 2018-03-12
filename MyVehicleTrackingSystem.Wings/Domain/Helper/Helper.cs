using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class Helper : BaseEntity
    {

        public int HelperId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string NIC
        {
            get;
            set;
        }

        public DateTime DateOfBirth
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

        public string EPFNumber
        {
            get;
            set;
        }

        public DateTime StartDateOfWork
        {
            get;
            set;
        }

        public string PeriodOfService
        {
            get;
            set;
        }

        public decimal BasicSalary
        {
            get;
            set;
        }

        public decimal MinimumSalary
        {
            get;
            set;
        }

        public DateTime PoliceReportExpiryDate
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

        public override bool IsTransient()
        {
            return HelperId == 0;
        }
    }
}
