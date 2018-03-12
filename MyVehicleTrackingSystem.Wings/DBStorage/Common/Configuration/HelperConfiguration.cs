using Domain.Helper;
using System.Data.Entity.ModelConfiguration;

namespace DBStorage.Common.Configuration
{
    public class HelperConfiguration : EntityTypeConfiguration<Domain.Helper.Helper>
    {
        public HelperConfiguration()
        {
            HasKey(d => d.HelperId);
        }
    }
}
