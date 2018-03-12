using Domin.Common;
using System.Collections.Generic;

namespace Domain.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetAllRoles();
    }
}
