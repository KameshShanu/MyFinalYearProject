using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserToOrganization
{
    public class UserToOrganization : BaseEntity
    {
        public int UserId
        {
            get;
            set;
        }

        public int OrganizationId
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
