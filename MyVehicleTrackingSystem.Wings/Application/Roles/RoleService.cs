using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Roles;
using DBStorage.Roles;

namespace Application.Roles
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleResitory;
        public RoleService(RoleRepository roleRepository)
        {
            _roleResitory = roleRepository;
        }
        public IEnumerable<Role> getUserRoles()
        {
            return _roleResitory.GetAllRoles();
        }
    }
}
