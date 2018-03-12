using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UserLog;

namespace Application.UserLog
{
    public interface IUserLogService
    {
        void LogUserEvent(Domain.UserLog.UserLog log);
    }
}
