using DBStorage.Common;
using Domain.UserLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.UserLog
{
    public class LogUserRepository : Repository<Domain.UserLog.UserLog>, ILogUserRepository
    {
        public LogUserRepository(WingsContext context)
            : base(context)
        {
        }
        public void LogUserEvent(Domain.UserLog.UserLog log)
        {
            Save(log);
        }
    }
}
