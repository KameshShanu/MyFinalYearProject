using Domain.UserLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class UserLogConfiguration : EntityTypeConfiguration<Domain.UserLog.UserLog>
    {
        public UserLogConfiguration()
        {
            HasKey(r => r.LogId);
        }
    }
}
