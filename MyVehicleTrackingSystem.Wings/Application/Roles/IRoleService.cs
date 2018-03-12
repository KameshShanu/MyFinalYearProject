using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Roles;

namespace Application.Roles
{
    public interface IRoleService
    {
        IEnumerable<Role> getUserRoles();
    }
}
