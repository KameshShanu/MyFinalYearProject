using Domain.Corporates;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class CorporateConfiguration : EntityTypeConfiguration<Corporate>
    {
        public CorporateConfiguration()
        {
            HasKey(b => b.CorporateId);
        }
    }
}
