using Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class AdvertisementItemConfiguration: EntityTypeConfiguration<AdvertisementItem>
    {
        public AdvertisementItemConfiguration()
        {
            HasKey(b => b.ItemId);
            HasRequired(t => t.AdvertisementCategory).WithMany(r => r.AdvertisementItem).HasForeignKey(t => t.CategoryId);
        }
    }
}
