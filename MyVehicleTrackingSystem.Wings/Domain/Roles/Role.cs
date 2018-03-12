using Domain.Users;
using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Roles
{
    public class Role : BaseEntity
    {
        public int RoleId
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public virtual ICollection<User> Users
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return RoleId == 0;
        }
    }
}
