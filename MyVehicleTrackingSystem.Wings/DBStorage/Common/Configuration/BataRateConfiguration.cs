using Domain.BataRates;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class BataRateConfiguration : EntityTypeConfiguration<BataRate>
    {
        public BataRateConfiguration()
        {
            HasKey(b => b.BataId);
            //HasOptional(d => d.TripList).WithOptionalPrincipal(l => l.BataRateList).Map(x => x.MapKey("BataRateList_BataRateId")); ;
        }
    }
}
