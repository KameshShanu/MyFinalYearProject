using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Advertisements;

namespace Application.Advertisements
{
    public interface IAdvertisementCategoryService
    {
        IEnumerable<AdvertisementCategory> getAdvertisements();
        void SaveAdvertisementCategory(AdvertisementCategory advertisementCategory);
        AdvertisementCategory GetAdvertisementCategoryById(int id);
        void UpdateAdvertisementCategory(AdvertisementCategory advertisement);
        void DeleteAdvertisementCategory(int id);
        void SortAdvertisementCategories(List<int> items);
    }
}
