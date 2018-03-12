using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserLog
{
    public class UserLog : BaseEntity
    {
        public int LogId
        {
            get;
            protected set;
        }

        public string LoggedUser
        {
            get;
            set;
        }
        public string LoggedMachineName
        {
            get;
            set;
        }
        public string Version
        {
            get;
            set;
        }
        public int TripId
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return LogId == 0;
        }
    }
}
