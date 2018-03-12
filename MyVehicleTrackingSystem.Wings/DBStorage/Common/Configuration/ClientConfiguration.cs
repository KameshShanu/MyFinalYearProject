using Domain.Client;
using System.Data.Entity.ModelConfiguration;


namespace DBStorage.Common.Configuration
{
   public class ClientConfiguration : EntityTypeConfiguration<Domain.Client.Client>
    {
        public ClientConfiguration()
        {
            HasKey(d => d.ClientId);
        }
    }
}
