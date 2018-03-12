using DBStorage.Common;
using Domain.Roles;
using System.Collections.Generic;

namespace DBStorage.Roles
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(WingsContext context) : base(context)
        {
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return Context.Set<Role>();
        }
    }
}
