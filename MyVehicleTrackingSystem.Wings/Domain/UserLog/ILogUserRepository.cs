using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserLog
{
    public interface ILogUserRepository
    {
        void LogUserEvent(UserLog log);
    }
}
