using Domain.Roles;
using System.Data.Entity.ModelConfiguration;

namespace DBStorage.Common.Configuration
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.HasKey(o => o.RoleId);
        }
    }
}
