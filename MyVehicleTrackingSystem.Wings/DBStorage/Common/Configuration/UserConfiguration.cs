namespace DBStorage.Common.Configuration
{
    using Domain.Users;
    using System.Data.Entity.ModelConfiguration;

    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasKey(o => o.UserId);
        }
    }
}
