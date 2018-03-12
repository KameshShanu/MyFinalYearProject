using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UserLog;
using DBStorage.UserLog;

namespace Application.UserLog
{
    public class UserLogService : IUserLogService
    {

        private ILogUserRepository _userLogResitory;

        public UserLogService(LogUserRepository userLogResitory)
        {
            _userLogResitory = userLogResitory;
        }

        public void LogUserEvent(Domain.UserLog.UserLog log)
        {
            _userLogResitory.LogUserEvent(log);
        }
    }
}
