using Domain.Advertisements;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.Common.Configuration
{
    public class AdvertisementCategoryConfiguration : EntityTypeConfiguration<AdvertisementCategory>
    {
        public AdvertisementCategoryConfiguration()
        {
            HasKey(b => b.CategoryId);
        }
    }
}
