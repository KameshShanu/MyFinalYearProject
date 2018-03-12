using Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Advertisements
{
    public interface IAdvertisementCategoryRepository : IRepository<AdvertisementCategory>
    {
        IEnumerable<AdvertisementCategory> getAdvertisements();
        void SaveAdvertisementCategory(AdvertisementCategory advertisementCategory);
        AdvertisementCategory GetAdvertisementCategoryById(int id);
        void UpdateAdvertisementCategory(AdvertisementCategory advertisement);
        void DeleteAdvertisementCategory(int id);
        void SortAdvertisementCategories(List<int> items);
    }
}
